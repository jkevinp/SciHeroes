using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanoidController : Controller {

    public int playerLayerMask = 1 << 9;
    private List<PlayerObject> _enemyList = new List<PlayerObject>();
    private Player _player = null;

    public override void Start(){
        base.Start();
        _enemyList =  this.RayCastObject<PlayerObject>(CFG.TAG_ENEMY);
        _player = FnGlobal.GetPlayer().GetComponent<Player>();
        if(this.showDebug)
        print(_enemyList.Count);
    }
    public override void Update(){
        base.Update();
    }
    public override void FixedUpdate(){
        if (!this.enabled) return;
            base.FixedUpdate();
            UpdatePlayer(_player);
            if (_player.state == PlayerObject.PlayerState.Breaking) return;
            foreach (PlayerObject _p in _enemyList) UpdateHumanoid(_p);
        
    }
    void UpdateHumanoid(PlayerObject _p)
    {
        if (_p.state == PlayerObject.PlayerState.Dead) return;
        if (_p._target != null) _p._lookAt = _p._target.transform.position;
        this.transform.LookAt(_p._lookAt);
        switch (_p.type)
        {
           case PlayerObject.PlayerType.EnemyRootedAI:
                _p.RootedMovement();
            break;
            case PlayerObject.PlayerType.EnemyAI:
            _p.AiMovement();
            break;
        }
    }
    void UpdatePlayer(Player _p)
    {
        if (_p.state == PlayerObject.PlayerState.Dead) return;
            if (_p._target != null) _p._lookAt = _p._target.transform.position;
            this.transform.LookAt(_p._lookAt);
            _p.PlayerMovement(_p);
            _p.target_plane.transform.position = _p._lookAt + new Vector3(0, 0.1f, 0);
    }
    public override void OnGUI()
    {
        if (!this.enabled) return;
            if (_player._turnStatus == PlayerObject.TurnStatus.QuestionBreakSetup || _player._turnStatus == PlayerObject.TurnStatus.QuestionBreakEnd || _player._turnStatus == PlayerObject.TurnStatus.QuestionBreakAttack || _player._turnStatus == PlayerObject.TurnStatus.QuestionBreakInteract) return;
            _player.ShowInfo(_player);
        
    }
  
}
