using UnityEngine;
using System.Collections;

public class GuardMovementPath : MonoBehaviour {

    public GameObject[] beacons;
    public float speed = 1f;
    private int numOfBeacons;
    private int headingTowardThisBeacon;
    private bool reversePath;
    public float angle;

	// Use this for initialization
	void Start () {
        numOfBeacons = beacons.Length;
        headingTowardThisBeacon = 1;
        reversePath = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 _origPos = transform.position;

        //If guard is within a certain distance of the beacon, it moves to the next beacon.
        if (Vector2.Distance(this.transform.position, beacons[headingTowardThisBeacon].transform.position) < .05)
        {
            nextBeacon();
        }
        else
        {
            this.transform.position += (beacons[headingTowardThisBeacon].transform.position - this.transform.position).normalized * speed * Time.deltaTime;
        }

        //Rotates the direction at which the sprite is facing
        Vector3 moveDirection = transform.position - _origPos;
        if (moveDirection != Vector3.zero)
        {
            angle = Mathf.Round(Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    //Iterates through the list of beacons and once it hits the end of the list. It reverses.
    void nextBeacon()
    {
        if(headingTowardThisBeacon == (numOfBeacons - 1))
        {
            reversePath = true;
        }
        if(headingTowardThisBeacon == 0)
        {
            reversePath = false;
        }

        if (reversePath)
        {
            headingTowardThisBeacon--;
        }
        else
        {
            headingTowardThisBeacon++;
        }

    }
}
