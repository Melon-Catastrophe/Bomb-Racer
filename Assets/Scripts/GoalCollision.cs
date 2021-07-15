using UnityEngine;

public class GoalCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {/*
        if (col.gameObject.name == "PlayerCar")
        {
            Debug.Log("Goal");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
