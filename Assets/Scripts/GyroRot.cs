using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRot : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up * Time.deltaTime * 200.0f);
	}
}
