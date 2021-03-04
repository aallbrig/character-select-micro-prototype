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
            var eventListenerCalled = false;
            var unityEvent = new CharacterSelectedEventUnityEvent();
            unityEvent.AddListener(character => eventListenerCalled = true);
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();
            eventListener.unityEvent = unityEvent;
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

            // Act
            eventListener.OnEventBroadcast(payload);

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void ScriptEventListenerHandleFunction_CalledWithExpectedArgument()
        {
            // Arrange
            SelectableCharacter argument = null;
            var unityEvent = new CharacterSelectedEventUnityEvent();
            unityEvent.AddListener(character => argument = character);
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();
            eventListener.unityEvent = unityEvent;
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

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
            unityEvent.AddListener(character => eventListenerCalled = true);
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();
            eventListener.soEvent = evt;
            eventListener.unityEvent = unityEvent;
            eventListener.OnEnable();
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

            // Act
            evt.Broadcast(payload);

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void OnCharacterSelectedEventBroadcast_CalledWithExpectedArgument()
        {
            // Arrange
            SelectableCharacter argument = null;
            var unityEvent = new CharacterSelectedEventUnityEvent();
            unityEvent.AddListener(character => argument = character);
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = new GameObject().AddComponent<CharacterSelectedEventListener>();
            eventListener.soEvent = evt;
            eventListener.unityEvent = unityEvent;
            eventListener.OnEnable();
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

            // Act
            evt.Broadcast(payload);

            // Assert
            Assert.AreSame(payload, argument);
        }
    }
}