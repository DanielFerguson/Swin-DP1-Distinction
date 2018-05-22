using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class NewTestScript {

    [Test]
    public void NewTestScriptSimplePasses() {
        // Use the Assert class to test conditions.

        var gameObject = new GameObject();

        gameObject.AddComponent<Player>();
        Player testPlayer = gameObject.GetComponent<Player>();

        testPlayer.StartPlayer();

    //    bool testBool=testPlayer.UnitySucks;
    //    Text test=testPlayer.Course;

        Assert.AreEqual(0, testPlayer.PlayerLevel);

 //       Assert.AreEqual("bob", testPlayer.PlayerName);

        Assert.AreEqual(500, testPlayer.PlayerDebt);

        Assert.AreEqual(25, testPlayer.UnitCreditsRequired);

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
