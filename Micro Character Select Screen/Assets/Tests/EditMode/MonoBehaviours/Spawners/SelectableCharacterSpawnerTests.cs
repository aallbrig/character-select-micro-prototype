using MonoBehaviours.Spawners;
using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Spawners
{
    public class SingleInstanceSpawnerTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<SelectableCharacterSpawner>());

        [Test]
        public void Spawner_CanSpawnSingleInstance_NoPreviousInstance()
        {
            var script = new GameObject().AddComponent<SelectableCharacterSpawner>();
            var selectableCharacter = ScriptableObject.CreateInstance<SelectableCharacter>();
            selectableCharacter.prefab.var = new GameObject();
                var transform = new GameObject().transform;
            script.parentTransform = transform;
            script.selectedCharacter = selectableCharacter;

            script.Spawn();

            Assert.AreEqual(1, transform.childCount);
        }
    }
}