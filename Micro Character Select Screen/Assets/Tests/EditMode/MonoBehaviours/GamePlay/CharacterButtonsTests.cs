using MonoBehaviours.GamePlay;
using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.GamePlay
{
    public class CharacterButtonsTests
    {
        [Test]
        public void Script_Exists() =>
            Assert.NotNull(new GameObject().AddComponent<CharacterButtons>());

        [Test]
        public void CharacterButtons_ButtonsMatchProvidedCharacterList_Single()
        {
            var dummyContainer = new GameObject();
            var script = new GameObject().AddComponent<CharacterButtons>();
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.buttonContainer = dummyContainer.transform;
            script.buttonPrefab = new GameObject();

            script.Render();

            Assert.AreEqual(1, dummyContainer.transform.childCount);
        }

        [Test]
        public void CharacterButtons_ButtonsMatchProvidedCharacterList_Multiple()
        {
            var dummyContainer = new GameObject();
            var script = new GameObject().AddComponent<CharacterButtons>();
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.availableCharacters.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            script.buttonContainer = dummyContainer.transform;
            script.buttonPrefab = new GameObject();

            script.Render();

            Assert.AreEqual(5, dummyContainer.transform.childCount);
        }
    }
}