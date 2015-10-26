using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public bool debugMode;

    // Use this for initialization
    void Start () {
        if (debugMode == false)
        {
            if (PlayerPrefs.GetInt("Player1Joined") == 0)
            {
                GameObject.Destroy(player1);
            }
            if (PlayerPrefs.GetInt("Player2Joined") == 0)
            {
                GameObject.Destroy(player2);
            }
            if (PlayerPrefs.GetInt("Player3Joined") == 0)
            {
                GameObject.Destroy(player3);
            }
            if (PlayerPrefs.GetInt("Player4Joined") == 0)
            {
                GameObject.Destroy(player4);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
