using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAvatar : MonoBehaviour {
    public int playerNumber;
    int currentAvatar;
    public Sprite[] Avatars;

	// Use this for initialization
	void Start () {
	    if(playerNumber == 1)
        {
            currentAvatar = PlayerPrefs.GetInt("Player1Avatar");
        }
        else if (playerNumber == 2)
        {
            currentAvatar = PlayerPrefs.GetInt("Player2Avatar");
        }
        else if(playerNumber == 3)
        {
            currentAvatar = PlayerPrefs.GetInt("Player3Avatar");
        }
        else if(playerNumber == 4)
        {
            currentAvatar = PlayerPrefs.GetInt("Player4Avatar");
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Avatars[currentAvatar];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
