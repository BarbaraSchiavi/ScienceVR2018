using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTestFloCoul : MonoBehaviour {

    public GameObject floPos;
    public GameObject coulPos;

    public GameObject vfx;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "object")
        {
            //c.gameObject.GetComponent<ObjectManager>().SetIsUnderWater(true);
            Instantiate(vfx, floPos.transform.position, Quaternion.identity);
            this.GetComponent<AudioSource>().Play();
            c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);

            if (c.gameObject.GetComponent<ObjectManager>().coule)
            {
            //    c.gameObject.GetComponent<ObjectManager>().SnapToWater(coulPos.transform.position);
            }
            else
            { 

            //    c.gameObject.GetComponent<ObjectManager>().SnapToWater(floPos.transform.position);
                c.gameObject.GetComponent<ObjectManager>().ActiveDesactiveBuoyancy(true);
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "object")
        {
            //afficher Description
            FindObjectOfType<DescriptionFloCoul>().SetDescription(c.gameObject.GetComponent<ObjectManager>().GetDescriptionFloCoul());
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "object")
        {
            //c.gameObject.GetComponent<ObjectManager>().SetIsUnderWater(false);

            c.gameObject.GetComponent<ObjectManager>().ActiveDesactiveBuoyancy(false);
            c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.2f, 0.2f);


        }
    }
}
