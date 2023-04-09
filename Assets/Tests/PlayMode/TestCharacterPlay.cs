using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCharacterPlay
{
    [UnityTest]
    public IEnumerator CharacterMovement()
    {
        // Arrange
        GameObject characterGameObject = new GameObject();
        Character character = characterGameObject.AddComponent<Character>(); // Adding Character Class into an empty character gameObject
        characterGameObject.AddComponent<Rigidbody2D>();
        characterGameObject.AddComponent<Animator>();
        float originalXPos = character.transform.position.x;
        int xInput = -1;
        // float screenLx = -5;

        // Act
        // character.Movement(xInput, screenLx);

        // Assert
        float expectedXPos = originalXPos + xInput * character.moveSpeed * Time.fixedDeltaTime;
        float actualXPos = character.transform.position.x;

        Debug.Log("originalXPos " + originalXPos);
        Debug.Log("character.moveSpeed " + character.moveSpeed);
        Debug.Log("Time.fixedDeltaTime " + Time.fixedDeltaTime);
        Debug.Log("expectedXPos " + expectedXPos);
        Debug.Log("actualXPos " + actualXPos);

        Assert.AreEqual(
            expectedXPos,
            actualXPos,
            0.001f,
            "Movement did not move the character the expected distance."
        );
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterControl() {
        // Arrange
        GameObject characterGameObject = new GameObject();
        Character character = characterGameObject.AddComponent<Character>();
        characterGameObject.AddComponent<Rigidbody2D>();
        characterGameObject.AddComponent<Animator>();

        // Simulate a touch
        Touch touch = new Touch();
        touch.position = new Vector2(Screen.width/2 + 100, 0);
        touch.fingerId = 0;
        touch = Input.GetTouch(0);
        Debug.Log(touch);

        // Act
        // int actualXInput = character.Control();

        // Assert
        // int expectedXInput = 0;

        // Assert.AreEqual(expectedXInput, actualXInput);
        yield return new WaitForSeconds(3);
    }
}
