using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XboxCtrlrInput;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject WinPanel;
    public GameObject player1GUI;
    public GameObject player2GUI;
    public GameObject player3GUI;
    public GameObject player4GUI;
    public Sprite[] characterAvatar;

    public bool debugMode;

    // Use this for initialization
    void Start () {
        if (debugMode == false)
        {
            int currentAvatar;

            if (PlayerPrefs.GetInt("Player1Joined") == 0)
            {
                GameObject.Destroy(player1);
                GameObject.Destroy(player1GUI);
            }
            else
            {
                currentAvatar = PlayerPrefs.GetInt("Player1Avatar");
                player1GUI.transform.GetChild(0).GetComponent<Image>().sprite = characterAvatar[currentAvatar];
            }

            if (PlayerPrefs.GetInt("Player2Joined") == 0)
            {
                GameObject.Destroy(player2);
                GameObject.Destroy(player2GUI);
            }
            else
            {
                currentAvatar = PlayerPrefs.GetInt("Player2Avatar");
                player2GUI.transform.GetChild(0).GetComponent<Image>().sprite = characterAvatar[currentAvatar];
            }

            if (PlayerPrefs.GetInt("Player3Joined") == 0)
            {
                GameObject.Destroy(player3);
                GameObject.Destroy(player3GUI);
            }
            else
            {
                currentAvatar = PlayerPrefs.GetInt("Player3Avatar");
                player3GUI.transform.GetChild(0).GetComponent<Image>().sprite = characterAvatar[currentAvatar];
            }

            if (PlayerPrefs.GetInt("Player4Joined") == 0)
            {
                GameObject.Destroy(player4);
                GameObject.Destroy(player4GUI);
            }
            else
            {
                currentAvatar = PlayerPrefs.GetInt("Player4Avatar");
                player4GUI.transform.GetChild(0).GetComponent<Image>().sprite = characterAvatar[currentAvatar];
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WinState(int winnerNumber)
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        WinPanel.SetActive(true);
        WinPanel.transform.GetChild(0).GetComponent<Text>().text = "Player " + winnerNumber + " Wins!";
        WinPanel.transform.GetChild(1).GetComponent<Text>().text = "Player " + winnerNumber + " Press Start to Return to Selection Screen";

        if (XCI.GetButtonDown(XboxButton.Start, winnerNumber) ||
                Input.GetButtonDown("StartGame"))
        {
            Application.LoadLevel(1);
        }
    }
}
