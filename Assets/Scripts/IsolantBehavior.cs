
public class IsolantBehavior {

    private static readonly IsolantBehavior instance = new IsolantBehavior();
    public string isolantDescription;

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static IsolantBehavior()
    {
    }

    private IsolantBehavior()
    {
        isolantDescription = "Isolant - comme le verre, l'air,\nle bois, le papier, le tissu,\nles matières plastiques";
    }

    public static IsolantBehavior Instance
    {
        get
        {
            return instance;
        }
    }
}
