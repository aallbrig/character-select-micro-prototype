using UnityEngine;

namespace Interfaces
{
    public interface IAnimatorController
    {
        void UpdateAnimator(RuntimeAnimatorController runtimeAnimator);
        void SetTrigger(string triggerName);
    }
}