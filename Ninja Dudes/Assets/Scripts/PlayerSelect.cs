using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class PlayerSelect : MonoBehaviour {

    public int PlayerNumber;
    int currentSelection;
    public GameObject[] images;
    public GameObject isReadyText;
    public bool isReady;
	// Use this for initialization
	void Start () {
        isReady = false;
        currentSelection = PlayerNumber - 1;
        images[currentSelection].SetActive(true);
        isReadyText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isReady){
            if (XCI.GetDPadDown(XboxDPad.Left, PlayerNumber))
            {
                images[currentSelection].SetActive(false);
                currentSelection--;
                if (currentSelection == -1)
                {
                    currentSelection = images.Length - 1;
                }
                images[currentSelection].SetActive(true);
                //Determine what avatar the player is using
                if (PlayerNumber == 1)
                {
                    PlayerPrefs.SetInt("Player1Avatar", currentSelection);
                }
                else if (PlayerNumber == 2)
                {
                    PlayerPrefs.SetInt("Player2Avatar", currentSelection);
                }
                else if (PlayerNumber == 3)
                {
                    PlayerPrefs.SetInt("Player3Avatar", currentSelection);
                }
                else if (PlayerNumber == 4)
                {
                    PlayerPrefs.SetInt("Player4Avatar", currentSelection);
                }
            }
            if (XCI.GetDPadDown(XboxDPad.Right, PlayerNumber))
            {
                images[currentSelection].SetActive(false);
                currentSelection++;
                if (currentSelection == images.Length)
                {
                    currentSelection = 0;
                }
                images[currentSelection].SetActive(true);
            }
            if (XCI.GetButtonDown(XboxButton.A, PlayerNumber))
            {
                isReady = true;
                isReadyText.SetActive(true);
            }

            //DEBUG CONTROLS
            if (PlayerNumber == 1)
            {
                if (Input.GetButtonDown("Player1Fire"))
                {
                    isReady = true;
                    isReadyText.SetActive(true);
                    PlayerPrefs.SetInt("Player1Avatar", currentSelection);
                }
                if (Input.GetButtonDown("Player1Left"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection--;
                    if (currentSelection == -1)
                    {
                        currentSelection = images.Length - 1;
                    }
                    images[currentSelection].SetActive(true);
                }
                if (Input.GetButtonDown("Player1Right"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection++;
                    if (currentSelection == images.Length)
                    {
                        currentSelection = 0;
                    }
                    images[currentSelection].SetActive(true);
                }
            }
            if (PlayerNumber == 2)
            {
                if (Input.GetButtonDown("Player2Fire"))
                {
                    isReady = true;
                    isReadyText.SetActive(true);
                    PlayerPrefs.SetInt("Player2Avatar", currentSelection);
                }
                if (Input.GetButtonDown("Player2Left"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection--;
                    if (currentSelection == -1)
                    {
                        currentSelection = images.Length - 1;
                    }
                    images[currentSelection].SetActive(true);
                }
                if (Input.GetButtonDown("Player2Right"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection++;
                    if (currentSelection == images.Length)
                    {
                        currentSelection = 0;
                    }
                    images[currentSelection].SetActive(true);
                }
            }
            if (PlayerNumber == 3)
            {
                if (Input.GetButtonDown("Player3Fire"))
                {
                    isReady = true;
                    isReadyText.SetActive(true);
                    PlayerPrefs.SetInt("Player3Avatar", currentSelection);
                }
                if (Input.GetButtonDown("Player3Left"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection--;
                    if (currentSelection == -1)
                    {
                        currentSelection = images.Length - 1;
                    }
                    images[currentSelection].SetActive(true);
                }
                if (Input.GetButtonDown("Player3Right"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection++;
                    if (currentSelection == images.Length)
                    {
                        currentSelection = 0;
                    }
                    images[currentSelection].SetActive(true);
                }
            }
            if (PlayerNumber == 4)
            {
                if (Input.GetButtonDown("Player4Fire"))
                {
                    isReady = true;
                    isReadyText.SetActive(true);
                    PlayerPrefs.SetInt("Player4Avatar", currentSelection);
                } 
                if (Input.GetButtonDown("Player4Left"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection--;
                    if (currentSelection == -1)
                    {
                        currentSelection = images.Length - 1;
                    }
                    images[currentSelection].SetActive(true);
                }
                if (Input.GetButtonDown("Player4Right"))
                {
                    images[currentSelection].SetActive(false);
                    currentSelection++;
                    if (currentSelection == images.Length)
                    {
                        currentSelection = 0;
                    }
                    images[currentSelection].SetActive(true);
                }
            }
        }
        //Is ready don't change image
        else
        {
            if (XCI.GetButtonDown(XboxButton.A, PlayerNumber))
            {
                isReady = false;
                isReadyText.SetActive(false);
            }
            //DEBUG CONTROLS
            if (PlayerNumber == 1)
            {
                if (Input.GetButtonDown("Player1Fire"))
                {
                    isReady = false;
                    isReadyText.SetActive(false);
                }
            }
            if (PlayerNumber == 2)
            {
                if (Input.GetButtonDown("Player2Fire"))
                {
                    isReady = false;
                    isReadyText.SetActive(false);
                }
            }
            if (PlayerNumber == 3)
            {
                if (Input.GetButtonDown("Player3Fire"))
                {
                    isReady = false;
                    isReadyText.SetActive(false);
                }
            }
            if (PlayerNumber == 4)
            {
                if (Input.GetButtonDown("Player4Fire"))
                {
                    isReady = false;
                    isReadyText.SetActive(false);
                }
            }
        }
    }
}
