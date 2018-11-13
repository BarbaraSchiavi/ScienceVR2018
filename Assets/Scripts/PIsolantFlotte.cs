using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIsolantFlotte : Panier {

    [SerializeField]
    private AudioClip audioClipWin;
    [SerializeField]
    private AudioClip audioClipLose;

    protected override void Start()
    {
        base.Start();
        _audioClipWin = audioClipWin;
        _audioClipLose = audioClipLose;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Objet")
        {
            if (c.gameObject.GetComponent<OIsolantFlotte>())
            {
                if (c.gameObject.GetComponent<OIsolantFlotte>().GetIsNothingObject())
                {
                    //in the right basket
                    InRightBasket();
                    //resize box collider
                    c.gameObject.GetComponent<OIsolantFlotte>().ResizeObjectCollider(0.1f);
                    //set object is in basket
                    c.gameObject.GetComponent<OIsolantFlotte>().SetInBasketObject();
                    //Debug.Log("OnTriggerEnter(Collider c) : " + c.gameObject.name);
                }
            }
            else
            {
                WrongBasket();
            }
        }
    }
}
