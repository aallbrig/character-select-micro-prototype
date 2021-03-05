using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class SelectableCharacterController : MonoBehaviour, ICharacterController
    {
        public GameObject animatorSource;

        public IAnimatorController AnimatorController { get; set; }

        public void Idle() => AnimatorController.SetTrigger("idle");
        public void Walk() => AnimatorController.SetTrigger("walk");
        public void Run() => AnimatorController.SetTrigger("run");
        public void Dance() => AnimatorController.SetTrigger("dance");

        private void CacheAnimator() =>
            (animatorSource != null ? animatorSource : gameObject).GetComponent<IAnimatorController>();

        private void OnEnable() => CacheAnimator();
    }
}