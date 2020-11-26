using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class Testing
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }
    [UnityTest]
    public IEnumerator PlatformMovesRight()
    {
        GameObject platform = game.GetPlatform().gameObject;
        GameObject path = game.GetPoints().gameObject;
        float initialXPos = platform.transform.position.x;
        //wait for 0.1 sec and assert that the x pos is greater
        yield return new WaitForSeconds(0.1f);
        game.GetPoints().GetNextPoint();
        game.GetPlatform().setType();
        game.GetPlatform().MoveTowards();
        Assert.Greater(platform.transform.position.x, initialXPos);
    }
    [UnityTest]
    public IEnumerator PlayerOnPlatform()
    {
        GameObject platform = game.GetPlatform().gameObject;

        ////wait for 0.1 sec and assert that the x pos is greater
        //yield return new WaitForSeconds(0.1f);
        //Assert.Greater(platform.transform.position.x, initialXPos);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator PlatformReachesPoint()
    {
        GameObject platform = game.GetPlatform().gameObject;

        Transform[] path = game.getTransformArr();
        float initialXPos = platform.transform.position.x;
        //wait for 0.1 sec and assert that the x pos is greater
        yield return new WaitForSeconds(0.1f);
        Assert.Equals(platform.transform.position.x, path[1].transform.position.x);
    }
    [UnityTest]
    public IEnumerator PlatformReachesSecondPoint()
    {
        GameObject platform = game.GetPlatform().gameObject;

        Transform[] path = game.getTransformArr();
        float initialXPos = platform.transform.position.x;
        //wait for 0.1 sec and assert that the x pos is greater
        yield return new WaitForSeconds(0.1f);
        Assert.Equals(platform.transform.position.x, path[2].transform.position.x);
    }
    [UnityTest]
    public IEnumerator PlatformReachesThirdPoint()
    {
        GameObject platform = game.GetPlatform().gameObject;

        Transform[] path = game.getTransformArr();
        float initialXPos = platform.transform.position.x;
        //wait for 0.1 sec and assert that the x pos is greater
        yield return new WaitForSeconds(0.1f);
        Assert.Equals(platform.transform.position.x, path[3].transform.position.x);
    }
}

