using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutzEngine.SceneManagement;
using UnityEngine;

namespace TutzEngine
{
    public abstract class BaseScene : Singleton<BaseScene>, IScene
    {
        protected ISceneData SceneData => SceneManager.CurrentSceneData;
        protected ISceneManager SceneManager => GameStatics.GetStaticObject<ISceneManager>();
        protected override bool DestroyOnLoad => true;
        private Dictionary<Type, ISceneComponent> _sceneComponents = new();

        protected void Start()
        {
            _ = Init();
        }

        protected virtual Awaitable Init()
        {
            return Awaitable.EndOfFrameAsync();
        }

        public void LoadScene(SceneData sceneData)
        {
            SceneManager.LoadScene(sceneData);
        }

        protected void SubscribeSceneComponent<T>(T component) where T : ISceneComponent
        {
            _sceneComponents.Add(typeof(T), component);
        }

        public T GetSceneComponent<T>() where T : ISceneComponent
        {
            if (!_sceneComponents.ContainsKey(typeof(T)))
                throw new NotImplementedException($"{nameof(T)} não cadastrado");

            return (T)_sceneComponents[typeof(T)];
        }

        protected T GetStaticObject<T>() where T : IStaticObject => GameStatics.GetStaticObject<T>();
    }

    public abstract class BaseScene<T> : BaseScene where T : SceneData
    {
        protected new T SceneData => (T)base.SceneData;
    }
}