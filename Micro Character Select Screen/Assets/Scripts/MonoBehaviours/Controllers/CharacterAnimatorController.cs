using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class CharacterAnimatorController : MonoBehaviour, IAnimatorController
    {
        public GameObject animatorSource;
        public Animator animator;

        public GameObject AnimatorSource
        {
            get => animatorSource != null ? animatorSource : gameObject;
            set
            {
                animatorSource = value;
                CacheAnimator();
            }
        }

        public void UpdateAnimator(RuntimeAnimatorController runtimeAnimator) =>
            animator.runtimeAnimatorController = runtimeAnimator;
        public void SetTrigger(string triggerName) => animator.SetTrigger(triggerName);

        private void CacheAnimator() => animator = AnimatorSource.GetComponent<Animator>();

        private void OnEnable() => CacheAnimator();
    }
}