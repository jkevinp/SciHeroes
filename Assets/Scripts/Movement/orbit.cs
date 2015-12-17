using UnityEngine;
using System.Collections;

public class orbit : MonoBehaviour {

    public Transform _target = null;
    float rotation = 0;
    Vector3 offset = new Vector3(5, 3, 0);
    bool hasAssigned = false;
    public Transform comboCameraTarget = null;
    private PlayerObject _player;
    void Start()
    {
        _player = FnGlobal.GetPlayer().GetComponent<PlayerObject>();
    }
	void Update () {
        if (FnGlobal.GetPlayer() == null) return;
        if (FnGlobal.GetPlayer().GetComponent<PlayerObject>()._turnStatus == PlayerObject.TurnStatus.Answered)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 45, Time.fixedDeltaTime * 10);
            //this.transform.position = Vector3.MoveTowards(this.transform.position, FnGlobal.GetPlayer().GetComponent<PlayerObject>().transform.position - FnGlobal.GetPlayer().GetComponent<PlayerObject>().transform.forward + offset, 10 * Time.fixedDeltaTime);
        }
        else if (_player._turnStatus == PlayerObject.TurnStatus.QuestionBreakSetup || _player._turnStatus == PlayerObject.TurnStatus.QuestionBreakEnd ||_player._turnStatus == PlayerObject.TurnStatus.QuestionBreakInteract ||
            _player._turnStatus == PlayerObject.TurnStatus.QuestionBreakAttack)
        {
            this.transform.LookAt(_player._target.transform);
            this.transform.position = Vector3.MoveTowards(this.transform.position, comboCameraTarget.transform.position , 20 * Time.fixedDeltaTime);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 45, Time.fixedDeltaTime * 10);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.fixedDeltaTime * 10);
            rotation += Time.fixedDeltaTime;
            this.transform.LookAt(_target);
            this.transform.Translate(Vector3.right * Time.fixedDeltaTime);
            
        }
	}
}
