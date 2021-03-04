using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New character selected event", menuName = "CSS/CharacterSelectedEvent", order = 0)]
    public class CharacterSelectedEvent : ScriptableObject
    {
        private readonly List<ICharacterSelectedEventListener> _listeners = new List<ICharacterSelectedEventListener>();

        public void Broadcast(SelectableCharacter.SelectableCharacter character)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(character);
        }

        public void RegisterListener(ICharacterSelectedEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(ICharacterSelectedEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}