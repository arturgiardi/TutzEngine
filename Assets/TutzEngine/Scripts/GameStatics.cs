namespace TutzEngine
{
    public static class GameStatics
    {
        private static IStaticObjectGetter _getter;

        public static void SetStaticObjectGetter(IStaticObjectGetter getter)
            => _getter = getter;

        public static T GetStaticObject<T>() where T : IStaticObject => _getter.GetStaticObject<T>();
    }
}

