using UnityEngine;
//using System.Collections;

public class FollowPlayer : MonoBehaviour
{

	public Transform player;
	public Vector3 vectorOffset;
	public Vector3 rotateOffset;
	public GameObject behindCamera;
	private Vector3 velocity = Vector3.zero;

	public float smoothTime = 0.3f;


	//private Vector3 target = new Vector3(5.0f, 0.0f, 0.0f);

	// Update is called once per frame
	private void Start()
    {
		behindCamera = GameObject.Find("behindCamera");
		transform.eulerAngles = rotateOffset;
    }

    void FixedUpdate()
	{
		Quaternion playerRotation = player.rotation;
		// Sets position of camera to players' position plus the offset.

		

		//		transform.RotateAround(player.transform.position, Vector3.up, 50 * Time.deltaTime);

		//		//vectorOffset = transform.position - player.position;
		//transform.position = player.localPosition + vectorOffset;
		//		//		//Debug.Log(player.position);



		//transform.eulerAngles += 5 * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);



		//cameraBehavior();
		transform.position = player.localPosition + vectorOffset;
		Vector3 targetPosition = player.TransformDirection(new Vector3(0, 0, -10));

		
		

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		//transform.LookAt(player);

	}

	private void cameraBehavior()
    {
		
    }
}