using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damage : MonoBehaviour {
    public GameObject effect = null;
    public GameObject[] effects = null;
    public List<string> include = new List<string>();
    public bool friendlyFire = false;
    public string friendTag = string.Empty;
    void OnCollisionEnter(Collision c)
    {   
        print(c.transform.tag + "=" + friendTag);
        if (c.transform.tag == friendTag) return;
        if (c.transform.tag == "Enemy")
        {
            c.gameObject.GetComponent<PlayerObject>().ApplyDamage(5);
            Destroy(this.gameObject);
            if (effect != null) GameObject.Instantiate(effect, this.transform.position, Quaternion.identity);
        }
        else if (c.transform.tag == CFG.TAG_PLAYER)
        {
            if (effect != null) GameObject.Instantiate(effect, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (this.GetComponent<Rigidbody>() != null)
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider c)
    {
        print(c.transform.tag + "=" + friendTag);
       
        if (c.transform.tag == friendTag) return;

        if (c.transform.tag == "Enemy")
        {
            c.gameObject.GetComponent<PlayerObject>().ApplyDamage(5);
        }
        if (this.GetComponent<Rigidbody>() != null)this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        DoEffects();
        Destroy(this.gameObject);
    }
    void DoEffects()
    {
        if (effect != null) GameObject.Instantiate(effect, this.transform.position, Quaternion.identity);
        foreach (GameObject g in effects)
        {
            GameObject.Instantiate(g, this.transform.position, Quaternion.identity);
        }
    }
}
