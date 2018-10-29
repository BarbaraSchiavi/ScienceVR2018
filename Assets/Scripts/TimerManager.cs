using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {

    TextMesh textMesh;
    public float timer;
    public string timerFormatted;
    public bool startQuarantaine = false;
    bool startCountdown = false;
    
    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void StartCountdown()
    {
        startCountdown = true;
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }


    void Update()
    {
        if (startCountdown)
        {

            timer += Time.deltaTime;
            
            System.TimeSpan t = System.TimeSpan.FromSeconds(300.0f - timer);
            timerFormatted = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            textMesh.text = timerFormatted;

            if (!startQuarantaine && t.Seconds == 0)
            {
                startQuarantaine = true;
                FindObjectOfType<PartyTimManager>().StartParty();
            }

            if (t.Minutes <= 0 && t.Seconds == 0)
            {
                Quit();
            }
        }

    }
}
