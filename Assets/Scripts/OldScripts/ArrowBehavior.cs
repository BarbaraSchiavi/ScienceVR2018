using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    private float speed = 50f;

	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
