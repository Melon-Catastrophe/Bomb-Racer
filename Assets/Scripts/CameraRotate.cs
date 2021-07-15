using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime); 
    }
}
