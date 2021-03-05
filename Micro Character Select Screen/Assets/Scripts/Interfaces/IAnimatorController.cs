using UnityEngine;

namespace Interfaces
{
    public interface IAnimatorController
    {
        void UpdateAnimator(RuntimeAnimatorController animator);
        void SetTrigger(string triggerName);
    }
}