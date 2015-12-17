using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public static class FnGlobal{
    public static GameObject F_Obj(string _tag)
    {
        return GameObject.FindGameObjectWithTag(_tag);
    }
    public static GameObject[] F_Objs(string _tag)
    {
        return GameObject.FindGameObjectsWithTag(_tag);
    }
    public static T[] F_Objs<T>(string _tag)
    {
        List<T> _list = new List<T>();
        GameObject[] _gs =  GameObject.FindGameObjectsWithTag(_tag);
        foreach (GameObject _g in _gs)
        {
            _list.Add(_g.GetComponent<T>());
        }
        return _list.ToArray();
    }
    public static T L_Obj<T>(string _dir, string _name) where T : UnityEngine.Object
    {
        T _object = Resources.Load < T>(_dir + _name) as T;
        return _object;
    }
    public static void LoadLevel(string _levelName){
        CFG.GS = CFG.GAMESTATE.LOADING;
        GameObject _loadingCanvas = F_Obj("Loading") == null ? L_Obj<GameObject>(CFG.DIR_UI , "LoadingCanvas") : F_Obj("Loading");
        _loadingCanvas = GameObject.Instantiate(_loadingCanvas) as GameObject;
        _loadingCanvas.SetActive(true);
        Application.LoadLevel(_levelName);
    }
    public static GameObject GetPlayer()
    {
        return F_Obj(CFG.TAG_PLAYER);
    }
    public static T GetPlayer <T>()
    {
        return F_Obj(CFG.TAG_PLAYER).GetComponent<T>();
    }
    public static AudioSource GetAudioSource()
    {
        return F_Obj(CFG.TAG_MAINCAM).GetComponent<AudioSource>();
    }
    public static AudioClip GetBGM(string _name)
    {
        return L_Obj<AudioClip>(CFG.DIR_BGM, _name);
    }
    public static AudioClip GetUiSFX(string _name)
    {
        return L_Obj<AudioClip>(CFG.DIR_SFX_UI , _name);
    }
    public static AudioClip GetPlayerSfX(string _name)
    {
        return L_Obj<AudioClip>(CFG.DIR_SFX_PLAYER , _name);
    }
}
