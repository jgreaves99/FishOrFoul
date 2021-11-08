using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private int score;
	// Use this for initialization
	void Start ()
    {
        score = 100;
	}

    public int getScore()
    {
        return score;
    }

    public void iterate()
    {
        score++;
        text.text = "Score " + score;
    }
}
