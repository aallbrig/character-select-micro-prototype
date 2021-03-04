using System.Collections.Generic;
using MonoBehaviours.Customizers;
using ScriptableObjects.Events;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.GamePlay
{
    public class CharacterButtons : MonoBehaviour
    {
        public List<SelectableCharacter> availableCharacters = new List<SelectableCharacter>();
        public Transform buttonContainer;
        public GameObject buttonPrefab;
        public CharacterSelectedEvent characterSelected;

        private void OnEnable() => Render();

        public void Render()
        {
            foreach (Transform child in buttonContainer)
                Destroy(child.gameObject);

            availableCharacters.ForEach(character =>
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
    }
}