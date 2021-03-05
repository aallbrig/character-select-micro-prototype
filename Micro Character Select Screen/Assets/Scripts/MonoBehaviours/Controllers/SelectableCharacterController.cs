using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class SelectableCharacterController : MonoBehaviour, ICharacterController
    {
        public GameObject animatorControllerSource;

        public IAnimatorController AnimatorController { get; set; }

        [ContextMenu("Idle")] public void Idle() => AnimatorController.SetTrigger("idle");
        [ContextMenu("Walk")] public void Walk() => AnimatorController.SetTrigger("walk");
        [ContextMenu("Run")] public void Run() => AnimatorController.SetTrigger("run");
        [ContextMenu("Dance")] public void Dance() => AnimatorController.SetTrigger("dance");

        private void CacheAnimatorController() =>
            AnimatorController = (animatorControllerSource != null ? animatorControllerSource : gameObject).GetComponent<IAnimatorController>();

        private void OnEnable() => CacheAnimatorController();
    }
}