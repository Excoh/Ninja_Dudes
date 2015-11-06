using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FoV2DEyesMod : MonoBehaviour
{
    public bool raysGizmosEnabled;
    //public float updateRate = 0.02f;
    public int quality = 4; //The number of raycast made.
    public int fovAngle = 90; //The angle of the field of view
    public float fovMaxDistance = 15; //How far the enemy can see
    public LayerMask cullingMask; //The layer the enemy can see
    public List<RaycastHit2D> hits = new List<RaycastHit2D>();

    int numRays;
    float currentAngle;
    Vector2 direction;
    RaycastHit2D hit;

    void Update()
    {
        CastRays();
    }

    //Casting a list of raylist at different angles along the field of angle vision.
    void CastRays()
    {
        numRays = fovAngle * quality;
        currentAngle = fovAngle / -2;

        hits.Clear();

        for (int i = 0; i < numRays; i++)
        {
            //Determine the angle at which the raycast should be shooting from.
            Vector3 temp = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
            direction = new Vector2(temp.x, temp.y);

            hit = new RaycastHit2D();
            //Checks if raycast is hitting an object between 0.1 < z < 1
            hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, fovMaxDistance, cullingMask, 0.1f, 1);
            if (!hit)
            {
                //create the raycast up until it is flush with the object. Which makes the guard not see "behind" walls.
                hit.point = new Vector2(transform.position.x, transform.position.y) + (direction * fovMaxDistance);
            }

            hits.Add(hit);

            //to check every raycast that was made in the field of view.
            currentAngle += 1f / quality;
        }
    }

    //Used for debugging purposes.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        if (raysGizmosEnabled && hits.Count() > 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                Gizmos.DrawSphere(hit.point, 0.04f);
                Gizmos.DrawLine(transform.position, hit.point);
            }
        }
    }

}

