using UnityEngine;

public class OIsolantCoule : Objet
{
    IsolantBehavior isolantBehavior;
    CouleBehavior couleBehavior;

    private string _descriptionIsolant = "";
    private string _descriptionCoule = "";

    //return the description if is Conducteur or Isolant
    public override string GetDescriptionOnCircuit()
    {
        return _descriptionIsolant;
    }
    //return the description if Flotte or Coule 
    public override string GetDescriptionUnderwater()
    {
        return _descriptionCoule;
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        isolantBehavior = IsolantBehavior.Instance;
        couleBehavior = CouleBehavior.Instance;

        _descriptionIsolant = name + " : " + isolantBehavior.isolantDescription;
        _descriptionCoule = name + " : " + couleBehavior.couleDescription;
    }
	
}
