using UnityEngine;

public abstract class Panier : MonoBehaviour {

    protected AudioSource _audioSource;
    protected AudioClip _audioClipWin;
    protected AudioClip _audioClipLose;

    protected NewGameManager nGameManager;
    
    protected virtual void Start()
    {
        nGameManager = FindObjectOfType<NewGameManager>();
        _audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    protected void InRightBasket()
    {
        //play win sound
        _audioSource.PlayOneShot(_audioClipWin);
        //add score
        nGameManager.AddScore();
    }

    protected void WrongBasket()
    {
        //play lose sound
        _audioSource.PlayOneShot(_audioClipLose);
        //sub score
        nGameManager.SubScore();
    }

}
