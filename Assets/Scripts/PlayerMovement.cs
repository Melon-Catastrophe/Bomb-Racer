using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float SPEED = 1000f;
    public float DEGROTATE = 0.5f;
    public float MAX_VELOCITY = 5000f;

    private void FixedUpdate()
    {
        
         if (Globals.isTouchingRoad)
        {
            if (Input.GetKey("w"))
            {
                if (playerRB.velocity.y > MAX_VELOCITY)
                {
                    playerRB.AddRelativeForce(0, -SPEED * Time.deltaTime, 0);
                }
                else { playerRB.AddRelativeForce(0, SPEED * Time.deltaTime, 0); }
            } else if (Input.GetKey("s"))
            {
                //playerRB.velocity = transform.forward * 5;
                playerRB.AddRelativeForce(0, -SPEED * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(DEGROTATE, 0, 0);
            if (Globals.isTouchingRoad)
            {
                playerRB.AddRelativeForce((float)(SPEED / 2 * Time.deltaTime), (float)(SPEED / 2 * Time.deltaTime), 0);
            }
        } else
        {
            // Move car in a straighter direction until it is straight. 
        } 
        if (Input.GetKey("d"))
        {
            transform.Rotate(-DEGROTATE, 0, 0);
            if (Globals.isTouchingRoad)
            {
                playerRB.AddRelativeForce((float)(SPEED / 2 * Time.deltaTime), (float)(SPEED / 2 * Time.deltaTime), 0);
            }
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Road")
        {
            Globals.isTouchingRoad = true;
        }
        else if (col.gameObject.name.IndexOf("Bomb") != -1)
        {
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Road")
        {
            Globals.isTouchingRoad = false;
        }
    }

    public static class Globals
    {
        public static bool isTouchingRoad = false;
    }
}
