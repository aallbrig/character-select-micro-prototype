using ScriptableObjects.Refs;
using UnityEngine;

namespace ScriptableObjects.SelectableCharacter
{
    [CreateAssetMenu(fileName = "New selectable character", menuName = "CSS/SelectableCharacter", order = 0)]
    public class SelectableCharacter : ScriptableObject
    {
        public StringRef characterName = new StringRef();
        public GameObjectRef prefab = new GameObjectRef();
    }
}