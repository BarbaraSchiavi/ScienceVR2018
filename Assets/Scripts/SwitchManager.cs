using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    [SerializeField]
    GameObject lightBulb;
    [SerializeField]
    GameObject switcherOPEN;
    [SerializeField]
    GameObject switcherCLOSE;


    bool ObjectOnTestIsConductor = false;
    public void SetObjectOnTestIsConductor(bool b) { ObjectOnTestIsConductor = b; }
    

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "controller")
        {
            //play sound
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("OnTriggerEnter");
            //switch button to visually actionning it
            SwitchButton(true);

            if (ObjectOnTestIsConductor)
            {
                //switch light on
                lightBulb.GetComponent<Light>().intensity = 10.0f;
                //play sound light on
                lightBulb.GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "controller")
        {
            //play sound
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("OnTriggerExit");
            //switch button to visually realising it
            SwitchButton(false);
            //switch light off
            lightBulb.GetComponent<Light>().intensity = 0.0f;
        }
    }
    
    //Enable/Disable gameobject of switcher
    void SwitchButton(bool b)
    {
        switcherOPEN.SetActive(!b);
        switcherCLOSE.SetActive(b);
    }
}
