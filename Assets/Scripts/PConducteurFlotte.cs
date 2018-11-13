﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PConducteurFlotte : Panier {

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
            if (c.gameObject.GetComponent<OConducteurFlotte>())
            {
                if (c.gameObject.GetComponent<OConducteurFlotte>().GetIsNothingObject())
                {
                    //in the right basket
                    InRightBasket();
                    //resize box collider
                    c.gameObject.GetComponent<OConducteurFlotte>().ResizeObjectCollider(0.1f);
                    //set object is in basket
                    c.gameObject.GetComponent<OConducteurFlotte>().SetInBasketObject();
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