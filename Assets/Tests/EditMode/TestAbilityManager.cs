using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestAbilityManager
{
    AbilityManager abilityManager;
    // Character character;

    [SetUp]
    public void Setup()
    {
        abilityManager = new GameObject().AddComponent<AbilityManager>();
    }

    [Test]
    public void Test_MultiplyCharRunSpeed()
    {
        // Arrange
        float testMultiplier = 1.6f;
        float testMoveSpeed = 10;
        abilityManager.character = new GameObject().AddComponent<Character>();
        abilityManager.character.MoveSpeed = testMoveSpeed;

        // Act
        abilityManager.MultiplyCharRunSpeed(testMultiplier);
        
        // Assert
        float expectedCharMoveSpeed = testMoveSpeed*testMultiplier;
        var actualCharMoveSpeed = abilityManager.character.MoveSpeed;
        Assert.AreEqual(expectedCharMoveSpeed, actualCharMoveSpeed);
    }

    [Test]
    public void Test_MultiplyStepSpeed()
    {
        // Arrange
        float testMultiplier = 1.6f;
        float originStepUpSpeed = 17.85f;
        StepsSpawner.stepUpSpeed = originStepUpSpeed;

        // Act
        abilityManager.MultiplyStepSpeed(testMultiplier);
        
        // Assert
        float expectedStepUpSpeed = originStepUpSpeed*testMultiplier;
        Assert.AreEqual(expectedStepUpSpeed, StepsSpawner.stepUpSpeed);
    }
}
