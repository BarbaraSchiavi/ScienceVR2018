//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour {

    protected enum State
    {
        NOTHING,
        GRABBED,
        UNDERWATER,
        ONCIRCUIT,
        INBASKET,
        INPARTYTIME
    }

    protected Rigidbody rbody;
    protected BoxCollider bcollider;
    protected State state;

    virtual protected void Start()
    {
        //init state to nothing as spawned
        state = State.NOTHING;
        //add rigidbody and enable gravity
        rbody = this.gameObject.AddComponent<Rigidbody>();
        rbody.useGravity = true;
        //add boxcollider and resize
        bcollider = this.gameObject.AddComponent<BoxCollider>();
        bcollider.size = new Vector3(0.2f, 0.2f, 0.2f);
       
    }

    //return the description if is Conducteur or Isolant
    public virtual string GetDescriptionOnCircuit() { return "1"; }
    //return the description if Flotte or Coule
    public virtual string GetDescriptionUnderwater() { return "1"; }

    //setter
    public void SetNothingObject() { state = State.NOTHING; }
    public void SetGrabbedObject() { state = State.GRABBED; }
    public void SetUnderwaterObject() { state = State.UNDERWATER; }
    public void SetOnCircuitObject() { state = State.ONCIRCUIT; }
    public void SetInBasketObject() { state = State.INBASKET; }
    public void SetPartyTimeObject() { state = State.INPARTYTIME; }

    //getter
    public bool GetIsNothingObject() { return (state == State.NOTHING ? true : false); }
    public bool GetIsGrabbedObject() { return (state == State.GRABBED ? true : false); }
    public bool GetIsUnderwaterObject() { return (state == State.UNDERWATER ? true : false); }
    public bool GetIsOnCircuitObject() { return (state == State.ONCIRCUIT ? true : false); }
    public bool GetIsInBasketObject() { return (state == State.INBASKET ? true : false); }
    public bool GetIsInPartyTimeObject() { return (state == State.INPARTYTIME ? true : false); }

    public void ResizeObjectCollider(float size) {
        bcollider.size = new Vector3(size, size, size);
    }

    protected virtual void Update()
    {
    }
}


