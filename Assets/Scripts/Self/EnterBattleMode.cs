using UnityEngine;
using System.Collections;

public class EnterBattleMode : MonoBehaviour {

    public GameObject target = null;
    public GameController gameControl = null;
    GameObject p;
    bool moveToTarget = false;
    void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == CFG.TAG_PLAYER)
        {
            p = c.transform.gameObject;
            moveToTarget = true;
            print("Collided");
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!moveToTarget) return;
       
        
        if (Vector3.Distance(p.transform.position, target.transform.position) >= 1)
        {
            //print("moving to target. dist : " + Vector3.Distance(p.transform.position, target.transform.position));
            //p.GetComponent<Rigidbody>().velocity = p.transform.forward * 5;
            //p.transform.LookAt(new Vector3(target.transform.position.x, 0, target.transform.position.z));
            p.transform.position = target.transform.position;
        }
        else
        {
            gameControl.gameMode = Controller.GameMode.BATTLE;
            moveToTarget = false;
            Destroy(this.gameObject);
        }
	}
}
