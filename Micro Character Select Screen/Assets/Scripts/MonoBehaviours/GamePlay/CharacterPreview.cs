using System;
using ScriptableObjects.Refs;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class CharacterPreview : MonoBehaviour
    {
        public SelectableCharacterVar selectedCharacter;
        public GameObjectRef emptyPrefab;
        public Transform previewContainer;
        private GameObject _instance;

        private void RenderPreview()
        {
            if (_instance != null) Destroy(_instance);
            var prefab = selectedCharacter.value != null ? selectedCharacter.value.prefab.Value : emptyPrefab.Value;
            if (prefab != null) _instance = Instantiate(prefab, previewContainer);
        }

        private void Update() => RenderPreview();
    }
}