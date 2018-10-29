using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyTimManager : MonoBehaviour {

    bool startPartyTime = false;
    float timer = 0.0f;
    public GameObject testLight;
    public float minWaitTime;
    public float maxWaitTime;
    bool b;
    private IEnumerator coroutine;
    public GameObject MainLight;

    public GameObject BoltAudio;

    [SerializeField]
    private GameObject vfx;
    [SerializeField]
    private Transform fxPos;

    // Use this for initialization
    void Start () {
        coroutine = Flashing();
    }

    public void StartParty()
    {
        startPartyTime = true;
        MainLight.SetActive(false);
        StartCoroutine(coroutine);
        if (FindObjectOfType<GameManager>())
            FindObjectOfType<GameManager>().StopAmbientSound();
        this.GetComponent<AudioSource>().Play();

        Instantiate(vfx, new Vector3(fxPos.position.x + 0.5f, fxPos.position.y, fxPos.position.z + 0.5f), Quaternion.identity);
        Instantiate(vfx, new Vector3(fxPos.position.x + 0.5f, fxPos.position.y, fxPos.position.z - 0.5f), Quaternion.identity);
        Instantiate(vfx, new Vector3(fxPos.position.x - 0.5f, fxPos.position.y, fxPos.position.z + 0.5f), Quaternion.identity);
        Instantiate(vfx, new Vector3(fxPos.position.x - 0.5f, fxPos.position.y, fxPos.position.z - 0.5f), Quaternion.identity);
        BoltAudio.GetComponent<AudioSource>().Play();

        if (GameObject.FindGameObjectsWithTag("object").Length != 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
            {
                go.GetComponent<Rigidbody>().useGravity = false;
                go.GetComponent<Rigidbody>().AddForce(Vector3.one * Random.Range(1.0f, 3.0f), ForceMode.Impulse);
            }
        }
    }

    void StopParty()
    {
        this.GetComponent<AudioSource>().Stop();
        BoltAudio.GetComponent<AudioSource>().Stop();
        if (FindObjectOfType<GameManager>())
            FindObjectOfType<GameManager>().PlayAmbientSound();
        MainLight.SetActive(true);
        StopCoroutine(coroutine);
        testLight.SetActive(false);

        if (GameObject.FindGameObjectsWithTag("object").Length != 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
            {
                go.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        
    }


    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            b = !b;
            testLight.SetActive(b);
        }
    }

    // Update is called once per frame
    void Update () {

        if (startPartyTime)
        {
            //Debug.Log("IT'S PARTY TIME");
            timer += Time.deltaTime;
            if (timer > 10.0f)
            {
                StopParty();
                startPartyTime = false;
                FindObjectOfType<TimerManager>().startQuarantaine = false;
                timer = 0.0f;
            }
        }
	}
}
