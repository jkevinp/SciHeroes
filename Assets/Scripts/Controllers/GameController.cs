using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController  : Controller {
    public GameMode gameMode = GameMode.BATTLE;
    public int playerLayerMask = 1 << 9;
    Dictionary<GameMode, List<Controller>> _dicController;

    public HumanoidController _humanoidController = null;
    public QuestionController _questionController = null;
    public PlayerController _playerController = null;
    public override void Start () {
        base.Start();
        CFG.ApplyFPSRate();
        _humanoidController = this.GetComponent<HumanoidController>();
        _playerController = this.GetComponent<PlayerController>();
        _questionController = this.GetComponent<QuestionController>();
        _humanoidController.enabled = false;
        _questionController.enabled = false;
        Setup();
	}
    public override void Update(){
        base.Update();
        switch (gameMode)
        {
            case GameMode.BATTLE:
                  _humanoidController.enabled = true;
                  _questionController.enabled = true;
                  _playerController.enabled = false;
            break;

            case GameMode.STROLL:
            _playerController.enabled = true;
                _humanoidController.enabled = false;
                _questionController.enabled = false;
            break;
        }
	}
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    void Setup()
    {
        
    }
    
}
