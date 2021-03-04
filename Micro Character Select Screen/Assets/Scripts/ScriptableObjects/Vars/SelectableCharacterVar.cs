using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "New selectable character var", menuName = "CSS/SelectableCharacterVar", order = 0)]
    public class SelectableCharacterVar : Var<SelectableCharacter.SelectableCharacter> {}
}