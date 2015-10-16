using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public bool killed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (killed)
        {
            //Move to new respawn location
            GameObject[] respawnPosition = GameObject.FindGameObjectsWithTag("Respawn");
            int randNum = Random.Range(0, 3);
            gameObject.transform.position = respawnPosition[randNum].transform.position;
            killed = false;
        }
	}

}
