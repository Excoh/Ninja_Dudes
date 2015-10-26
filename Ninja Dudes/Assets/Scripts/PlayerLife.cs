using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{

    //**CHANGE: Added public variables
    public int PlayerNumber;
    public float respawnTime = 3f;
    public float invincibilityDuration = 3f;
    float timeStamp;
    bool waitingForRespawn = false;
    public bool isInvincible = false;

    Color flashColor = Color.black; //Feel free to change the color, or think up of some other way to indicate invincibility.
    float flashTimeStamp = 0;
    float timePerFlash = 0.15f;
    //---------------------------------

    public bool killed = false;
    // Use this for initialization
    void Start()
    {
        timeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (killed)
        {
            //**CHANGE: Check if the player already isn't waiting to respawn. Add the points and continue.
            if (!waitingForRespawn)
            {
                this.gameObject.GetComponent<Renderer>().enabled = false;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

                timeStamp = Time.time + respawnTime;
                waitingForRespawn = true;
            }
            //--------------------------------------------------------------------

            //**CHANGE: Enough time has passed to respawn
            if (Time.time > timeStamp)
            {

                //Move to new respawn location
                GameObject[] respawnPosition = GameObject.FindGameObjectsWithTag("Respawn");
                int randNum = Random.Range(0, 3);

                gameObject.transform.position = respawnPosition[randNum].transform.position;

                //** CHANGE: Render the sprite and make the player invincible.
                this.gameObject.GetComponent<Renderer>().enabled = true;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = true;

                waitingForRespawn = false; //Reset respawn variable and set invincible variable
                isInvincible = true;
                Debug.Log("INVINCIBLE");
                timeStamp = Time.time + invincibilityDuration; //Set timer for invincibility
                //---------------------------------------

                killed = false;
            }
            //--------------------------------------------

        }

        //**CHANGE: Invincibility Check
        if (isInvincible)
        {
            alternateColors(); //Flash!

            if (Time.time > timeStamp) //Timer has run out for invincibility
            {

                Debug.Log("NO LONGER INVINCIBLE");
                this.gameObject.GetComponent<Renderer>().material.color = Color.white; //Reset the color
                isInvincible = false; //You are no longer invincible!
            }
        }

        //--------------------------------
    }

    void alternateColors()
    {
        if (Time.time - flashTimeStamp > timePerFlash)
        {
            Renderer renderer = this.gameObject.GetComponent<Renderer>();
            if (renderer.material.color == flashColor)
            {
                renderer.material.color = Color.white;
            }
            else
            {
                renderer.material.color = flashColor;
            }

            flashTimeStamp = Time.time;
        }

    }
}



