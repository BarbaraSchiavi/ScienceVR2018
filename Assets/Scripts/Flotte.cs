using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotte : MonoBehaviour {

    public float floatHeight = 0.09f;
    public float bounceDamp = 3f;
    public Vector3 buoyancyCenterOffset;

    public float waterLevel;
    float forceFactor;
    Vector3 actionPoint;
    Vector3 upLift;

    void Start()
    {
        waterLevel = FindObjectOfType<CollisionTestFloCoul>().gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
        forceFactor = 1.0f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0.0f)
        {
            upLift = -Physics.gravity * (forceFactor - this.GetComponent<Rigidbody>().velocity.y * bounceDamp);
            this.GetComponent<Rigidbody>().AddForceAtPosition(upLift, actionPoint);

        }
    }
}
