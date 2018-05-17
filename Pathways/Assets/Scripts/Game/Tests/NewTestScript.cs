using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.Networking;



public class NewTestScript
{

    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions.
        PlayerLogicAbstraction testPlayer = new PlayerLogicAbstraction("Player 1");
        bool testVal = true;
        Assert.AreEqual("Player 1", testPlayer.PlayerName);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
