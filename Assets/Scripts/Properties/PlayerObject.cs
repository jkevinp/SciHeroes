using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerObject : MonoBehaviour {
    public enum PlayerType
    {
        EnemyRootedAI,
        Player,
        EnemyAI
    }
    public enum TurnStatus
    {
        Setup,
        Idle,
        Answering,
        Answered,
        MoveBack,
        AfterAttack,
        Info,
        Victory,
        GameOver,
        QuestionBreakSetup,
        QuestionBreakInteract,
        QuestionBreakAttack,
        QuestionBreakEnd
    }
    public enum PlayerState
    {
        Breaking,
        Dead,
        Normal
    }
    public PlayerType type = PlayerType.Player;
    public PlayerState state = PlayerState.Normal;
    public TurnStatus _turnStatus = TurnStatus.Idle;

    public float Health = 100;
    public float Damage = 1;

    public float waitTime = 5;
    float moveSpeed = 0.05f;
    public float _currentWaitTime = 0;
    public int maxCombo = 5;
    public bool useSpecial = false;
    
    
    public GameObject damageResult = null;
    
    private Vector3 _startPos = Vector3.zero;
    bool hasAttacked = false;
    int selectedIndex = 0;
    private List<GameObject> enemyList = null;
    [HideInInspector]
    public GameObject _target = null;
    [HideInInspector]
    public Vector3 _lookAt;


    int terrainLayerMask;
    System.Random rand = new System.Random(100);
    private GameObject _damageResult = null;
    public AudioClip audioTeleport = null;
    private bool hasPlayedTeleport = false;
    private int questionBreakIndex = 1;
    private Animation _anim = null;
    private AudioSource _audioSource = null;

    public virtual void Start () {
       _startPos = this.gameObject.transform.position;
       _audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
       _currentWaitTime = waitTime;
       if (type != PlayerType.Player) enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
       else enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
       _lookAt = enemyList[0].transform.position;
       this.transform.LookAt(_lookAt);
       terrainLayerMask = 1 << 8;
       _damageResult = damageResult;
       _anim = this.GetComponent<Animation>();
	}
    public void ApplyDamage(float _damage)
    {
        ShowDamage(_damage);

        //Apply the Damage
        if (this.Health - _damage >= 0) 
            this.Health -= _damage;
        else this.Health = 0;
        /*AudioManager
        if (this._Health <= 50 && type == PlayerType.Player)//If the Receiver of the attack is a player , change BGM
        {
            if (FnGlobal.GetAudioSource().clip != danger)
            {
                FnGlobal.GetAudioSource().clip = danger;
                FnGlobal.GetAudioSource().Play();
            }
        }*/
        if (this.Health <= 0) //if the receiver Hit points is 0 , it is dead
        {
            this.GetComponent<Animation>().CrossFade("Dead"); //play Dead animation
            this.state = PlayerState.Dead;//change State to dead
            this.GetComponent<Collider>().enabled = false;//off the collider
            this.GetComponent<Rigidbody>().useGravity = false; //off the rigid body gravity
            Collider[] c = this.GetComponentsInChildren<Collider>(); //get all colliders
            foreach (Collider _c in c)
            {
                _c.enabled = false; //off the collider
            }
            /* AudioManager
            if (gameOver != null)
            {
                FnGlobal.GetAudioSource().clip = gameOver;
                FnGlobal.GetAudioSource().Play();
            }*/
            return;
        }
        if (type == PlayerType.Player && this._turnStatus != TurnStatus.Answered)
        {
            this.GetComponent<Animation>().CrossFade("Hit");
            this.GetComponent<Animation>().CrossFadeQueued("Idle");
        }
        else if (type == PlayerType.EnemyAI)
        {
            this.GetComponent<Animation>().CrossFade("Block");
            this.GetComponent<Animation>().CrossFadeQueued("Idle");
        }
    }
    public bool Move(Vector3 _current , Vector3 _targetPos, float moveSpeed, bool isLookToTarget,  bool playAnim , float _distance)
    {
        bool _diff =Vector3.Distance(_current, _targetPos) >= _distance;
        if (_diff)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _targetPos, moveSpeed);
            this._anim.CrossFade("Run");
            this.transform.LookAt(_targetPos);
        }
        return _diff;

    }
    public void Hit()
    {

    }
    public void Attack(Animation _anim , GameObject _target , float _dmg)
    {
        _anim.CrossFade("Attack");
        _target.GetComponent<PlayerObject>().ApplyDamage(_dmg);
        this.hasAttacked = true;
    }
    public void SpecialAttack(Animation _anim, GameObject _target, float _dmg)
    {
        _anim.CrossFade("Special");
        _target.GetComponent<PlayerObject>().ApplyDamage(_dmg * 2);
        useSpecial = false;
        this.hasAttacked = true;
    }
    void ShowDamage(float _dmg)
    {
        damageResult = Instantiate(_damageResult, Vector3.up + _target.transform.position, this.transform.rotation) as GameObject;
        damageResult.transform.Find("Text").GetComponent<Text>().text = "-" + _dmg;
    }
    public void Charge(GameObject weaponGlow ,GameObject glow)
    {
       
        if (this.useSpecial && !weaponGlow.activeInHierarchy)
        {

            weaponGlow.SetActive(true);
            this.GetComponent<Animation>().CrossFade("Charge");
            this._currentWaitTime = waitTime;
            this.hasAttacked = false;
           
        }
        else if (!this.useSpecial)
        {
            if (glow != null) weaponGlow.SetActive(false);
            this.GetComponent<Animation>().CrossFade("Idle");
            this._currentWaitTime = waitTime;
            this.hasAttacked = false;
            this._turnStatus = TurnStatus.Idle;
        }
        if (!this.GetComponent<Animation>().IsPlaying("Charge"))
        {
            this._turnStatus = TurnStatus.Idle;
        }
    }
    void CancelBreak()
    {
        questionBreakIndex = 0;
        _turnStatus = TurnStatus.Idle;
    }
    public void BreakCharge(GameObject glow)
    {

        if (this.GetComponent<TrailRenderer>() == null) this.gameObject.AddComponent<TrailRenderer>();
            this.GetComponent<TrailRenderer>().startWidth = 3f;
            this.GetComponent<TrailRenderer>().endWidth = 0.5f;
            this.GetComponent<TrailRenderer>().material.color = Color.green;
        
        if (_target != null)
        {
            _target.transform.LookAt(this.transform);
            _target.gameObject.GetComponent<Animation>().Play("Hit");
        }

        if (Vector3.Distance(this.transform.position, this._target.transform.position) <= 5)
        {
            if (!hasPlayedTeleport)
            {
                if (audioTeleport != null) _audioSource.PlayOneShot(audioTeleport);
                hasPlayedTeleport = true;
            }
           
            _anim.Play("Run");
            
            this.transform.LookAt(_target.transform.forward * 6 + _target.transform.position );
            foreach (Collider _c in this.gameObject.GetComponentsInChildren<Collider>()) _c.enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.forward * 6 + _target.transform.position + Vector3.right, 0.2f);
            
            return;
        }else{

            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
            foreach (Collider _c in this.gameObject.GetComponentsInChildren<Collider>()) _c.enabled = true;
            this.transform.LookAt(_target.transform);
            this.GetComponent<Rigidbody>().useGravity = true;
        }

        if (glow.activeInHierarchy)
        {
            if (!this.GetComponent<Animation>().IsPlaying("Charge"))
            {
                this._turnStatus = TurnStatus.QuestionBreakInteract;
            }
        }
        else
        {
            
            this.GetComponent<Animation>().CrossFade("Charge");
            if (this.GetComponent<Animation>().IsPlaying("Charge"))
            glow.SetActive(true);
            this._currentWaitTime = waitTime;
            this.hasAttacked = false;
            if (_target != null) this.transform.LookAt(_target.transform);
            RenderSettings.fogColor = Color.yellow;
            RenderSettings.fogDensity = 0.09f;
            RenderSettings.fog = true;

        }
    }
    public void BreakAttack()
    {
        this.GetComponent<Animation>()["Combo" + questionBreakIndex].speed = 1f;
        if (!this.GetComponent<Animation>().isPlaying)
        {
            this._turnStatus = TurnStatus.QuestionBreakEnd;
            print("sssss");
        }
    }
    public void BreakInteract()
    {
        this.GetComponent<Animation>()["Combo" + questionBreakIndex].speed = 0.05f;
        this.GetComponent<Animation>().CrossFade("Combo" + questionBreakIndex);
    }
    public void BreakEnd()
    {

    }
    public void Idle()
    {
        questionBreakIndex = 1;
        hasPlayedTeleport = false;
        if ((_currentWaitTime == waitTime) && _target != null)
        {
            float xx = (float)rand.Next(1, 3);
            if (_startPos != this.transform.position) _startPos = this.transform.position - this.transform.forward * xx;
        }
        if (_currentWaitTime - Time.fixedDeltaTime > 0)
        {
            _currentWaitTime -= Time.fixedDeltaTime;
            if (Move(this.transform.position, _startPos, moveSpeed, true, true, 0.5f) && !this.GetComponent<Animation>().IsPlaying("Attack"))
            {

            }
            else
            {
                this.GetComponent<Animation>().CrossFade("Idle");
                this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                if (_target != null) this.transform.LookAt(_target.transform);
            }
        }
        else
        {
            _turnStatus = TurnStatus.Answering;
        }
    }
    void cursorMove()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var fwd = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(fwd, out hit, Mathf.Infinity, (1 << 9)))
            {
                if (hit.transform.tag == CFG.TAG_ENEMY)
                    _target = hit.transform.gameObject;
            }
        }
    }
    public void PlayerMovement(Player _p)
    {
        CheckEnemies();
        cursorMove();
        switch (_turnStatus)
        {
            case TurnStatus.QuestionBreakSetup:
                BreakCharge(_p.glow);
                break;
            case TurnStatus.QuestionBreakInteract:
                BreakInteract();
                break;
            case TurnStatus.QuestionBreakAttack:
                BreakAttack();
            break;
            case TurnStatus.QuestionBreakEnd:
            questionBreakIndex += 1;
            if (questionBreakIndex <= 3)this._turnStatus = TurnStatus.QuestionBreakInteract;
            else
            {
                RenderSettings.fogColor = Color.cyan;
                RenderSettings.fogDensity = 0.09f;
                RenderSettings.fog = true;
                this._turnStatus = TurnStatus.Setup;
                _p.glow.SetActive(false);
            }
            break;
            case TurnStatus.Setup:
               Charge(_p.weaponGlow , _p.glow);
            break;
            case TurnStatus.Idle:
                Idle();
            break;
                 
            case TurnStatus.Answering:
                  _target = enemyList[selectedIndex];
                  if (!this.GetComponent<Animation>().IsPlaying("Hit")) this.GetComponent<Animation>().CrossFade("Idle");
                  float x = (float)rand.Next(-5,5);
                  float y = (float)rand.Next(-3,3);
                  if (_startPos != this.transform.position) _startPos = _target.transform.position + new Vector3(x, 0, y);
            break;
            case TurnStatus.Answered:
                if (_target == null) _target = enemyList[selectedIndex];
                else
                {
                    if (!hasAttacked)
                    {
                        if (!Move(this.transform.position, _target.transform.position, moveSpeed, true, true, 1f))
                        {
                            if (!useSpecial) Attack(this._anim, this._target , this.Damage);
                            else SpecialAttack(this._anim,this._target, this.Damage);
                        }
                    }
                    else
                    {
                      if (!this.GetComponent<Animation>().IsPlaying("Attack") && !this.GetComponent<Animation>().IsPlaying("Special")) this._turnStatus = TurnStatus.MoveBack;
                    }
                }
            break;
            case TurnStatus.MoveBack:
                float dis = Vector3.Distance(this.transform.position, _startPos);
                if (Move(this.transform.position, _startPos, moveSpeed, true, true, 0.5f) && !this.GetComponent<Animation>().IsPlaying("Attack") && !this.GetComponent<Animation>().IsPlaying("Special"))
                {
                    
                }
                else{
                    this.GetComponent<Animation>().CrossFade("Idle");
                    this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                    this.transform.LookAt(_target.transform);
                    this._turnStatus = TurnStatus.AfterAttack;
                }
            break;
            case TurnStatus.AfterAttack:
                this._turnStatus = TurnStatus.Setup;
            break;
        }
    }
    public void AiMovement()
    {
        print("Ai movement");
        if (_target != null) if (_target.GetComponent<PlayerObject>().state == PlayerState.Dead) return;
        switch (_turnStatus)
        {
            case TurnStatus.Idle:
                if (_currentWaitTime > 0) _currentWaitTime -= Time.fixedDeltaTime;
                else _turnStatus = TurnStatus.Answered;
                break;
            case TurnStatus.Answered:
                if (_target == null) _target = enemyList[new System.Random().Next(0, enemyList.Count - 1)];
                else{
                    this.transform.LookAt(_target.transform);
                    print(_target.name);
                    if (Vector3.Distance(this.transform.position, _target.transform.position) > 1 && !hasAttacked)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, _target.transform.position, moveSpeed);
                        this.GetComponent<Animation>().CrossFade("Run");
                    }
                    else
                    {
                        if (!hasAttacked){
                            this.GetComponent<Animation>().CrossFade("Attack");
                            this.hasAttacked = true;
                            _target.GetComponent<PlayerObject>().ApplyDamage(this.Damage);
                            damageResult = Instantiate(_damageResult, Vector3.up + _target.transform.position, this.transform.rotation) as GameObject;
                            damageResult.transform.Find("Text").GetComponent<Text>().text = "-" +this.Damage;
                        }
                        else{
                          
                            if (!this.GetComponent<Animation>().IsPlaying("Attack"))
                            {
                                this.GetComponent<Animation>().CrossFade("Idle");
                                SetToIdle();
                            }
                        }
                    }
                }
           break;

            case TurnStatus.MoveBack:
                float dis = Vector3.Distance(this.transform.position, _startPos);
                if (dis > 1){
                    this.transform.position = Vector3.MoveTowards(this.transform.position, _startPos, moveSpeed);
                    this.GetComponent<Animation>().CrossFade("Run");
                    this.transform.LookAt(_startPos);
                }
                else{
                    this.GetComponent<Animation>().CrossFade("Idle");
                    this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                    this._turnStatus = TurnStatus.Idle;
                }
           break;
        }
    }
    public void RootedMovement()
    {
        if (_target != null) if (_target.GetComponent<PlayerObject>().state == PlayerState.Dead) return;
       
        switch (_turnStatus)
        {
            case TurnStatus.Idle:
                this.GetComponent<Animator>().Play("Idle");
                if (_currentWaitTime > 0) _currentWaitTime -= Time.fixedDeltaTime;
                else _turnStatus = TurnStatus.Answered;
                break;
            case TurnStatus.Answered:
                if (_target == null) _target = enemyList[new System.Random().Next(0, enemyList.Count - 1)];
                else
                {
                    this.transform.LookAt(_target.transform);
                    
                        if (!hasAttacked)
                        {
                            this.hasAttacked = true;
                            this.GetComponent<Rooted>().Attack();
                            this.GetComponent<Animator>().Play("Attack");
                        }
                        else
                        {
                                SetToIdle();
                        }
                }
                break;

            case TurnStatus.MoveBack:
                  this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                  this._turnStatus = TurnStatus.Idle;
            break;
        }
    }
    void SetToIdle()
    {
        this.transform.LookAt(_startPos);
        _currentWaitTime = waitTime;
        hasAttacked = false;
        this._turnStatus = TurnStatus.MoveBack;
    }
    public void ShowInfo(Player _p)
    {

        if (type != PlayerType.Player) return;
        if (this.state == PlayerState.Dead || _turnStatus == TurnStatus.Victory) return;
        if (_p.skin != null)if (GUI.skin != _p.skin) GUI.skin = _p.skin;
        if (_turnStatus != TurnStatus.MoveBack)
        {
            if (GUI.Button(new Rect(Screen.width * 0.89f, Screen.height * 0.82f, Screen.width * 0.1f, Screen.height * 0.1f), "Target"))
            {
                if (selectedIndex < enemyList.Count - 1) selectedIndex += 1;
                else selectedIndex = 0;
                _lookAt = enemyList[selectedIndex].transform.position;
                this.transform.LookAt(_lookAt);
            }
        }
        //question
        GUI.Box(new Rect(0, Screen.height * 0.82f, Screen.width * 0.1f, Screen.height * 0.07f), "HP");
        GUI.Box(new Rect(Screen.width * 0.1f, Screen.height * 0.82f, Screen.width * 0.7f, Screen.height * 0.04f), "", GUI.skin.GetStyle("slider_fg_red"));
        GUI.Box(new Rect(Screen.width * 0.1f + 10, Screen.height * 0.83f, (Screen.width * 0.7f) * Health / 100 - 20, Screen.height * 0.02f), "", GUI.skin.GetStyle("slider_bg"));
        switch (_turnStatus)
        {
            case TurnStatus.Idle:

                GUI.Box(new Rect(0, Screen.height * 0.91f, Screen.width * 0.1f, Screen.height * 0.07f), "TIME");
                GUI.Box(new Rect(Screen.width * 0.1f, Screen.height * 0.91f, Screen.width * 0.7f , Screen.height * 0.04f), "", GUI.skin.GetStyle("slider_bg"));
                GUI.Box(new Rect(Screen.width * 0.1f+10, Screen.height * 0.92f, (Screen.width * 0.7f) * _currentWaitTime / waitTime - 20 , Screen.height * 0.02f), "", GUI.skin.GetStyle("slider_fg"));
            break;
        }
    }
    void CheckEnemies()
    {
        selectedIndex = 0; //change the target
        enemyList = enemyList.FindAll(p => p.GetComponent<PlayerObject>().state != PlayerState.Dead);//get all enemies that are not dead.
        print(enemyList.Count);
        if (enemyList.Count == 0) //check if there are still enemies that are alive
        {
            this._turnStatus = TurnStatus.Victory; //if no enemies are alive, do Victory
        }
    }
}
