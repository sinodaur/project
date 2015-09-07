using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	
	AllGLInstances GLS;
	float distance;
	Vector3 direction;
	Vector3 heading;
	Vector3 cameraAxis;
	public Transform cameraTransform;
	Transform playerTransform;
	public bool rotateLeft;
	public bool rotateRight;
	float startAngle;
	
	// Use this for initialization
	void Start () 
	{
		cameraTransform = GameObject.Find("PlayerCamera").transform;
		playerTransform = GameObject.Find("Player").transform;
		
		cameraTransform.position = new Vector3(playerTransform.position.x,
			playerTransform.position.y + 10, playerTransform.position.z - 10);
			
		cameraAxis = new Vector3(0,10,0) + playerTransform.position;
		heading = cameraTransform.position - playerTransform.position;
		distance = heading.magnitude;
		direction = heading / distance;
		
		rotateLeft = false;
		rotateRight = false;
		startAngle = cameraTransform.eulerAngles.y;
		Debug.Log (startAngle);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		cameraAxis = new Vector3(0,10,0) + playerTransform.position;
		
		if (rotateLeft)
		{
			MoveLeft90();
		}
		else if (rotateRight)
		{	
			MoveRight90();
		}
		else 
		{
			cameraTransform.position = playerTransform.position + heading; 
		}
		
	}
	
	//get glinstances and initialize variables
	public void SetGLInstances(AllGLInstances gls)
	{
		GLS = gls;
		
	}
	
	public void rotateLeft90()
	{
		rotateLeft = true;
	}
	
	public void rotateRight90()
	{
		rotateRight = true;
	}
	
	void MoveLeft90()
	{
		cameraTransform.RotateAround(cameraAxis, Vector3.up, 80 * Time.deltaTime);
		if (startAngle != 270)
		{
			if ((int)cameraTransform.eulerAngles.y > startAngle + 90)
			{
				startAngle = startAngle + 90f;
				cameraTransform.eulerAngles = 
					new Vector3(cameraTransform.eulerAngles.x, startAngle, 
					            cameraTransform.eulerAngles.z);
				heading = cameraTransform.position - playerTransform.position;
				rotateLeft = false;
				GLS.playerController.StartObjectPlayerControl();		
			}
		}
		else 
		{	
			if ((int)cameraTransform.eulerAngles.y < 270 && (int)cameraTransform.eulerAngles.y > 0 ) 
			{
				
				
				startAngle = 0f;
				cameraTransform.eulerAngles = 
					new Vector3(cameraTransform.eulerAngles.x, startAngle, 
					            cameraTransform.eulerAngles.z);
				heading = cameraTransform.position - playerTransform.position;
				rotateLeft = false;	
				GLS.playerController.StartObjectPlayerControl();	
			}
		}
		
		
	}
	
	void MoveRight90()
	{
		cameraTransform.RotateAround(cameraAxis, Vector3.up, -80 * Time.deltaTime);
		if (startAngle == 180 || startAngle == 270)
		{
			if ((int)cameraTransform.eulerAngles.y < startAngle - 90)
			{
				startAngle = startAngle - 90f;
				cameraTransform.eulerAngles = 
					new Vector3(cameraTransform.eulerAngles.x, startAngle, 
					            cameraTransform.eulerAngles.z);
				heading = cameraTransform.position - playerTransform.position;
				rotateRight = false;
				GLS.playerController.StartObjectPlayerControl();		
			}
		}
		else if (startAngle == 90)
		{
			if ((int)cameraTransform.eulerAngles.y < 360 && (int)cameraTransform.eulerAngles.y > 90)
			{
				startAngle = startAngle - 90f;
				cameraTransform.eulerAngles = 
					new Vector3(cameraTransform.eulerAngles.x, startAngle, 
					            cameraTransform.eulerAngles.z);
				heading = cameraTransform.position - playerTransform.position;
				rotateRight = false;
				GLS.playerController.StartObjectPlayerControl();		
			}
		}
		else 
		{	
			if ((int)cameraTransform.eulerAngles.y < 270 && (int)cameraTransform.eulerAngles.y > 0 ) 
			{
				
				
				startAngle = 270f;
				cameraTransform.eulerAngles = 
					new Vector3(cameraTransform.eulerAngles.x, startAngle, 
					            cameraTransform.eulerAngles.z);
				heading = cameraTransform.position - playerTransform.position;
				rotateRight = false;	
				GLS.playerController.StartObjectPlayerControl();	
			}
		}
	}
	
}
