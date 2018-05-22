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

        testPlayer.CheckIfWon();

        Assert.AreEqual(false, testPlayer.hasWon);

        testPlayer.UpdateDegree(1);
        testPlayer.UpdateRequiredUnitCredits(1);
        Assert.AreEqual(550, testPlayer.PlayerDebt);
        Assert.AreEqual(75, testPlayer.UnitCreditsRequired);

        testPlayer.UpdateDegree(2);
        testPlayer.UpdateRequiredUnitCredits(2);
        Assert.AreEqual(650, testPlayer.PlayerDebt);
        Assert.AreEqual(175, testPlayer.UnitCreditsRequired);

        testPlayer.UpdateDegree(3);
        testPlayer.UpdateRequiredUnitCredits(3);
        Assert.AreEqual(750, testPlayer.PlayerDebt);
        Assert.AreEqual(325, testPlayer.UnitCreditsRequired);

        testPlayer.UpdateDegree(4);
        testPlayer.UpdateRequiredUnitCredits(4);
        Assert.AreEqual(1000, testPlayer.PlayerDebt);
        Assert.AreEqual(525, testPlayer.UnitCreditsRequired);

    }

    [Test]
    public void TestGameOverCredit()
    {
        var gameObject = new GameObject();

        gameObject.AddComponent<Player>();
        Player testPlayer = gameObject.GetComponent<Player>();

        testPlayer.StartPlayer();

        for (int i = 0; i < 20; i++)
        {
            testPlayer.UnitCreditDecreament();
            testPlayer.CheckDegree();
        }

        Assert.AreEqual(false, testPlayer.hasWon);

        testPlayer.UnitCreditDecreament();
        testPlayer.CheckDegree();

        Assert.AreEqual(true, testPlayer.hasWon);
    }

    [Test]
    public void TestGameOverDebt()
    {
        var gameObject = new GameObject();

        gameObject.AddComponent<Player>();
        Player testPlayer = gameObject.GetComponent<Player>();

        testPlayer.StartPlayer();

        for (int i=0; i<5; i++) {
            testPlayer.DebtDecreament();
        }
        testPlayer.CheckIfWon();

        Assert.AreEqual(true, testPlayer.hasWon);
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
