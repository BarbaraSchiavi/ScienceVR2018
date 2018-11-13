
public class ConducteurBehavior {

    private static readonly ConducteurBehavior instance = new ConducteurBehavior();
    public string conducteurDescription;

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static ConducteurBehavior()
    {
    }

    private ConducteurBehavior()
    {
        conducteurDescription = "Conducteur - l'eau, le métal,\nle graphite. ";
    }

    public static ConducteurBehavior Instance
    {
        get
        {
            return instance;
        }
    }
}
