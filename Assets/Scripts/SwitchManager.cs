using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    public GameObject switchLight;

    public GameObject switcherOPEN;
    public GameObject switcherCLOSE;

    bool ObjectOnTest = false;
    public void SetObjectOnTest(bool b) { ObjectOnTest = b; }

    bool ObjectOnTestIsConductor = false;
    public void SetObjectOnTestIsConductor(bool b) { ObjectOnTestIsConductor = b; }
    

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "controller")
        {
            this.GetComponent<AudioSource>().Play();
            Debug.Log("OnTriggerEnter");
            SwitchButton(true);
            if (ObjectOnTest && ObjectOnTestIsConductor)
            {
                switchLight.GetComponent<Light>().intensity = 15.0f;
                switchLight.GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "controller")
        {
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("OnTriggerExit");
            SwitchButton(false);
            switchLight.GetComponent<Light>().intensity = 0.0f;
        }
    }
    

    void SwitchButton(bool b)
    {
        if (b)
        {
            switcherOPEN.SetActive(false);
            switcherCLOSE.SetActive(true);
        }
        else
        {
            switcherCLOSE.SetActive(false);
            switcherOPEN.SetActive(true);
        }


    }

}
