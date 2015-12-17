using UnityEngine;
using System.Collections;

public class Player : PlayerObject {
    public GUISkin skin = null;
    public AudioClip gameOver = null, danger = null;
    public GameObject glow = null, weaponGlow = null;
    public GameObject  target_plane = null;
    
    void Start () {
        base.Start();
        this.type = PlayerType.Player;
        if (type == PlayerType.Player)
        {
            target_plane = Instantiate(target_plane, _lookAt + Vector3.up, Quaternion.identity) as GameObject;
            glow = this.transform.Find("Glow").gameObject;
            if (glow != null) glow.SetActive(false);
        }
	}
	void Update () {
        
    }
    
}
