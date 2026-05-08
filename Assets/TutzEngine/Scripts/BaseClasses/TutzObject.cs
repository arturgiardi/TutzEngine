namespace TutzEngine
{
    public class TutzObject
    {
        protected static IScene Scene => BaseScene.Instance;
        protected static T GetStaticObject<T>() where T : IStaticObject => 
            GameStatics.GetStaticObject<T>();
        protected static T GetSceneComponent<T>() where T : ISceneComponent => 
            Scene.GetSceneComponent<T>();
    }
}

