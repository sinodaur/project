using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	

	DM dM;
	GameObject gObject;
	Rigidbody RBody;
	public float speed = 500f;
	public float drag = 20f;
	Vector3 playerOrientation = new Vector3();
	Vector3 playerStop = new Vector3();
	float timer;
	public bool moveEnabled;
	AllGLInstances GLS;
	float angleMod;
	 
	 
	// for keeping the action buttons from being continously held down by player
	bool buttonPress = false;
	 
	
	
	// control variable to shut-off/ turn-on access to player false by default
	
	void Start() 
	{
		dM = GLS.dM;
		
		moveEnabled = true;
	}
	
	public void SetGLInstances(AllGLInstances gls)
	{
		GLS = gls;
		
	}
	
	
	public void SetGameObject(GameObject go)
	{
		gObject = go;
	}
	public GameObject GetGameObject()
	{
		return gObject;
	}
	
	// Use this for contruction, gameObject must have RigidBody Component attached to work
	
	public void StartObjectPlayerControl ()
	{
		timer = Time.fixedTime + 1f;
		if (gObject != null) 
		{
			
			RBody = gObject.GetComponent<Rigidbody>();
			if (RBody != null) 
			{
				
				RBody.drag = drag;
				RBody.constraints = RigidbodyConstraints.FreezeRotationY | 
					RigidbodyConstraints.FreezeRotationX | 
						RigidbodyConstraints.FreezeRotationZ; //|
						//RigidbodyConstraints.FreezePositionY;
				
				InvokeRepeating("Movement", .05f, .05F);
					
			}
		}
	}
	
	public void StopObjectPlayerControl()
	{
		CancelInvoke("Movement");
		
		// need to freeze player object here.
		
		buttonPress = true;
		
	}
	
	void Movement() 
	{
		Debug.Log (timer < Time.fixedTime && !GLS.messageGuy.freezeMessage);
		if (GLS.messageGuy.freezeMessage) return;
		
		
			angleMod = GLS.cameraController.currentCamera.transform.eulerAngles.y;
			
			
			
			float upDown = Input.GetAxis ("Vertical");
			float leftRight = Input.GetAxis ("Horizontal");
			
			
			
			
			
				
			if (Input.GetButton("Fire1"))
			{
				if (!buttonPress) dM.NotifyPlayerRequest("Fire1");
				
			}
			else if (Input.GetButton("Fire2"))
			{
				if (!buttonPress) dM.NotifyPlayerRequest("Fire2");
			}
			else if (Input.GetButton("CameraLeft"))
			{
				if (!buttonPress) dM.NotifyPlayerRequest("CameraLeft");
			}
			else if (Input.GetButton("CameraRight"))
			{
				if (!buttonPress) dM.NotifyPlayerRequest("CameraRight");
			}
			else 
			{
				buttonPress = false;
			}
			
		
			if (upDown > 0 && leftRight < 0)
			{
				playerOrientation.y = 315f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight < 0 && upDown < 0)
			{
				playerOrientation.y = 225f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (upDown < 0 && leftRight > 0)
			{
				playerOrientation.y = 135f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight > 0 && upDown > 0)
			{
				playerOrientation.y = 45f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			
			else if (upDown > 0)
			{
				playerOrientation.y = 0.0f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (upDown < 0)
			{
				playerOrientation.y = 180f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight > 0)
			{
				playerOrientation.y  = 90f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight < 0)
			{
				playerOrientation.y  = 270f + angleMod;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else
			{
				RBody.velocity = playerStop;
			}
			
		
	
		
	
	}
	
	void moveALittle()
	{
		RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
	}

}

