using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class SceneEventListenerTests
    {
        [Test]
        public void SceneEventListenerScriptExposesFunctionForWhenInUnityEditor()
        {
            // Setup
            var called = false;
            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();
            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var unityEvent = new UnityEvent();

            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;

            unityEvent.AddListener(() => called = true);

            // Action
            sceneEventListener.OnEnable();
            sceneEventListener.OnEventBroadcast();
            sceneEventListener.OnDisable();

            // Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void SceneEventListenerRespondsToSceneEventBroadcast()
        {
            // Arrange
            var called = false;
            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();
            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var unityEvent = new UnityEvent();

            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;

            // Assert
            unityEvent.AddListener(() => called = true);

            // Action
            sceneEventListener.OnEnable();
            sceneEvent.Broadcast();

            // Assert
            Assert.IsTrue(called);
        }
    }
}