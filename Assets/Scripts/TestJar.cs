using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJar : MonoBehaviour {

    [SerializeField]
    TextMesh textMeshInJarDescription;
    [SerializeField]
    private GameObject flottePosition;
    [SerializeField]
    private GameObject vfx;
    [SerializeField]
    private AudioClip audioClipSplash;
    private AudioSource _audioSource;
    
    // Use this for initialization
    void Start () {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Objet" && c.gameObject.GetComponent<Objet>().GetIsNothingObject())
        {
            //set object underwater
            c.gameObject.GetComponent<Objet>().SetUnderwaterObject();
            //play splash vfx
            Instantiate(vfx, flottePosition.transform.position, Quaternion.identity);
            //play splash sound
            _audioSource.PlayOneShot(audioClipSplash);
            //resize objet
            c.gameObject.GetComponent<Objet>().ResizeObjectCollider(0.1f);
            //show description coule/flotte
            textMeshInJarDescription.text = c.gameObject.GetComponent<Objet>().GetDescriptionUnderwater();
        }
    }


    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Objet")
        {
            //resize objet
            c.gameObject.GetComponent<Objet>().ResizeObjectCollider(0.2f);
            //set objet back to nothing
            c.gameObject.GetComponent<Objet>().SetNothingObject();
            //clear descritpion
            textMeshInJarDescription.text = "";
        }
    }

}
