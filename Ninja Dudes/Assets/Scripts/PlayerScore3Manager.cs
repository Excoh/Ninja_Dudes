using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore3Manager : MonoBehaviour {
    
    public int score;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        score = 0;
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (score < 0)
        {
            score = 0;
        }

        text.text = "3\n" + score;
	}
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void Reset()
    {
        score = 0;
    }
}
