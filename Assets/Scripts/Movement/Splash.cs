using UnityEngine;
using System.Collections;

public class Splash : AfterEffect {

    public int number = 5;
    public GameObject prefab;
    GameObject[] prefabList;
    public bool randomDirection = true;
    public int maxX = 3, maxY = 5, maxZ = 3 ,minSpeed =2, maxSpeed=5;
    public float lifeTime = 2;
    System.Random _random = new System.Random();
	void Start () {
        prefabList = new GameObject[5];
        for (int x = 0; x < 5; x++)
        {
            prefabList[x] = Instantiate(prefab, this.transform.position, Quaternion.identity) as GameObject;
            if (prefabList[x].GetComponent<Rigidbody>() == null)prefabList[x].AddComponent<Rigidbody>();
            AddForce(prefabList[x]);
        }
        //Invoke("Destroy", lifeTime);
	}
    void AddForce(GameObject p)
    {       
            if (p.GetComponent<Rigidbody>() != null)
            {
                Move(p);
            }
            else
            {
                p.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
                Move(p);
            }
        
    }
    void Move(GameObject p)
    {
        var dir = new Vector3(_random.Next(maxX), _random.Next(maxX), _random.Next(maxX));
        if (randomDirection)
        {
            p.GetComponent<Rigidbody>().AddForce(dir * _random.Next(minSpeed, maxSpeed), ForceMode.Impulse);
            p.transform.LookAt(p.transform.forward * 2);
        }
        else
        {
            p.GetComponent<Rigidbody>().AddForce(dir * 5, ForceMode.Impulse);
        }
               
    }
    void Destroy()
    {
        foreach (GameObject g in prefabList)
        {
            Destroy(g);
        }
    }
}
