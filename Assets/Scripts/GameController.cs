using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance { get; private set; }

    private int score = 0;

    public Text scoreText;

    void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddToScore(int value) {
        score += value;
    }

}
