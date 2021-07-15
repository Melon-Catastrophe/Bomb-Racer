using UnityEngine;

public class RailingCollide : MonoBehaviour
{
    public Rigidbody currentRB;
    public float explosionForce = 10f;
    public float radius;
    public float upMotion;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerCar")
        {
            currentRB.AddExplosionForce(explosionForce, transform.position, radius, upMotion, ForceMode.Impulse);
        }
    }
}
