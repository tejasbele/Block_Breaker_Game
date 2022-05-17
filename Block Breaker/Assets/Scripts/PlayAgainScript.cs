using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   // package of SceneManaging stuffs

public class PlayAgainScript : MonoBehaviour
{
    public void LoadStartMenu(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
}
