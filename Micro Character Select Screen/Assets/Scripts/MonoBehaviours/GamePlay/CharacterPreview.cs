using System;
using ScriptableObjects.Refs;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    public class CharacterPreview : MonoBehaviour
    {
        public SelectableCharacter selectedCharacter;
        public GameObjectRef emptyPrefab;
        public Transform previewContainer;
        private GameObject _instance;

        public void SetSelectableCharacter(SelectableCharacter character)
        {
            selectedCharacter = character;
            RenderPreview();
        }

        private void RenderPreview()
        {
            if (_instance != null) Destroy(_instance);
            var prefab = selectedCharacter != null ? selectedCharacter.prefab.Value : emptyPrefab.Value;
            if (prefab != null) _instance = Instantiate(prefab, previewContainer);
        }

        private void OnEnable()
        {
            RenderPreview();
        }
    }
}