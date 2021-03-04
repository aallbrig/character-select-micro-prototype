using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects
{
    public class SelectableCharacterTests
    {
        [Test]
        public void SelectableCharacter_ScriptableObject_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<SelectableCharacter>());

        [Test]
        public void SelectableCharacter_CharacterName_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<SelectableCharacter>().characterName);

        [Test]
        public void SelectableCharacter_CharacterPrefab_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<SelectableCharacter>().prefab);
    }
}