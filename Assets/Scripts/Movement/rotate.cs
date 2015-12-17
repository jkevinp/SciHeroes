using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
    public float speed = 30;
	void Update () {
        this.transform.Rotate(Vector3.up * Time.fixedDeltaTime * speed);
	}
}
