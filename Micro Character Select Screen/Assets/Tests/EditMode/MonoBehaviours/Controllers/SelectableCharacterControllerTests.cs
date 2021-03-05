using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class SelectableCharacterControllerTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<SelectableCharacterController>());

        [Test]
        public void Character_Can_Idle()
        {
            var script = new GameObject().AddComponent<SelectableCharacterController>();
            var animatorDouble = Substitute.For<IAnimatorController>();
            script.AnimatorController = animatorDouble;

            script.Idle();

            animatorDouble.Received().SetTrigger("idle");
        }

        [Test]
        public void Character_Can_Walk()
        {
            var script = new GameObject().AddComponent<SelectableCharacterController>();
            var animatorDouble = Substitute.For<IAnimatorController>();
            script.AnimatorController = animatorDouble;

            script.Walk();

            animatorDouble.Received().SetTrigger("walk");
        }

        [Test]
        public void Character_Can_Run()
        {
            var script = new GameObject().AddComponent<SelectableCharacterController>();
            var animatorDouble = Substitute.For<IAnimatorController>();
            script.AnimatorController = animatorDouble;

            script.Run();

            animatorDouble.Received().SetTrigger("run");
        }

        [Test]
        public void Character_Can_Dance()
        {
            var script = new GameObject().AddComponent<SelectableCharacterController>();
            var animatorDouble = Substitute.For<IAnimatorController>();
            script.AnimatorController = animatorDouble;

            script.Dance();

            animatorDouble.Received().SetTrigger("dance");
        }
    }
}