using NUnit.Framework;
using UnityEngine.UI;
using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine.TestTools;

public class NewTestScript
{

    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions.

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator PlayerMovment()
    {
       // Assert.True(if Input.GetKey(KeyCode.DownArrow) && Rigidbody.velocity != 0);
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
