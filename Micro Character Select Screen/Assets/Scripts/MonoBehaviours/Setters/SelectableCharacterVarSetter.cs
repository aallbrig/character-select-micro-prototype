using System;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Actions;
using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.Setters
{
    public class SelectableCharacterVarSetter : MonoBehaviour
    {
        public SelectableCharacterVar var;

        public void SetVar(SelectableCharacter character) => var.value = character;

        public void ResetVar() => var.value = null;

        private void OnEnable() => ResetVar();
    }
}