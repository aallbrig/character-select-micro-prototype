using NUnit.Framework;
using ScriptableObjects.Lists;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects
{
    public class SelectableCharacterListTests
    {
        [Test]
        public void SelectableCharacterList_List_Exists()
        {
            Assert.NotNull(ScriptableObject.CreateInstance<SelectableCharacterList>());
        }
    }
}