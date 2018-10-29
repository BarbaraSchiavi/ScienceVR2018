using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionIsoCond : MonoBehaviour {

    TextMesh textMesh;

    // Use this for initialization
    void Start()
    {

        textMesh = GetComponent<TextMesh>();
        textMesh.text = "Un conducteur est une matière \nà travers laquelle le courant \nélectrique peut circuler. \n"
            + "Un isolant est l’opposé d’un conducteur.";
    }

    public void SetDescription(string s)
    {
        textMesh.text = s;
    }
}
