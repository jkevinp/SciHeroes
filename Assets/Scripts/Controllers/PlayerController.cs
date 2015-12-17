using UnityEngine;
using System.Collections;

public class PlayerController : Controller {

    public GameObject player = null;
    private Rigidbody _rigidBody = null;
    private Player _playerObject = null;
    private Animation _anim = null;
    public float moveSpeed = 5;
    public float turnSpeed = 45;
	void Start () {
        player = FnGlobal.F_Obj(CFG.TAG_PLAYER);
        _playerObject = player.GetComponent<Player>();
        _rigidBody = player.GetComponent<Rigidbody>();
        _anim = player.GetComponent<Animation>();
	}
	
	
	void Update () {
        if (!this.enabled) return;
        if (_anim.IsPlaying("Attack")) return;
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * turnSpeed;
        player.transform.Rotate(Vector3.up * x);
        if(z != 0)
        _rigidBody.velocity = _playerObject.transform.forward * z;

        //if (_rigidBody.velocity != Vector3.zero)
        //{
          //  player.transform.LookAt(_rigidBody.velocity * 5);
        //}
        if (_rigidBody.velocity != Vector3.zero) _anim.CrossFade("Run");
        else if (_rigidBody.velocity == Vector3.zero) _anim.CrossFade("Idle");

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _anim.CrossFade("Attack");
        }
        
	}
}
