using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HorizontalMovement
{
    // A Test behaves as an ordinary method
    [Test]
    public void HorizontalMovementSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HorizontalMovementWithEnumeratorPasses()
    {
        var Player = new GameObject().AddComponent<Player>();
        Rigidbody rigidBody = Player.GetComponent<Rigidbody>();
        float horizontalInput = Player.horizontalInput;
        float speed = Player.speed;
        Player.HorizontalMovement(horizontalInput, speed);

        var expected = new Vector3(horizontalInput * speed, rigidBody.velocity.y, 0);

        var movement = Player.HorizontalMovement(horizontalInput, speed);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Assert.Equals(expected, movement);
    }
}
