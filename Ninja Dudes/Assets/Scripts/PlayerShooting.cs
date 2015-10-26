using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class PlayerShooting : MonoBehaviour {

    public int PlayerNumber;
    public GameObject projectile;
    public GameObject muzzle;
    public float speed = 10f;
    public float cooldownTimeSecs = 1f;
    float timeStamp;

    // Use this for initialization
    void Start () {
        timeStamp = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        //If enough time has past, player can shoot again.
        if (timeStamp <= Time.time)
        {
            //Xbox Controller (works with all players)
            if(XCI.GetButton(XboxButton.A, PlayerNumber))
            {
                fire();
            }

            //Debug mode
            if (PlayerNumber == 1)
            {
                if (Input.GetButtonDown("Player1Fire"))
                {
                    fire();
                }
            }
            if (PlayerNumber == 2)
            {
                if (Input.GetButtonDown("Player2Fire"))
                {
                    fire();
                }
            }
            if (PlayerNumber == 3)
            {
                if (Input.GetButtonDown("Player3Fire"))
                {
                    fire();
                }
            }
            if (PlayerNumber == 4)
            {
                if (Input.GetButtonDown("Player4Fire"))
                {
                    fire();
                }
            }
        }
    }

    //Fires projectile
    void fire()
    {
        timeStamp = Time.time + cooldownTimeSecs;
        GameObject projectile_clone;

        projectile_clone = Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
        projectile.GetComponent<bulletScript>().playerNumber = PlayerNumber;
        projectile_clone.transform.parent = this.gameObject.transform;

        //retrieve the direction of the player
        float angle = this.gameObject.GetComponentInParent<PlayerMovement>().angle;
        //The direction of the projectile when shot
        Vector2 dir;
        if(angle >= 0 && angle < 90)
        {
            dir = new Vector2(0,1);
        }
        else if (angle < 0 && angle >= -90)
        {
            dir = new Vector2(1, 0);
        }
        else if (angle >= 90)
        {
            dir = new Vector2(-1, 0);
        }
        else
        {
            dir = new Vector2(0, -1);
        }
        projectile_clone.GetComponent<Rigidbody2D>().velocity = dir * speed;
        projectile_clone.transform.parent = null;
    }
}
