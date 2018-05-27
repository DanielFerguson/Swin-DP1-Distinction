using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class Iteration3TDDTests
{
    [Test]
    public void TDDInstantiateEnemy()
    {
        var enemyGameObject = new GameObject();

        enemyGameObject.AddComponent<EnemyScript>();
        EnemyScript enemy = enemyGameObject.GetComponent<EnemyScript>();

        enemy.Start();

        // Test that enemy has EnemyLogic Component
        Assert.NotNull(enemy.Logic);

        // Test that the enemy is spawned
        Assert.NotNull(enemy.transform.position);

        // Test that the Enemy object is enabled / active
        Assert.IsTrue(enemy.enabled);
    }

    [Test]
    public void TDDLoadCorrectAsset()
    {
        // Responsibility: Caleb
        Assert.False(false);
    }

    [Test]
    public void TDDMovementAbility()
    {        // Responsibility: Duncan
        var enemyGameObject = new GameObject();
        enemyGameObject.AddComponent<EnemyScript>();
        EnemyScript enemy = enemyGameObject.GetComponent<EnemyScript>();

        enemy.Start();

        Rigidbody enemybody= enemy.GetComponent<Rigidbody>();
        
        //test that the enemy has a velocity
        Assert.NotNull(enemybody.velocity);
    }
}