using MonoBehaviours.GamePlay;
using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class CharacterPreviewTests
    {
        [Test]
        public void Script_Exists()
        {
            Assert.NotNull(new GameObject().AddComponent<CharacterPreview>());
        }

        [Test]
        public void Preview_InitialState()
        {
            var script = new GameObject().AddComponent<CharacterPreview>();
            Assert.Null(script.selectedCharacter);
        }

        [Test]
        public void Preview_SelectedCharacter_CanBeSet()
        {
            var script = new GameObject().AddComponent<CharacterPreview>();
            var payload = ScriptableObject.CreateInstance<SelectableCharacter>();

            script.SetSelectableCharacter(payload);

            Assert.AreEqual(payload, script.selectedCharacter);
        }
    }
}