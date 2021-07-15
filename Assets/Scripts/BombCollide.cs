using UnityEngine;
using UnityEngine.UI;

public class BombCollide : MonoBehaviour
{
    public Rigidbody currentRB;
    public float explosionForce;
    public float radius;
    public float upMotion;
    private float surpriseUpMotion = 1;
    private Score score;

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerCar")
        {
            Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();

            Globals.bombCounter++;
            score.addBomb(Globals.bombCounter);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                int hitIndex = hit.gameObject.name.IndexOf("Bomb");
                if (rb != null && hitIndex != 0)    // If there is a rigidbody that is not a bomb...
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius, upMotion, ForceMode.Impulse);
                }
            }

            currentRB.AddExplosionForce(explosionForce, transform.position, radius, upMotion, ForceMode.Impulse);
            
            int randomNum = 0;
            while (randomNum == 0)
            {
                randomNum = Random.Range(-1, 2);
            }
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, (float)(explosionForce) * randomNum, ForceMode.Impulse);
            //col.gameObject is currently set to PlayerCar

            randomNum = Random.Range(0, 10);
            //randomNum = 9;        // Used for debugging.
            if (randomNum == 9)
            {
                Debug.Log("Adding Force");
                
                //playerRB.AddRelativeForce(0, 100f, 0, ForceMode.Impulse);
                playerRB.AddExplosionForce(explosionForce, playerRB.position, radius, surpriseUpMotion, ForceMode.Impulse);
            }

        }

    }

    public static class Globals
    {
        public static int bombCounter = 0;
    }
}
