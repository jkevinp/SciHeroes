using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public GameObject slashParticle = null;
    void Start()
    {
        print("wep started");
    }
    void OnCollisionEnter(Collision c)
    {
        print("wep collided" + c.gameObject.name);
        if (slashParticle != null && (c.gameObject.tag == "Enemy" || c.gameObject.tag == "Player"))
        {
            Instantiate(slashParticle, c.contacts[0].point, Quaternion.identity);
        }
    }
}
