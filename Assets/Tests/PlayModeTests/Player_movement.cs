using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Player_movement
{
  .
    [UnityTest]
    public IEnumerator Horiztonal_Input_Movement()
    {
        var Nplayer = new GameObject().AddComponent<Player>();
        Nplayer.speed = 2.5;

        yield.return.null;

        Assert.AreEqual(1, Nplayer.transform.position.x, 0.1f);


    }
}
