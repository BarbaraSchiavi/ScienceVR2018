using UnityEngine;

public class OIsolantFlotte : Objet
{

    IsolantBehavior isolantBehavior;
    FlotteBehavior flotteBehavior;

    private string _descriptionIsolant = "";
    private string _descriptionFlotte = "";

    //return the description if is Conducteur or Isolant
    public override string GetDescriptionOnCircuit()
    {
        return _descriptionIsolant;
    }
    //return the description if Flotte or Coule 
    public override string GetDescriptionUnderwater()
    {
        return _descriptionFlotte;
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        isolantBehavior = IsolantBehavior.Instance;
        flotteBehavior = FlotteBehavior.Instance;
        _descriptionIsolant = name + " : " + isolantBehavior.isolantDescription;
        _descriptionFlotte = name + " : " + flotteBehavior.flotteDescription;
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if (state == State.UNDERWATER)
        {
            flotteBehavior.Flotte(this.gameObject);
        }
	}
}
