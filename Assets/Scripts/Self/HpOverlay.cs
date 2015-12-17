using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpOverlay : MonoBehaviour {

    GameObject _parent = null;
    public PlayerObject _parentPlayerObj = null;
    public Slider _hp, _time;
    public Texture wait = null, attack = null;
    Text _name = null;
    RawImage _icon = null;
    void Start () {
        _parent = this.transform.parent.gameObject;
        _parentPlayerObj = _parent.GetComponent<PlayerObject>();
        _hp = this.transform.Find("Panel").Find("slider_hp").GetComponent<Slider>();
        _time = this.transform.Find("Panel").Find("slider_time").GetComponent<Slider>();
        _name = this.transform.Find("Panel").Find("txt_enemyname").GetComponent<Text>();
        _icon = this.transform.Find("Panel").Find("img_icon").GetComponent<RawImage>();
        if (_name != null) _name.text = _parent.name;
        if (_time != null) _time.maxValue = _parentPlayerObj.waitTime;
	}
	void FixedUpdate () {
        if(_time != null)_time.value = _parentPlayerObj._currentWaitTime;
        if(_hp != null)_hp.value = _parentPlayerObj.Health;
        this.transform.position = _parent.transform.position + new Vector3(0, 1.5f, 0);
        this.transform.LookAt(Camera.main.transform);
        switch (_parentPlayerObj._turnStatus)
        {
            case PlayerObject.TurnStatus.Idle:
                if(_icon.texture != wait)_icon.texture = wait;
            break;
            case PlayerObject.TurnStatus.Answered:
            if (_icon.texture != attack) _icon.texture = attack;
           break;
        }
	}
}
