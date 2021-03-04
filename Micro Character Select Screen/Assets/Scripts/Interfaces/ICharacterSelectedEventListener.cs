using ScriptableObjects.SelectableCharacter;

namespace Interfaces
{
    public interface ICharacterSelectedEventListener
    {
        void OnEventBroadcast(SelectableCharacter character);
    }
}