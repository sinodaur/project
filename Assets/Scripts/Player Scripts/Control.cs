using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{
	
	private Rigidbody RBody;
	private float speed = 500f;
	private Vector3 playerOrientation = new Vector3();
	private Vector3 playerStop = new Vector3();
	
	
	// Use this for initialization
	void Start () {
		RBody = GetComponent<Rigidbody>();
		RBody.drag = 20;
		RBody.constraints = RigidbodyConstraints.FreezeRotationY | 
			RigidbodyConstraints.FreezeRotationX | 
			RigidbodyConstraints.FreezeRotationZ |
			RigidbodyConstraints.FreezePositionY;
		InvokeRepeating("Movement", .05f, 0.05F);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void Movement() 
	{
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
		{
			
			playerOrientation.y = 315f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
		{
			
			playerOrientation.y = 225f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			
			playerOrientation.y = 135f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
		{
			
			playerOrientation.y = 45f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		
		else if (Input.GetKey(KeyCode.W))
		{
			
			playerOrientation.y = 0.0f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			
			playerOrientation.y = 180f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			
			playerOrientation.y  = 90f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			
			playerOrientation.y  = 270f;
			transform.eulerAngles = playerOrientation;
			RBody.velocity += transform.forward * speed * Time.deltaTime;
			
		}
		else
		{
			RBody.velocity = playerStop;
		}
	}
}
