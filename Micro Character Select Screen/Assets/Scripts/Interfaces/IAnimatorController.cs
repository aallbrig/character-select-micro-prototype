using UnityEngine;

namespace Interfaces
{
    public interface IAnimatorController
    {
        GameObject AnimatorSource { get; set; }

        void UpdateAnimator(RuntimeAnimatorController runtimeAnimator);
        void SetTrigger(string triggerName);
    }
}