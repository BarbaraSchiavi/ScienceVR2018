using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NewGameManager : MonoBehaviour {
    
    enum GameState
    {
        INMENU,
        START,
        PAUSE,
        QUIT
    }

    enum PartyTime
    {
        ON,
        OFF
    }

    GameState gstate;
    PartyTime partytime;
    [SerializeField]
    TextMesh textMeshTimer;
    [SerializeField]
    TextMesh textMeshScore;
    float timer;
    string timerFormatted;
    bool startQuarantaine;
    int score;

    AudioSource _audioSource;
    [SerializeField]
    AudioClip _audioClipAmbient;
    [SerializeField]
    AudioClip _audioClipPartyTime;

    [SerializeField]
    GameObject PartyLight;
    float minWaitTime = 0f;
    float maxWaitTime = 0.1f;
    bool b;
    float partyTimer;
    private IEnumerator coroutine;
    [SerializeField]
    GameObject MainLight;
    [SerializeField]
    GameObject BoltAudio;
    [SerializeField]
    GameObject vfx;
    [SerializeField]
    Transform fxPos;

    void Start(){
        this.timer = 0.0f;
        this.partyTimer = 0.0f;
        this.score = 0;
        this.startQuarantaine = false;
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        textMeshScore.text = score.ToString();
        textMeshTimer.text = "05:00";
        gstate = GameState.START;
        partytime = PartyTime.OFF;
        _audioSource.PlayOneShot(_audioClipAmbient);
        coroutine = Flashing();
    }

    //manage score in the game
    public void AddScore()
    {
        //Debug.Log("AddScore()");
        score++;
        textMeshScore.text = score.ToString();
    }
    public void SubScore()
    {
        //Debug.Log("SubScore()");
        if (score > 0)
        {
            score--;
        }
        textMeshScore.text = score.ToString();
    }

    //stop application after 5min
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    
    //make Partytime happening each minute
    void StartParty()
    {
        //set property
        startQuarantaine = true;
        partytime = PartyTime.ON;
        //play audio alarme
        _audioSource.Stop();
        _audioSource.clip = _audioClipPartyTime;
        _audioSource.Play();
        //stop ambient light
        MainLight.SetActive(false);
        //start flashing lights
        StartCoroutine(coroutine);
        //vfx bolt lights
        Instantiate(vfx, new Vector3(fxPos.position.x, fxPos.position.y, fxPos.position.z), Quaternion.identity);
        //play sfx of bolt lights
        BoltAudio.GetComponent<AudioSource>().Play();
        //find objects "nothing" and put them on gravity
        if (GameObject.FindGameObjectsWithTag("Objet").Length != 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Objet"))
            {
                if (go.GetComponent<Objet>().GetIsNothingObject())
                {
                    go.GetComponent<Rigidbody>().useGravity = false;
                    go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0f, 3.0f), Random.Range(0f, 1.0f), Random.Range(0f, 3.0f)), ForceMode.Impulse);
                }
            }
        }
    }
    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            b = !b;
            PartyLight.SetActive(b);
        }
    }
    void StopParty()
    {
        MainLight.SetActive(true);
        StopCoroutine(coroutine);
        PartyLight.SetActive(false);
        BoltAudio.GetComponent<AudioSource>().Stop();
        //put gravity back to objects
        if (GameObject.FindGameObjectsWithTag("Objet").Length != 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Objet"))
            {
                    go.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        //reset property
        startQuarantaine = false;
        partytime = PartyTime.OFF;
        partyTimer = 0.0f;
        _audioSource.Stop();
        _audioSource.clip = _audioClipAmbient;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
        if (gstate == GameState.START)
        {
            timer += Time.deltaTime;

            System.TimeSpan t = System.TimeSpan.FromSeconds(300.0f - timer);
            timerFormatted = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            textMeshTimer.text = timerFormatted;

            if (!startQuarantaine && t.Seconds == 0)
            {
                StartParty();
            }

            if (partytime == PartyTime.ON)
            {
                partyTimer += Time.deltaTime;
                if (partyTimer > 10.0f)
                {
                    StopParty();
                }
            }

            if (t.Minutes <= 0 && t.Seconds == 0)
            {
                Quit();
            }
        }
    }
}
