using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCharacter
{
    Character.CharacterStub character;

    [SetUp]
    public void Setup(){
        character = new GameObject().AddComponent<Character.CharacterStub>();
        character.Rb = new GameObject().AddComponent<Rigidbody2D>();
    }

    [Test]
    public void Test_Character_Movement()
    {
        // Arrange
        character.ScreenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        character.ScreenLx = -character.ScreenRx;
        float originalXPos = character.transform.position.x;
        int xInput = -1;

        Debug.Log(originalXPos);
        // Act
        character.Movement(xInput);

        // Assert
        float expectedXPos = originalXPos + xInput * character.MoveSpeed * Time.fixedDeltaTime;
        float actualXPos = character.transform.position.x;
        Assert.AreEqual(expectedXPos, actualXPos, 0.001f);
    }

    [Test]
    public void Test_Character_Animation_WalkLeftRight(){
        // Arrange
        // character.animator = characterGameObject.AddComponent<Animator>();
        character.Rb.velocity = new Vector2(0, 0); // Velocity NOT falling
        character.IsFalling = true; 
        character.CurrentState = "isIdle"; // Say the character is idle now

        // Act
        character.AnimationStateController(1); // From current state to new state, go Right
        // Assert
        string expectedNewState = "isWalkingRight";
        string actualNewState = character.CurrentState;
        Assert.AreEqual(expectedNewState, actualNewState, "Not having the expected animation.");

        // Act2
        character.AnimationStateController(-1); // Go Left
        // Assert2
        expectedNewState = "isWalkingLeft";
        actualNewState = character.CurrentState;
        Assert.AreEqual(expectedNewState, actualNewState, "Not having the expected animation.");

        // Act3
        character.AnimationStateController(0); // Go Left
        // Assert3
        expectedNewState = "isIdle";
        actualNewState = character.CurrentState;
        Assert.AreEqual(expectedNewState, actualNewState, "Not having the expected animation.");
    }

    [Test]
    public void Test_Character_Init_Gravity(){
        // Arrange
        float expectedGravity, actualGravity;

        // Act
        character.Rb.gravityScale = 0;
        character.InitCharGravity(10);
        // Assert
        expectedGravity = 10;
        actualGravity = character.Rb.gravityScale;
        Assert.AreEqual(expectedGravity, actualGravity);

        // Act2
        character.Rb.gravityScale = 15;
        character.InitCharGravity(10);
        // Assert2
        expectedGravity = 15;
        actualGravity = character.Rb.gravityScale;
        Assert.AreEqual(expectedGravity, actualGravity);
    }
}
