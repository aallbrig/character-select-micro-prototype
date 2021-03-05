using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class CharacterSelectedEventListenerTests
    {
        [Test]
        public void ScriptEventListenerHandleFunction_UnityEventCanBeInvokedDirectly()
        {
            // Arrange
            var called = false;
            var unityEvent = new CharacterSelectedEventUnityEvent();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();
            unityEvent.AddListener(character => called = true);
            eventListener.unityEvent = unityEvent;

            // Act
            eventListener.OnEventBroadcast(ScriptableObject.CreateInstance<SelectableCharacter>());

            // Assert
            Assert.True(called);
        }

        [Test]
        public void ScriptEventListenerHandleFunction_CalledWithExpectedArgument()
        {
            // Arrange
            SelectableCharacter argument = null;
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();
            var unityEvent = new CharacterSelectedEventUnityEvent();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();

            unityEvent.AddListener(character => argument = character);
            eventListener.unityEvent = unityEvent;

            // Act
            eventListener.OnEventBroadcast(payload);

            // Assert
            Assert.AreSame(payload, argument);
        }

        [Test]
        public void OnCharacterSelectedEventBroadcast_GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            // Arrange
            var eventListenerCalled = false;
            var unityEvent = new CharacterSelectedEventUnityEvent();
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();

            unityEvent.AddListener(character => eventListenerCalled = true);
            eventListener.soEvent = evt;
            eventListener.unityEvent = unityEvent;
            evt.RegisterListener(eventListener);

            // Act
            evt.Broadcast(ScriptableObject.CreateInstance<SelectableCharacter>());

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void OnCharacterSelectedEventBroadcast_CalledWithExpectedArgument()
        {
            // Arrange
            SelectableCharacter argument = null;
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();
            var unityEvent = new CharacterSelectedEventUnityEvent();
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();

            unityEvent.AddListener(character => argument = character);
            eventListener.soEvent = evt;
            eventListener.unityEvent = unityEvent;
            evt.RegisterListener(eventListener);

            // Act
            evt.Broadcast(payload);

            // Assert
            Assert.AreSame(payload, argument);
        }
    }
}