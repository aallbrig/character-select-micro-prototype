using Interfaces;
using ScriptableObjects.SelectableCharacter;
using UnityEngine;

namespace MonoBehaviours.Spawners
{
    public class SelectableCharacterSpawner : MonoBehaviour, ISpawner, ICharacterSelectedEventListener
    {
        public Transform parentTransform;
        public SelectableCharacter selectedCharacter;
        public RuntimeAnimatorController animator;
        private GameObject _instance;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            DestroyInstance();

            _instance = Instantiate(selectedCharacter.prefab.Value, parentTransform);
            var animatorController = GetComponent<IAnimatorController>();
            if (animatorController != null)
            {
                animatorController.AnimatorSource = _instance;
                animatorController.UpdateAnimator(animator);
            }
            var characterController = GetComponent<ICharacterController>();
            characterController?.Dance();
        }

        [ContextMenu("De-spawn")]
        public void DestroyInstance()
        {
            if (_instance != null) Destroy(_instance);
        }

        public void OnEventBroadcast(SelectableCharacter character) => selectedCharacter = character;
    }
}