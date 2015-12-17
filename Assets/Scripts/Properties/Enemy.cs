using UnityEngine;
using System.Collections;

public class Enemy : PlayerObject {
    public GameObject hpOverlay = null;
	void Start () {
        base.Start();
        this.type = PlayerType.EnemyAI;
        hpOverlay = Instantiate(hpOverlay, this.transform.position, this.transform.rotation) as GameObject;
        hpOverlay.transform.SetParent(this.transform, false);
	}
    void Update()
    {

    }
    
}
