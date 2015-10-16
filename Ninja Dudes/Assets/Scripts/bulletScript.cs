using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public Rigidbody2D projectile;
    public float speed = 15f;
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
            Destroy(this.gameObject);
            //Kills the player
            other.gameObject.GetComponent<PlayerLife>().killed = true;
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
