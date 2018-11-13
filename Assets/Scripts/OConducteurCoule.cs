using UnityEngine;

public class OConducteurCoule : Objet
{
    ConducteurBehavior conducteurBehavior;
    CouleBehavior couleBehavior;

    private string _descriptionConducteur = "";
    private string _descriptionCoule = "";

    //return the description if is Conducteur or Isolant
    public override string GetDescriptionOnCircuit()
    {
        return _descriptionConducteur;
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

        conducteurBehavior = ConducteurBehavior.Instance;
        couleBehavior = CouleBehavior.Instance;
        _descriptionConducteur = name + " : " + conducteurBehavior.conducteurDescription;
        _descriptionCoule = name + " : " + couleBehavior.couleDescription;
    }

}
