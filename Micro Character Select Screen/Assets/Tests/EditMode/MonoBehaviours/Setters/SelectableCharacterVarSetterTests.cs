using MonoBehaviours.Setters;
using NUnit.Framework;
using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Setters
{
    public class SelectableCharacterVarSetterTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<SelectableCharacterVarSetter>());

        [Test]
        public void Var_CanBe_Set()
        {
            var targetVar = ScriptableObject.CreateInstance<SelectableCharacterVar>();
            var newValue = ScriptableObject.CreateInstance<SelectableCharacter>();
            var script = new GameObject().AddComponent<SelectableCharacterVarSetter>();
            script.var = targetVar;

            script.SetVar(newValue);

            Assert.AreEqual(newValue, targetVar.value);
        }

        [Test]
        public void Var_CanBe_Reset()
        {
            var targetVar = ScriptableObject.CreateInstance<SelectableCharacterVar>();
            targetVar.value = ScriptableObject.CreateInstance<SelectableCharacter>();

            var script = new GameObject().AddComponent<SelectableCharacterVarSetter>();
            script.var = targetVar;

            script.ResetVar();

            Assert.IsNull(targetVar.value);
        }
    }
}