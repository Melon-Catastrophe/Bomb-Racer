using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "PlayerCar")
        {
            rb = GetComponent<Rigidbody>();
            rb.AddTorque(0, 90, 0);
            gameManager.CompleteLevel();
        }
        
    }
}
