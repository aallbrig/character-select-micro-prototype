using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Lists
{
    [CreateAssetMenu(fileName = "New selectable characters list", menuName = "CSS/SelectableCharactersList", order = 0)]
    public class SelectableCharacterList : ScriptableObject
    {
        public List<SelectableCharacter.SelectableCharacter> list = new List<SelectableCharacter.SelectableCharacter>();
    }
}