using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tests
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
                float initialXPos = platform.transform.position.x;
                //wait for 0.1 sec and assert that the x pos is greater
                yield return new WaitForSeconds(0.1f);
                Assert.Greater(platform.transform.position.x, initialXPos);
            }
        
    }
}
