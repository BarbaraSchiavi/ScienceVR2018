using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanierManager : MonoBehaviour {

    int nbPoint = 0;
    int nbPointPerdu = 5;
    static int scoreFinal = 0;

    private static List<GameObject> DeleteAfterLoosing;

    // Use this for initialization
    void Start () {

        DeleteAfterLoosing = new List<GameObject>();

        if (this.gameObject.tag == "CondFlo")
        {
            nbPoint = 4;
        }
        if (this.gameObject.tag == "CondCoul")
        {
            nbPoint = 1;
        }
        if (this.gameObject.tag == "IsoFlo")
        {
            nbPoint = 2;
        }
        if (this.gameObject.tag == "IsoCoul")
        {
            nbPoint = 3;
        }

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "object")
        {
            //CondFlo
            if (this.gameObject.tag == "CondFlo")
            {
                Debug.Log("CondFlo");
                if (c.gameObject.GetComponent<ObjectManager>().conducteur && c.gameObject.GetComponent<ObjectManager>().flotte)
                {
                    scoreFinal += nbPoint;
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayWin();
                    c.gameObject.GetComponent<ObjectManager>().enabled = false;
                    //c.gameObject.GetComponent<BoxCollider>().enabled = false;
                    c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
                    DeleteAfterLoosing.Add(c.gameObject);
                    c.gameObject.tag = "Untagged";

                }
                else
                {
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayLose();
                    //perdu
                    Destroy(c.gameObject);
                    if (DeleteAfterLoosing.Count > 0)
                    {
                        foreach (GameObject go in DeleteAfterLoosing)
                        {
                            Destroy(go.gameObject);
                        }
                    }
                    //enleve des points
                    scoreFinal -= nbPointPerdu;
                    if (scoreFinal <= 0)
                    {
                        scoreFinal = 0;
                    }
                }
            }
            //CondCoul
            if (this.gameObject.tag == "CondCoul")
            {
                Debug.Log("CondCoul");
                if (c.gameObject.GetComponent<ObjectManager>().conducteur && c.gameObject.GetComponent<ObjectManager>().coule)
                {
                    //Debug.Log("GAGNER");
                    scoreFinal += nbPoint;
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayWin();
                    c.gameObject.GetComponent<ObjectManager>().enabled = false;
                    //c.gameObject.GetComponent<BoxCollider>().enabled = false;
                    c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
                    DeleteAfterLoosing.Add(c.gameObject);
                    c.gameObject.tag = "Untagged";


                }
                else
                {
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayLose();
                    //perdu
                    Destroy(c.gameObject);
                    if (DeleteAfterLoosing.Count > 0)
                    {
                        foreach (GameObject go in DeleteAfterLoosing)
                        {
                            Destroy(go.gameObject);
                        }
                    }
                    //enleve des points
                    scoreFinal -= nbPointPerdu;
                    if (scoreFinal <= 0)
                    {
                        scoreFinal = 0;
                    }
                }
            }


            //IsoFlo
            if (this.gameObject.tag == "IsoFlo")
            {
                Debug.Log("IsoFlo");
                if (c.gameObject.GetComponent<ObjectManager>().isolant && c.gameObject.GetComponent<ObjectManager>().flotte)
                {
                    scoreFinal += nbPoint;
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayWin();
                    c.gameObject.GetComponent<ObjectManager>().enabled = false;
                    //c.gameObject.GetComponent<BoxCollider>().enabled = false;
                    c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
                    DeleteAfterLoosing.Add(c.gameObject);
                    c.gameObject.tag = "Untagged";

                }
                else
                {
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayLose();
                    //perdu
                    Destroy(c.gameObject);
                    if (DeleteAfterLoosing.Count > 0)
                    {
                        foreach (GameObject go in DeleteAfterLoosing)
                        {
                            Destroy(go.gameObject);
                        }
                    }
                    //enleve des points
                    scoreFinal -= nbPointPerdu;
                    if (scoreFinal <= 0)
                    {
                        scoreFinal = 0;
                    }
                }
            }
            //IsoCoul
            if (this.gameObject.tag == "IsoCoul")
            {
                Debug.Log("IsoCoul");
                if (c.gameObject.GetComponent<ObjectManager>().isolant && c.gameObject.GetComponent<ObjectManager>().coule)
                {
                    scoreFinal += nbPoint;
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayWin();
                    c.gameObject.GetComponent<ObjectManager>().enabled = false;
                    //c.gameObject.GetComponent<BoxCollider>().enabled = false;
                    c.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
                    DeleteAfterLoosing.Add(c.gameObject);
                    c.gameObject.tag = "Untagged";

                }
                else
                {
                    if (FindObjectOfType<ScoreManager>())
                        FindObjectOfType<ScoreManager>().PlayLose();
                    //perdu
                    Destroy(c.gameObject);
                    if (DeleteAfterLoosing.Count > 0)
                    {
                        foreach (GameObject go in DeleteAfterLoosing)
                        {
                            Destroy(go.gameObject);
                        }
                    }

                    //enleve des points
                    scoreFinal -= nbPointPerdu;
                    if (scoreFinal <= 0)
                    {
                        scoreFinal = 0;
                    }
                }
            }
            
            if(FindObjectOfType<ScoreManager>())
                FindObjectOfType<ScoreManager>().SetScore(scoreFinal);
            Debug.Log(scoreFinal.ToString());
        }
    }
}
