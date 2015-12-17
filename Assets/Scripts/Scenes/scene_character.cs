using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class scene_character : MonoBehaviour
{

    public GUISkin skin = null;
    private Vector2 scrollPos = Vector2.zero, scrollPos2 = Vector2.zero;
    private float unlockedStages = 0, currentPoints = 0;
    private Rect ScrollViewStagesSize;
    GameObject[] turretList;
    private GameObject currentTurret = null;
    //private UnitTower currentUnit = null;
    private GUIContent[] contentList;

    List<string> unlockedList = new List<string>();
    void Start()
    {
        ScrollViewStagesSize = new Rect(0, Screen.height * 0.1f, Screen.width / 2, Screen.height);
      //  unlockedStages = GlobalFunctions.GetUnlockedStages();
        turretList = Resources.LoadAll<GameObject>("Prefab/Towers") as GameObject[];
        GameObject cube = GameObject.Find("Platform");
        contentList = new GUIContent[turretList.Length];
        for (int x = 0; x < turretList.Length; x++)
        {
            turretList[x] = Instantiate(turretList[x], cube.transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity) as GameObject;
            turretList[x].SetActive(false);
          //  if (turretList[x].GetComponent<UnitTower>() != null)
            //    contentList[x] = new GUIContent(turretList[x].GetComponent<UnitTower>().unitName);
            //else contentList[x] = new GUIContent(turretList[x].name);
        }
    }
    void Update()
    {
       // if (currentPoints != GlobalFunctions.GetInt(Config.PREF_POINTS)) currentPoints = GlobalFunctions.GetInt(Config.PREF_POINTS);
    }

    void OnGUI()
    {
        if (skin != null) if (GUI.skin != skin) GUI.skin = skin;
        GUI.Label(new Rect(Screen.width * 0.75f, 0, Screen.width / 4, Screen.height * 0.1f), "Shop", GUI.skin.GetStyle("customLabel"));
        //GUI.Label(new Rect(0, 0, Screen.width / 4, Screen.height * 0.1f), "Points: " + GlobalFunctions.GetInt(Config.PREF_POINTS), GUI.skin.GetStyle("customLabel"));
        if (currentTurret != null) currentTurret.transform.Rotate(Vector3.up * 1);
        scrollPos2 = GUI.BeginScrollView(new Rect(Screen.width * 0.75f, Screen.height * 0.1f, Screen.width / 4, Screen.height * 0.8f), scrollPos2, new Rect(0, 0, Screen.width / 4, Screen.height * 2));
        //if (GlobalFunctions.GetTowers() != null)
          //  unlockedList = new List<string>(GlobalFunctions.GetTowers());
        for (int x = 0; x < turretList.Length; x++)
        {

            GameObject g = turretList[x];


            if (GUILayout.Button(contentList[x], GUILayout.Width(Screen.width / 4), GUILayout.Height(Screen.height * 0.1f)))
            {
                if (currentTurret != null)
                {
                    currentTurret.SetActive(false);
                    currentTurret.transform.rotation = Quaternion.identity;
                }
                g.SetActive(true);
                currentTurret = g;
                //if (currentTurret.GetComponent<UnitTower>() != null)
                //{

                //  //  currentUnit = currentTurret.GetComponent<UnitTower>();
                //}

            }

        }
        GUI.EndScrollView();
        if (GUI.Button(new Rect(Screen.width * 0.75f, Screen.height * 0.9f, Screen.width / 4, Screen.height * 0.1f), "Back"))
        {
            //GlobalFunctions.LoadLevel("Menu");
        }
        //if (currentTurret != null && currentUnit != null)
        //{

        //    GUI.skin.label.overflow = new RectOffset(Screen.width / 16, Screen.width / 16, 0, 0);
        //    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        //    GUILayout.BeginArea(new Rect(0, Screen.height * 0.1f, Screen.width / 4, Screen.height * 0.8f), "Tower Specs \n", GUI.skin.box);
        //    GUILayout.Label("", GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label(new GUIContent("   " + currentUnit.unitName, currentUnit.icon), GUILayout.Width(Screen.width / 4.5f), GUILayout.Height(Screen.height * 0.1f));
        //    //GUILayout.Label("Price: " + currentUnit.pointsCost + "Points", GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label("Type: " + currentUnit.type.ToString(), GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label("Description: " + currentUnit.description, GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label("Damage: " + currentUnit.baseStat.damage, GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label("Cooldown: " + currentUnit.baseStat.cooldown, GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));
        //    //GUILayout.Label("AOE Radius: " + currentUnit.baseStat.aoeRadius, GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height * 0.05f));

        //    GUILayout.EndArea();
        //    //string search = currentUnit.transform.name.Replace("(Clone)", "");

        //    //if (unlockedList.Find(str => str == search) != null)
        //    //{
        //    //    GUI.Button(new Rect(0, Screen.height * 0.9f, Screen.width / 4, Screen.height * 0.1f), "Item is Already Unlocked!");
        //    //}
        //    //else
        //    //{
        //    //    //if (currentUnit.pointsCost <= currentPoints)
        //    //    //{
        //    //    //    if (GUI.Button(new Rect(0, Screen.height * 0.9f, Screen.width / 4, Screen.height * 0.1f), "Unlock Tower")) GlobalFunctions.AddTower(currentTurret.name);
        //    //    //}
        //    //    else GUI.Button(new Rect(0, Screen.height * 0.9f, Screen.width / 4, Screen.height * 0.1f), "Not Enough Points!");
        //    //}
        //}

    }
}
