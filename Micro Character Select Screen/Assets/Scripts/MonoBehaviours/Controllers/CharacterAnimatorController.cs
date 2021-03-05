using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class CharacterAnimatorController : MonoBehaviour, IAnimatorController
    {
        public GameObject animatorSource;
        public Animator animator;

        public void UpdateAnimator(RuntimeAnimatorController runtimeAnimator) =>
            animator.runtimeAnimatorController = runtimeAnimator;
        public void SetTrigger(string triggerName) => animator.SetTrigger(triggerName);

        private void CacheAnimator() =>
            animator = (animatorSource != null ? animatorSource : gameObject).GetComponent<Animator>();

        private void OnEnable() => CacheAnimator();
    }
}