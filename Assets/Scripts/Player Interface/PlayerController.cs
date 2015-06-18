using UnityEngine;
using System.Collections;

namespace MyGame.PlayerInterface
{
	public class PlayerController : MonoBehaviour
	{
		
	
		 DM dM;
		 GameObject gObject;
		 Rigidbody RBody;
		 float speed = 500f;
		 Vector3 playerOrientation = new Vector3();
		 Vector3 playerStop = new Vector3();
		 
		 // for keeping the action buttons from being continously held down by player
		 bool buttonPress = false;
		 
		
		
		// control variable to shut-off/ turn-on access to player false by default
		
		void Start() 
		{
			dM = GameObject.Find("DM").GetComponent("DM") as DM;
			
		}
		
		
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
			buttonPress = true;
			
		}
		
		void Movement() 
		{
			
			float upDown = Input.GetAxis ("Vertical");
			float leftRight = Input.GetAxis ("Horizontal");
			
			
			
			
			
				
			if (Input.GetButton("Fire1"))
			{
				if (!buttonPress) dM.notifyPlayerRequest("Fire1");
				
			}
			else 
			{
				buttonPress = false;
			}
			
		
			if (upDown > 0 && leftRight < 0)
			{
				playerOrientation.y = 315f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight < 0 && upDown < 0)
			{
				playerOrientation.y = 225f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (upDown < 0 && leftRight > 0)
			{
				playerOrientation.y = 135f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight > 0 && upDown > 0)
			{
				playerOrientation.y = 45f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			
			else if (upDown > 0)
			{
				playerOrientation.y = 0.0f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (upDown < 0)
			{
				playerOrientation.y = 180f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight > 0)
			{
				playerOrientation.y  = 90f;
				gObject.transform.eulerAngles = playerOrientation;
				moveALittle();
			}
			else if (leftRight < 0)
			{
				playerOrientation.y  = 270f;
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
}
