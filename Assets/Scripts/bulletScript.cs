using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public Rigidbody2D projectile;
    public float speed = 15f;
    public int playerNumber;
    float startTime;
    public float duration = .5f;
    private float spin; //to animate spin of projectile

	// Use this for initialization
	void Start () {
        startTime = 0f;
        spin = 0;

	}
	
	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;
        //Once the projectile has been instantiated for a certain time. destroy it regardless if it hits anything.
        if(startTime >= duration)
        {
            Destroy(this.gameObject);
        }

        //Animates spin on projectile
        this.transform.rotation = Quaternion.Euler(0, 0, spin);
        spin += 10;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerLife player = other.gameObject.GetComponent<PlayerLife>();
            if (!player.killed) //He isn't dead and is thus visible.
            {
                Destroy(this.gameObject); //Destroy the bullet, whether or not he's invincible.
                if (!player.isInvincible) //Is the player hit invincible?
                {
                    //Adds a point to the player that shot the projectile.
                    if (playerNumber == 1)
                    {
                        GameObject.Find("P1ScoreManager").GetComponent<PlayerScore1Manager>().SendMessage("AddPoints", 1);
                    }
                    if (playerNumber == 2)
                    {
                        GameObject.Find("P2ScoreManager").GetComponent<PlayerScore2Manager>().SendMessage("AddPoints", 1);
                    }
                    if (playerNumber == 3)
                    {
                        GameObject.Find("P3ScoreManager").GetComponent<PlayerScore3Manager>().SendMessage("AddPoints", 1);
                    }
                    if (playerNumber == 4)
                    {
                        GameObject.Find("P4ScoreManager").GetComponent<PlayerScore4Manager>().SendMessage("AddPoints", 1);
                    }
                    Debug.Log("Killed Player");
                    player.killed = true;
                }
            }
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
