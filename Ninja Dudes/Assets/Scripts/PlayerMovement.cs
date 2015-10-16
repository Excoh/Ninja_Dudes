﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int PlayerNumber;
	private float speed = 5f;
    public float reducedSpeed = 2f;
    public float normalSpeed = 5f;
    public float angle;
    bool[] canMove; //[left,right,up,down]
    bool wasSeen;
    public float cooldownTimeSecs = 2;
    float timeStamp;

    // Use this for initialization
    void Start () {
        wasSeen = false;
        canMove = new bool[] { true, true, true, true };
        speed = normalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        //True if the player is out of enemy sight for cool down amount of time.
        if (wasSeen == true && timeStamp <= Time.time)
        {
            safeFromGuard();
        }

        //Used to determine the rotation of the sprite.
		Vector3 _origPos = transform.position;

        //Player 1 controls
        if (PlayerNumber == 1) {
			if (Input.GetButton ("Player1Up") && canMove[2]){
				transform.position += new Vector3 (0, 1, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[1] = true;
                canMove[3] = true;
            } else if (Input.GetButton ("Player1Down") && canMove[3]) {
				transform.position += new Vector3 (0, -1, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[1] = true;
                canMove[2] = true;
            } else if (Input.GetButton ("Player1Left") && canMove[0]) {
				transform.position += new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
                canMove[1] = true;
                canMove[2] = true;
                canMove[3] = true;
            } else if (Input.GetButton ("Player1Right") && canMove[1]) {
				transform.position += new Vector3 (1, 0, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[2] = true;
                canMove[3] = true;
            }
		}

        //Player 2 controls
        if (PlayerNumber == 2)
        {
            if (Input.GetButton("Player2Up") && canMove[2])
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[1] = true;
                canMove[3] = true;
            }
            else if (Input.GetButton("Player2Down") && canMove[3])
            {
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[1] = true;
                canMove[2] = true;
            }
            else if (Input.GetButton("Player2Left") && canMove[0])
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                canMove[1] = true;
                canMove[2] = true;
                canMove[3] = true;
            }
            else if (Input.GetButton("Player2Right") && canMove[1])
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                canMove[0] = true;
                canMove[2] = true;
                canMove[3] = true;
            }
        }

        Vector3 moveDirection = transform.position - _origPos; 
        //Determine the rotation of the sprite.
		if (moveDirection != Vector3.zero) 
		{
			angle = Mathf.Round(Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90; //-90 needed as the rotation of the sprite is offset by 90 degree.
			transform.rotation = Quaternion.AngleAxis(angle , Vector3.forward);
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //Forces player to stop moving once flushed against the wall
            if (angle == -180)
            {
                canMove[3] = false;
            }
            if (angle == -90)
            {
                canMove[1] = false;
            }
            if (angle == 0)
            {
                canMove[2] = false;
            }
            if (angle == 90)
            {
                canMove[0] = false;
            }
        }

    }

    //Called in GuardSight.cs in the guard prefab
    //Slow speed to reduced speed and change the sprite tint to blue.
    void wasSeenByGuard()
    {
        wasSeen = true;
        speed = reducedSpeed;
        timeStamp = Time.time + cooldownTimeSecs;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    //Turns speed to normal and sprite tint to normal.
    void safeFromGuard()
    {
        speed = normalSpeed;
        wasSeen = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}