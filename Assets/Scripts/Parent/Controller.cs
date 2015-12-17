using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
  
	// Use this for initialization
    public CFG.GAMESTATE gameStart = CFG.GAMESTATE.PLAYING;
    public bool showDebug = true;
    public bool enabled = true;
    public enum GameMode
    {
        STROLL,
        BATTLE
    }
    
    public virtual void Start () {
       
	}
    public virtual void Update()
    {
        if (gameStart == CFG.GAMESTATE.PLAYING) return;
    }
    public virtual void FixedUpdate()
    {
        if (gameStart == CFG.GAMESTATE.PLAYING) return;
    }
    public virtual void OnGUI()
    {
        if (gameStart == CFG.GAMESTATE.PLAYING) return;
    }

    public List<T> RayCastObject<T>(string _tag )
    {
        List<T> _list = new List<T>(FnGlobal.F_Objs<T>(_tag));
        return _list;
    }
}
