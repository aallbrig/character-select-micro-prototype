using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class CharacterSelectedEventTests
    {
        [Test]
        public void CharacterSelectedEvent_SO_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<CharacterSelectedEvent>());

        [Test]
        public void CharacterSelectedEvent_Broadcast_Received()
        {
            var evt = ScriptableObject.CreateInstance<CharacterSelectedEvent>();
            var eventListener = Substitute.For<ICharacterSelectedEventListener>();
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

            evt.RegisterListener(eventListener);
            evt.Broadcast(payload);

            eventListener.Received().OnEventBroadcast(payload);
        }
    }
}