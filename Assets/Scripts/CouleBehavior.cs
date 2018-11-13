

public class CouleBehavior {

    private static readonly CouleBehavior instance = new CouleBehavior();
    public string couleDescription;

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static CouleBehavior()
    {
    }

    private CouleBehavior()
    {
        couleDescription = "Coule - la densité est\nsuperieure à 1. La masse\nvolumique de l'objet est\nplus grande que celle de l'eau";
    }

    public static CouleBehavior Instance
    {
        get
        {
            return instance;
        }
    }
}
