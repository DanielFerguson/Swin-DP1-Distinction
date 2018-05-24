using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class Iteration2Tests {

    [Test]
    public void TestPlayerStartStats() {

        var gameObject = new GameObject();

        gameObject.AddComponent<Player>();
        Player testPlayer = gameObject.GetComponent<Player>();

        testPlayer.StartPlayer();
        testPlayer.CheckIfWon();

        // Check for player level == 0
        Assert.AreEqual(0, testPlayer.PlayerLevel);

        // Check that player debt == 500
        Assert.AreEqual(500, testPlayer.PlayerDebt);

        // Check that starting unit credit requrements == 25
        Assert.AreEqual(25, testPlayer.UnitCreditsRequired);

        // Check that player object 
        Assert.AreEqual(false, testPlayer.hasWon);
    }

    [Test]
    public void TestPlayerUpdateStats()
    {
        var gameObject = new GameObject();

        gameObject.AddComponent<Player>();
        Player testPlayer = gameObject.GetComponent<Player>();

        testPlayer.StartPlayer();

        // Check that player stats go up accordingly
        testPlayer.UpdateDegree(1);
        testPlayer.UpdateRequiredUnitCredits(1);
        Assert.AreEqual(550, testPlayer.PlayerDebt);
        Assert.AreEqual(75, testPlayer.UnitCreditsRequired);

        // Check that player stats go up accordingly
        testPlayer.UpdateDegree(2);
        testPlayer.UpdateRequiredUnitCredits(2);
        Assert.AreEqual(650, testPlayer.PlayerDebt);
        Assert.AreEqual(175, testPlayer.UnitCreditsRequired);

        // Check that player stats go up accordingly
        testPlayer.UpdateDegree(3);
        testPlayer.UpdateRequiredUnitCredits(3);
        Assert.AreEqual(750, testPlayer.PlayerDebt);
        Assert.AreEqual(325, testPlayer.UnitCreditsRequired);

        // Check that player stats go up accordingly
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
}
