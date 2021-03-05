using MonoBehaviours.Controllers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class AnimatorControllerTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<CharacterAnimatorController>());
    }
}