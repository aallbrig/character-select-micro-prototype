﻿using Interfaces;
using MonoBehaviours.EventProducers;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.EventProducers
{
    public class BroadcastGameEventsTests
    {
        [Test]
        public void Script_Exists()
        {
            var script = new GameObject().AddComponent<BroadcastGameEvents>();
            Assert.NotNull(script);
        }

        [Test]
        public void Script_SupportsListOfGameEvents()
        {
            // Arrange
            var script = new GameObject().AddComponent<BroadcastGameEvents>();

            // Act
            script.gameEvents.Add(ScriptableObject.CreateInstance<GameEvent>());
            script.gameEvents.Add(ScriptableObject.CreateInstance<GameEvent>());
            script.gameEvents.Add(ScriptableObject.CreateInstance<GameEvent>());

            // Assert
            Assert.AreEqual(3, script.gameEvents.Count);
        }

        [Test]
        public void Script_ExposesFunctionToBroadcast_Single()
        {
            // Arrange
            var script = new GameObject().AddComponent<BroadcastGameEvents>();
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            script.gameEvents.Add(gameEvent);

            var gameEventListenerFake = Substitute.For<IGameEventListener>();
            gameEvent.RegisterListener(gameEventListenerFake);

            // Act
            script.Broadcast();

            // Assert
            gameEventListenerFake.Received().OnEventBroadcast();
        }

        [Test]
        public void Script_ExposesFunctionToBroadcast_Multiple()
        {
            // Arrange
            var script = new GameObject().AddComponent<BroadcastGameEvents>();
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();

            script.gameEvents.Add(gameEvent);
            script.gameEvents.Add(gameEvent);
            script.gameEvents.Add(gameEvent);

            var gameEventListenerFake = Substitute.For<IGameEventListener>();
            gameEvent.RegisterListener(gameEventListenerFake);

            // Act
            script.Broadcast();

            // Assert
            gameEventListenerFake.Received(3).OnEventBroadcast();
        }
        
        [Test]
        public void Script_ExposesFunctionToBroadcast_MultipleTypesOfGameEvents()
        {
            // Arrange
            var script = new GameObject().AddComponent<BroadcastGameEvents>();
            var gameEventA = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventB = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventC = ScriptableObject.CreateInstance<GameEvent>();

            script.gameEvents.Add(gameEventA);
            script.gameEvents.Add(gameEventB);
            script.gameEvents.Add(gameEventC);

            var gameEventListenerA = Substitute.For<IGameEventListener>();
            gameEventA.RegisterListener(gameEventListenerA);
            var gameEventListenerB = Substitute.For<IGameEventListener>();
            gameEventB.RegisterListener(gameEventListenerB);
            var gameEventListenerC = Substitute.For<IGameEventListener>();
            gameEventC.RegisterListener(gameEventListenerC);

            // Act
            script.Broadcast();

            // Assert
            gameEventListenerA.Received().OnEventBroadcast();
            gameEventListenerB.Received().OnEventBroadcast();
            gameEventListenerC.Received().OnEventBroadcast();
        }
    }
}