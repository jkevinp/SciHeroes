using UnityEngine;
using System.Collections;

public class UIDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.Find("Text").transform.localScale /= 2;
        this.transform.Find("RawImage").transform.localScale /= 2;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<CanvasGroup>().alpha -= Time.fixedDeltaTime / 2 ;
        if (this.GetComponent<CanvasGroup>().alpha <= 0) Destroy(this.gameObject);
        this.transform.Find("Text").transform.localScale = Vector3.MoveTowards(this.transform.Find("Text").transform.localScale, Vector3.one, Time.fixedDeltaTime);
        this.transform.Find("RawImage").transform.localScale = Vector3.MoveTowards(this.transform.Find("RawImage").transform.localScale, Vector3.one, Time.fixedDeltaTime);
        this.transform.Find("Text").transform.localPosition += Vector3.up * 10 ;
        this.transform.Find("RawImage").transform.localPosition +=  Vector3.up *10;
                           
	}
}
