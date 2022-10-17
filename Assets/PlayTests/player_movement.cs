using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class player_movement
{
    [UnityTest]
    public IEnumerator with_positve_vertical_input_moves_forward()
    {
        GameObject playerObject = new GameObject("Player");
        Player player = playerObject.AddComponent<Player>();
        player.PlayerInput = Substitute.For<IPlayerInput>();
        player.PlayerInput.Vertical.Returns(1f);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(playerObject.transform);
        cube.transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(1f);

        Assert.IsTrue(player.transform.position.z > 0f);
        Assert.AreEqual(0, player.transform.position.y);
        Assert.AreEqual(0, player.transform.position.x);
    }
}
