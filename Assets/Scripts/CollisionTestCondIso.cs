using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTestCondIso : MonoBehaviour {

    public SwitchManager sm;


    void OnTriggerStay(Collider c)
    {

        if (c.gameObject.tag == "object")
        {
            //Debug.Log("Un Seul Objet");
            sm.SetObjectOnTest(true);

           // c.gameObject.GetComponent<ObjectManager>().SnapToPlateau(this.transform.position);

            if (c.gameObject.GetComponent<ObjectManager>().conducteur)
            {
                
                sm.SetObjectOnTestIsConductor(true);
            }
            else
            {
                sm.SetObjectOnTestIsConductor(false);
            }

            //afficher Description
            FindObjectOfType<DescriptionIsoCond>().SetDescription(c.gameObject.GetComponent<ObjectManager>().GetDescriptionCondIso());
        }
    }
    

            void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "object")
        {
            //Debug.Log("OnTriggerExit");
            sm.SetObjectOnTest(false);
            sm.SetObjectOnTestIsConductor(false);
            
        }
    }
    
}
