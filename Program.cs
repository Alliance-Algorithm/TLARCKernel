using System.Reflection;
using AllianceDM;
using AllianceDM.Init;
using Rcl.Logging;

static class DecisionMaker
{
    delegate void BasicFunc();

    static Dictionary<uint, Component> Components = [];
    static Dictionary<string, GameObject> GameObjects = [];
    static void Main(string[] args)
    {
        Ros2Def.context = new Rcl.RclContext(args);
        Ros2Def.node = Ros2Def.context.CreateNode("decision_maker");

        InitGameObject.Init(ref GameObjects);

        InitComponent.Init(ref Components);

        SearchForAwakeFunc();

        Ros2Def.node.Logger.LogInformation("Compelete");
    }
    static void SearchForAwakeFunc()
    {
        foreach (var i in Components)
            i.Value.Awake();
    }
}