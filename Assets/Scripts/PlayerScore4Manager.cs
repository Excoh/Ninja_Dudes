using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore4Manager : MonoBehaviour {
    
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
        //Win State
        if (score >= 10)
        {
            GameObject.Find("GameManager").SendMessage("WinState", 4);
        }

        text.text = "4\n" + score;
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
