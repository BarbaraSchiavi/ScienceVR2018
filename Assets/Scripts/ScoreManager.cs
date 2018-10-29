using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    TextMesh textMesh;
    [SerializeField]
    AudioClip Lose;
    [SerializeField]
    AudioClip Win;
    
	// Use this for initialization
	void Start () {
       
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "0";
    }

    public void PlayWin()
    {
        this.GetComponent<AudioSource>().PlayOneShot(Win);
    }

    public void PlayLose()
    {
        this.GetComponent<AudioSource>().PlayOneShot(Lose);
    }

    public void SetScore(int n)
    {
        textMesh.text = n.ToString();
    }

}
