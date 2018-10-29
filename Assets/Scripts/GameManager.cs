using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    AudioClip StartSound;
    [SerializeField]
    AudioClip Ambient;

    GameObject CanvaObject;

    [SerializeField]
    GameObject CameraHeadVR;

    // Use this for initialization
    void Start () {
        this.GetComponent<AudioSource>().PlayOneShot(StartSound);
        //CameraHeadVR.GetComponent<Camera>().cullingMask = 6;
        PlayAmbientSound();
       // CanvaObject.SetActive(false);
        if (FindObjectOfType<TimerManager>())
            FindObjectOfType<TimerManager>().StartCountdown();
    }

    public void StartGame()
    {
        CameraHeadVR.GetComponent<Camera>().cullingMask = 1;
        PlayAmbientSound();
        CanvaObject.SetActive(false);
        if (FindObjectOfType<TimerManager>())
            FindObjectOfType<TimerManager>().StartCountdown();
    }

    public void PlayAmbientSound()
    {
        this.GetComponent<AudioSource>().PlayOneShot(Ambient);
    }

    public void StopAmbientSound()
    {
        this.GetComponent<AudioSource>().Stop();
    }

}
