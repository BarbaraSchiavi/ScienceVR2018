using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionFloCoul : MonoBehaviour {

    TextMesh textMesh;

    // Use this for initialization
    void Start()
    {

        textMesh = GetComponent<TextMesh>();
        textMesh.text = "La densité d'un objet détermine \ns'il flotte ou coule suivant \nla densité de l'eau.";
    }

    public void SetDescription(string s)
    {
        textMesh.text = s;
    }
}
