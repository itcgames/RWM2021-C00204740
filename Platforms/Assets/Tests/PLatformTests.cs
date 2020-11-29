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
        public IEnumerator RotationBegins()
        {
            GameObject platform = game.GetPlatform().gameObject;
            GameObject player = game.GetPlayer().gameObject;
            game.GetPlatform().setUp();
            game.GetPlatform().setTypeRotation();
            //wait for .5 seconds and check if the current rotation is greater than the initial
            yield return new WaitForSeconds(0.3f);
            game.GetPlatform().PlatformRotation();
            Assert.True(game.rotating);
        }
        [UnityTest]
        public IEnumerator PlayerOnPlatform()
        {
            GameObject platform = game.GetPlatform().gameObject;
            GameObject player = game.GetPlayer().gameObject;

            game.GetPlatform().setTypeRotation();
            //wait for .5 secs and asset that the bool to check player was on platform was true
            yield return new WaitForSeconds(0.5f);
            Assert.True(game.playerOnPlat);
        }
        [UnityTest]
        public IEnumerator RotateToOriginal()
        {
            GameObject platform = game.GetPlatform().gameObject;
            game.GetPlatform().setTypeRotation();
           
            
            game.GetPlatform().setUp();
            //wait for 10 sec and assert that the bool to check if its at original rotation is true
            yield return new WaitForSeconds(10.0f);

            game.GetPlatform().PlatformRotation();
            Assert.True(game.backToOriginalRotation);
        }
        
    }
}
