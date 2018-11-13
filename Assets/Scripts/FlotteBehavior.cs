using UnityEngine;

public class FlotteBehavior : MonoBehaviour {


    private static readonly FlotteBehavior instance = new FlotteBehavior();
    public string flotteDescription;

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static FlotteBehavior()
    {
    }

    private FlotteBehavior()
    {
        flotteDescription = "Flotte - la masse volumique\nde l'objet est inférieur à\ncelle de l'eau. Sa densité\nest inférieure à 1.";
        waterLevel = FindObjectOfType<TestJar>().gameObject.transform.position.y;
    }

    public static FlotteBehavior Instance
    {
        get
        {
            return instance;
        }
    }
    
    float floatHeight = 0.09f;
    float bounceDamp = 3f;
    Vector3 buoyancyCenterOffset;
    float waterLevel;
    float forceFactor;
    Vector3 actionPoint;
    Vector3 upLift;

    // Update is called once per frame
    public void Flotte(GameObject go)
    {
        actionPoint = go.transform.position + go.transform.TransformDirection(buoyancyCenterOffset);
        forceFactor = 1.0f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0.0f)
        {
            upLift = -Physics.gravity * (forceFactor - go.GetComponent<Rigidbody>().velocity.y * bounceDamp);
            go.GetComponent<Rigidbody>().AddForceAtPosition(upLift, actionPoint);

        }
    }
}
