using System;
using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    [Serializable] public class CharacterSelectedEventUnityEvent : UnityEvent<SelectableCharacter> {}

    public class CharacterSelectedEventListener : MonoBehaviour, ICharacterSelectedEventListener
    {
        public CharacterSelectedEvent soEvent;
        public CharacterSelectedEventUnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast(SelectableCharacter character) => unityEvent.Invoke(character);
    }
}