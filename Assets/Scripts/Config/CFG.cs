using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class  CFG  {
    public static string DIR_PREFAB = "Prefabs/";
    public static string DIR_CHARACTERS = DIR_PREFAB + "Characters/";
    public static string DIR_ENEMIES = DIR_CHARACTERS + "Enemies/";
    public static string DIR_UI = DIR_PREFAB + "UI/";

    public static string DIR_AUDIO = "Audios/";
    public static string DIR_BGM = DIR_AUDIO + "BGM/";
    public static string DIR_SFX = DIR_AUDIO + "FX/";
    public static string DIR_SFX_UI = DIR_SFX + "UI/";
    public static string DIR_SFX_PLAYER = DIR_SFX + "Player/";

    public static string TAG_MAINCAM = "MainCamera";
    public static string TAG_PLAYER = "Player";
    public static string TAG_ENEMY = "Enemy";
    public static int TARGET_FRAMERATE = 45;
    public enum GAMESTATE
    {
        PLAYING,
        LOADING,
        UI,
        MENU,
        STOP
    }
    public static GAMESTATE GS = GAMESTATE.PLAYING;

    public static void ApplyFPSRate()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = TARGET_FRAMERATE;
    }
}
