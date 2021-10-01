using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // using this we can transition between different scene or load our current scene

public class GameManager : MonoBehaviour
{
    // it is important to write public keyword or button won't be able to call this function.
   public void PlayGame()
    {
        // To transition between scene. in bracket use the name of the scene we want to transition to.
        SceneManager.LoadScene("Game");
    }
}
