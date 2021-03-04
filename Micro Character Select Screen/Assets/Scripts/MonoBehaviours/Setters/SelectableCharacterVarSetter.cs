using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.Setters
{
    public class SelectableCharacterVarSetter : MonoBehaviour
    {
        public SelectableCharacterVar var;

        private void OnEnable() => ResetVar();

        public void SetVar(SelectableCharacter character) => var.value = character;

        public void ResetVar() => var.value = null;
    }
}