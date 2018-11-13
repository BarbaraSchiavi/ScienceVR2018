using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCircuit : MonoBehaviour {

    [SerializeField]
    TextMesh textMeshOnCircuitDescription;

    protected SwitchManager sManager;
    
    void Start()
    {
        sManager = FindObjectOfType<SwitchManager>();
    }
    
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Objet")
        {
            //show description conducteur/isolant
            textMeshOnCircuitDescription.text = c.gameObject.GetComponent<Objet>().GetDescriptionOnCircuit();

            //set objet on circuit
            c.gameObject.GetComponent<Objet>().SetOnCircuitObject();


            if (c.gameObject.GetComponent<OConducteurCoule>() || c.gameObject.GetComponent<OConducteurFlotte>())
            {
                // object on test conductor
                sManager.SetObjectOnTestIsConductor(true);
                //Debug.Log("sManager.SetObjectOnTestIsConductor(true);");
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Objet")
        {
            //no object on test neither conductor
            sManager.SetObjectOnTestIsConductor(false);

            //clear description
            textMeshOnCircuitDescription.text = "";

            //set objet back to nothing
            c.gameObject.GetComponent<Objet>().SetNothingObject();
        }

    }
}
