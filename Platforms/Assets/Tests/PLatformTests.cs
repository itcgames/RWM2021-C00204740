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

            yield return new WaitForSeconds(0.5f);
            Assert.True(game.playerOnPlat);
        }
       
    }
}
