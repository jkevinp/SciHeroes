using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
    public float time = 5;
    private float currentTime = 0;
    void Start () {
        Invoke("destroy", time);
        currentTime = time;
	}
    float alpha = 1;
    void FixedUpdate()
    {
        //3
        //5
        time -= Time.fixedDeltaTime;
        alpha = 1-( currentTime / time);
        if (this.GetComponent<Renderer>() != null)
        {
            Renderer rend = this.GetComponent<MeshRenderer>();
            rend.material.color = new Color(rend.material.color.r , rend.material.color.g, rend.material.color.b, alpha);
        }
    }
    void destroy()
    {
        Destroy(this.gameObject);
    }
	
}
