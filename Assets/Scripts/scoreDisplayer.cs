using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplayer : MonoBehaviour
{
    public GameManager gameManager { get; private set; }

    void Start()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        TextMeshProUGUI txt = this.GetComponent<TextMeshProUGUI>();
        txt.text = "Your score : " + this.gameManager.score;
    }
}
