using UnityEngine;

public class OConducteurFlotte : Objet
{
    ConducteurBehavior conducteurBehavior;
    FlotteBehavior flotteBehavior;

    private string _descriptionConducteur = "";
    private string _descriptionFlotte = "";

    //return the description if is Conducteur or Isolant
    public override string GetDescriptionOnCircuit()
    {
        return _descriptionConducteur;
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
        conducteurBehavior = ConducteurBehavior.Instance;
        flotteBehavior = FlotteBehavior.Instance;
        _descriptionConducteur = name + " : " + conducteurBehavior.conducteurDescription;
        _descriptionFlotte = name + " : " + flotteBehavior.flotteDescription;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (state == State.UNDERWATER)
        {
            flotteBehavior.Flotte(this.gameObject);
        }
    }
}
