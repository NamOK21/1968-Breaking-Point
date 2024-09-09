using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverUI;
    public PauseMenu pause;

    // Game Over Menu
    public void GameOver()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
