
using System.Collections.Generic;
using UnityEngine;

public class PConducteurCoule : Panier {

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
            if (c.gameObject.GetComponent<OConducteurCoule>())
            {
                if (c.gameObject.GetComponent<OConducteurCoule>().GetIsNothingObject())
                {
                    //in the right basket
                    InRightBasket();
                    //resize box collider
                    c.gameObject.GetComponent<OConducteurCoule>().ResizeObjectCollider(0.1f);
                    //set object is in basket
                    c.gameObject.GetComponent<OConducteurCoule>().SetInBasketObject();
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
