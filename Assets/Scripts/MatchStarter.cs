using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class MatchStarter : MonoBehaviour {

    public GameObject[] players;
    public GameObject isAllReady;
    public AudioClip startSound;

	// Use this for initialization
	void Start () {
        isAllReady.SetActive(false);

        //Player 1 or 2 are automatically joined in
        PlayerPrefs.SetInt("Player1Joined", 1);
        PlayerPrefs.SetInt("Player2Joined", 1);
        PlayerPrefs.SetInt("Player3Joined", 0);
        PlayerPrefs.SetInt("Player4Joined", 0);
    }
	
	// Update is called once per frame
	void Update () {
        
        //Player 3 joined game
        if (XCI.GetButtonDown(XboxButton.A, 3) ||
            Input.GetButtonDown("Player3Fire"))
        {
            players[2].SetActive(true);
            PlayerPrefs.SetInt("Player3Joined", 1);
        }
        //Player 4 joined game
        if (XCI.GetButtonDown(XboxButton.A, 4) ||
            Input.GetButtonDown("Player4Fire"))
        {
            players[3].SetActive(true);
            PlayerPrefs.SetInt("Player4Joined", 1);
        }

        //Checks if all players are ready. If so allows the 
        //player to start the game
        if (checkPlayer(0) && checkPlayer(1) &&
            checkPlayer(2) && checkPlayer(3))
        {
            isAllReady.SetActive(true);
        }
        else
        {
            isAllReady.SetActive(false);
        }

        if(isAllReady.activeSelf == true)
        {
            if (XCI.GetButtonDown(XboxButton.Start, 1) ||
                Input.GetButtonDown("StartGame"))
            {
                Application.LoadLevel(2);
            }
        }
	}

    //Checks whether the player has joined the game and has selected an avatar
    //or if the player didn't join the game
    bool checkPlayer(int num)
    {
        return (players[num].activeSelf == true && players[num].GetComponent<PlayerSelect>().isReady == true)
            || players[num].activeSelf == false;
    }
}
