using MonoBehaviours.GamePlay;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class CharacterPreviewTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<CharacterPreview>());

        [Test]
        public void Preview_InitialState()
        {
            var script = new GameObject().AddComponent<CharacterPreview>();
            Assert.Null(script.selectedCharacter);
        }
    }
}