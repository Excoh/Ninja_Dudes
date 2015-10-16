using UnityEngine;
using System.Collections;

public class GuardSight : MonoBehaviour {

    FoV2DEyesMod eyes;
    FoV2DConeMod visionCone;

    void Start()
    {
        eyes = GetComponentInChildren<FoV2DEyesMod>();
        visionCone = GetComponentInChildren<FoV2DConeMod>();
    }

    void Update()
    {
        bool playerInView = false;
        //Check each Raycast
        foreach (RaycastHit2D hit in eyes.hits)
        {
            //Check if the raycast hit a player.
            if (hit.transform && hit.transform.tag == "Player")
            {
                playerInView = true;
                hit.transform.GetComponent<PlayerMovement>().SendMessage("wasSeenByGuard");
            }
        }

        //Changes the color of the field of view if it sees the player.
        if (playerInView)
        {
            visionCone.status = FoV2DConeMod.Status.Alert;
        }
        else
        {
            visionCone.status = FoV2DConeMod.Status.Idle;
        }
    }
}
