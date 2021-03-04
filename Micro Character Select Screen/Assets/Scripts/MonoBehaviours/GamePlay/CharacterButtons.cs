using System;
using MonoBehaviours.Customizers;
using ScriptableObjects.Events;
using ScriptableObjects.Lists;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.GamePlay
{
    public class CharacterButtons : MonoBehaviour
    {
        public SelectableCharacterList availableCharacters;
        public Transform buttonContainer;
        public GameObject buttonPrefab;
        public CharacterSelectedEvent characterSelected;

        public void Render()
        {
            foreach (Transform child in buttonContainer)
            {
                Destroy(child.gameObject);
            }

            availableCharacters.list.ForEach(character =>
            {
                var go = Instantiate(buttonPrefab, buttonContainer);
                var textCustomizer = go.GetComponentInChildren<TextMeshProTextCustomizer>();
                if (textCustomizer != null)
                {
                    textCustomizer.text.useConstant = false;
                    textCustomizer.text.var = character.characterName.Value;
                }
                var button = go.GetComponent<Button>();

                if (button != null) button.onClick.AddListener(() => characterSelected.Broadcast(character));
            });
        }

        private void OnEnable() => Render();
    }
}