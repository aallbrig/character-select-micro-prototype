using MonoBehaviours.GamePlay;
using NUnit.Framework;
using ScriptableObjects.Lists;
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
            var availableCharacters = ScriptableObject.CreateInstance<SelectableCharacterList>();
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            var dummyContainer = new GameObject();
            var script = new GameObject().AddComponent<CharacterButtons>();
            script.availableCharacters = availableCharacters;
            script.buttonContainer = dummyContainer.transform;
            script.buttonPrefab = new GameObject();

            script.Render();

            Assert.AreEqual(1, dummyContainer.transform.childCount);
        }

        [Test]
        public void CharacterButtons_ButtonsMatchProvidedCharacterList_Multiple()
        {
            var availableCharacters = ScriptableObject.CreateInstance<SelectableCharacterList>();
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            availableCharacters.list.Add(ScriptableObject.CreateInstance<SelectableCharacter>());
            var dummyContainer = new GameObject();
            var script = new GameObject().AddComponent<CharacterButtons>();
            script.availableCharacters = availableCharacters;
            script.buttonContainer = dummyContainer.transform;
            script.buttonPrefab = new GameObject();

            script.Render();

            Assert.AreEqual(5, dummyContainer.transform.childCount);
        }
    }
}