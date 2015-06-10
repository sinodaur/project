using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	

	private GameObject gObject;
	private Rigidbody RBody;
	private float speed = 500f;
	private Vector3 playerOrientation = new Vector3();
	private Vector3 playerStop = new Vector3();
	
	
	// control variable to shut-off/ turn-on access to player false by default
	
	
	public void setGameObject(GameObject go)
	{
		gObject = go;
	}
	public GameObject getGameObject()
	{
		return gObject;
	}
	
	// Use this for contruction, gameObject must have RigidBody Component attached to work
	
	public void startObjectPlayerControl ()
	{
		
		if (gObject != null) 
		{
			
			RBody = gObject.GetComponent<Rigidbody>();
			if (RBody != null) 
			{
				
				RBody.drag = 20;
				RBody.constraints = RigidbodyConstraints.FreezeRotationY | 
					RigidbodyConstraints.FreezeRotationX | 
						RigidbodyConstraints.FreezeRotationZ |
						RigidbodyConstraints.FreezePositionY;
				
				InvokeRepeating("Movement", .05f, 0.05F);
					
			}
		}
	}
	
	public void stopObjectPlayerControl()
	{
		CancelInvoke("Movement");
	}
	
	private void Movement() 
	{
		
		
	
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
		{
			
			playerOrientation.y = 315f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
		{
			
			playerOrientation.y = 225f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{
			
			playerOrientation.y = 135f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
		{
			
			playerOrientation.y = 45f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		
		else if (Input.GetKey(KeyCode.W))
		{
			
			playerOrientation.y = 0.0f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			
			playerOrientation.y = 180f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			
			playerOrientation.y  = 90f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			
			playerOrientation.y  = 270f;
			gObject.transform.eulerAngles = playerOrientation;
			RBody.velocity += gObject.transform.forward * speed * Time.deltaTime;
			
		}
		else
		{
			RBody.velocity = playerStop;
		}
	
		
	
	}

}
