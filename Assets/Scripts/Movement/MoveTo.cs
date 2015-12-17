using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    public float  targetY;
    public float time = 3;
	void Start () {
	
	}
	
	void Update () {
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition,
                                    new Vector3(this.transform.localPosition.x , targetY, this.transform.localPosition.z),
                                    time * Time.fixedDeltaTime);
	}
}
