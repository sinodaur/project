using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	
	AllGLInstances GLS;
	GameObject currentCamera; 
	GameObject currentPlayer;
	Vector3 playerPos;
	float currentAngle;
	float x;
	float z;
	float cameraHeight;
	float cameraDistance;
	Vector3 cameraPos;
	
	
	
	// Use this for initialization
	void Start () {
		
		currentAngle = 180f;
		currentPlayer = GLS.dM.GetPlayer();
		playerPos = new Vector3();
		
		currentCamera = GameObject.Find("PlayerCamera");
		cameraHeight = 19f;
		cameraDistance = 20f;
		cameraPos = new Vector3(playerPos.x, playerPos.y + cameraHeight, playerPos.z - cameraDistance);
		
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		playerPos = currentPlayer.transform.position;
		x = playerPos.x;
		z = playerPos.z;
		cameraPos.Set(x + Mathf.Sin (Mathf.Deg2Rad * currentAngle) * cameraDistance,
		              playerPos.y + cameraHeight, 
		              z + Mathf.Cos (Mathf.Deg2Rad * currentAngle) * cameraDistance);
		currentCamera.transform.position = cameraPos;
		
	
	}
	
	//get glinstances and initialize variables
	public void SetGLInstances(AllGLInstances gls)
	{
		GLS = gls;
		
	}
	
	public void rotateLeft90()
	{
		currentCamera.transform.eulerAngles = new Vector3 (currentCamera.transform.eulerAngles.x, currentCamera.transform.eulerAngles.y + 1f ,currentCamera.transform.eulerAngles.z); 
		
		InvokeRepeating("MoveCameraLeft", .02f, .02f);	
	}
	
	public void rotateRight90()
	{
		currentCamera.transform.eulerAngles = new Vector3 (currentCamera.transform.eulerAngles.x, currentCamera.transform.eulerAngles.y - 1f ,currentCamera.transform.eulerAngles.z); 
		InvokeRepeating("MoveCameraRight", .02f, .02f);
	}
	
	void MoveCameraLeft()
	{
		currentAngle += 1f;
	    currentCamera.transform.eulerAngles = new Vector3 (currentCamera.transform.eulerAngles.x, currentCamera.transform.eulerAngles.y + 1f ,currentCamera.transform.eulerAngles.z);
		if ((int)currentCamera.transform.eulerAngles.y % 90 == 0)
		{
			GLS.playerController.StartObjectPlayerControl();
			CancelInvoke("MoveCameraLeft");
			
		}	
			
		
	}
	void MoveCameraRight()
	{
		currentAngle -= 1f;
		currentCamera.transform.eulerAngles = new Vector3 (currentCamera.transform.eulerAngles.x, currentCamera.transform.eulerAngles.y - 1f ,currentCamera.transform.eulerAngles.z);
		if ((int)currentCamera.transform.eulerAngles.y % 90 == 0)
		{
			GLS.playerController.StartObjectPlayerControl();
			CancelInvoke("MoveCameraRight");
				
		}
	}
	
}
