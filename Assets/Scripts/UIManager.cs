using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager { get; private set; }

    void Start()
    {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    public void NewGame()
    {
        this.gameManager.NewGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
