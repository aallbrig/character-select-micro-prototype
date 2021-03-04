using MonoBehaviours.GamePlay;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class CharacterButtonsTests
    {
        [Test]
        public void Script_Exists() =>
            Assert.NotNull(new GameObject().AddComponent<CharacterButtons>());
    }
}