using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestStepsSpawner
{

    StepsSpawner stepsSpawner;
    // StepsSpawnerStub stepsSpawnerStub;
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    public void Test_Create_Step()
    {
        // Arrange
        stepsSpawner = new GameObject().AddComponent<StepsSpawnerStub>();
        stepsSpawner.step = new GameObject();
        stepsSpawner.step.name = "A Test step";
        
        // Act
        stepsSpawner.CreateStep();
        // Assert
        Assert.IsNotNull(stepsSpawner.transform.Find("A Test step(Clone)"));
    }

    [Test]
    public void Test_Create_Step_With_Item_By_Chance()
    {
        // Arrange
        stepsSpawner = new GameObject().AddComponent<StepsSpawner>();
        stepsSpawner.step = new GameObject();
        stepsSpawner.step.AddComponent<Step>();
        stepsSpawner.step.name = "A Test step";

        stepsSpawner.spawnItems = new GameObject[5];
        for (int i = 0; i < stepsSpawner.spawnItems.Length; i++) {
            stepsSpawner.spawnItems[i] = new GameObject();
            stepsSpawner.spawnItems[i].name = "randItem";
        }

        // Act
        stepsSpawner.CreateStep();
        // Assert
        Transform clonedStep;
        Assert.IsNotNull(clonedStep = stepsSpawner.transform.Find("A Test step(Clone)"));
        if (clonedStep.childCount >= 1){
            Assert.Pass();
        }
    }
}
