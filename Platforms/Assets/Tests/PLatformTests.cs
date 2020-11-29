using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PLatformTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
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
            game.GetPoints().GetNextPoint();
            game.GetPlatform().setUp();
            //wait for 0.1 sec and assert that the x pos is greater
            yield return new WaitForSeconds(0.1f);

            game.GetPlatform().MoveToward();
            Assert.Greater(platform.transform.position.x, initialXPos);
        }
        [UnityTest]
        public IEnumerator PlayerOnPlatform()
        {
            GameObject platform = game.GetPlatform().gameObject;
            GameObject player = game.GetPlayer().gameObject;
            game.GetPlatform().setTypeRotation();
            player.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 0.5f, platform.transform.position.z);
            bool playerOnPlatform = game.GetPlatform().getPlayerOnPlatform();
            yield return new WaitForSeconds(0.1f);
            Assert.True(playerOnPlatform);
        }
        [UnityTest]
        public IEnumerator PlatformReachesPoint()
        {

            GameObject platform = game.GetPlatform().gameObject;
            GameObject path = game.GetPoints().gameObject;
            Transform[] pointsPath = game.GetPoints().GetTransformArr();
            float pointXPos = pointsPath[1].transform.position.x;
         
            game.GetPlatform().setUp();
            //wait for 0.1 sec and assert that the x pos is greater
            yield return new WaitForSeconds(2.5f);
            game.GetPlatform().MoveToward();
            Assert.GreaterOrEqual(platform.transform.position.x, pointXPos);
        }
        [UnityTest]
        public IEnumerator PlatformReachesSecondPoint()
        {
            GameObject platform = game.GetPlatform().gameObject;

            Transform[] path = game.getTransformArr();
            float initialXPos = platform.transform.position.x;
            //wait for 0.1 sec and assert that the x pos is greater
            yield return new WaitForSeconds(0.3f);
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
}
