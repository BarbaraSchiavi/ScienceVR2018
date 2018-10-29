using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    //bool isGrabbed;
    //bool isUnderWater;

    //AudioSource audiosource;
    //[SerializeField]
    //AudioClip clip;

    [TextArea]
    public string descriptionCondIso;

    [TextArea]
    public string descriptionFloCoul;
    
    [SerializeField]
    public bool conducteur;
    [SerializeField]
    public bool isolant;

    [SerializeField]
    public bool flotte;
    [SerializeField]
    public bool coule;

    private Vector3 couleObjetPos;
    private bool couleObjet = false;

    //public void SetIsGrabbed(bool b) { isGrabbed = b; }

    //public void SetIsUnderWater(bool b) { isUnderWater = b; }

    public string GetDescriptionCondIso() { return descriptionCondIso; }

    public string GetDescriptionFloCoul() { return descriptionFloCoul; }


    public void SetGravity() { this.GetComponent<Rigidbody>().useGravity = true; }

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody>().useGravity = true;
        if(this.GetComponent<Flotte>() != null)
            this.GetComponent<Flotte>().enabled = false;

        //this.gameObject.AddComponent<AudioSource>();
        //audiosource = this.GetComponent<AudioSource>();
    }
    

    public void SnapToPlateau(Vector3 plateau)
    {
        //this.GetComponent<Rigidbody>().useGravity = false;
        //this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        this.transform.position = new Vector3(plateau.x, plateau.y + 0.15f, plateau.z);
    }

    public void GravityBack()
    {
        if (!this.GetComponent<Rigidbody>().useGravity)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
 
    }

    public void ActiveDesactiveBuoyancy(bool b)
    {
        if (this.GetComponent<Flotte>() != null)
        {
            if(b)
            {
                this.GetComponent<Flotte>().enabled = true;
            }
            else
            {
                this.GetComponent<Flotte>().enabled = false;
            }
        }

    }

    public void Eject()
    {
        //Debug.Log("Try Eject");
        this.GetComponent<Rigidbody>().AddForce(new Vector3(3, 3, 3), ForceMode.Impulse);
    }

    public void SnapToWater(Vector3 newPos)
    {
       // this.GetComponent<Rigidbody>().useGravity = false;
        //this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        if (flotte)
        {
            this.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
        }
        else
        {
            couleObjetPos = newPos;
            couleObjet = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (coule && couleObjet)
        {
            //this.transform.Translate(couleObjetPos, Space.World);
            this.transform.position = Vector3.Lerp(this.transform.position, couleObjetPos, Time.deltaTime * 0.9f);
            if (this.transform.position.y <= (couleObjetPos.y + 0.5f))
            {
                couleObjet = false;
            }
        }
	}
}
