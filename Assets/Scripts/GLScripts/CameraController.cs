using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	
	AllGLInstances GLS;
	GameObject currentCamera; 
	GameObject currentPlayer;
	Vector3 playerPos;
	float currentAngle;
	float x;
	float y;
	float cameraHeight;
	float cameraDistance;
	Vector3 cameraPos;
	
	
	
	// Use this for initialization
	void Start () {
		
		currentAngle = 0f;
		currentPlayer = GLS.dM.GetPlayer();
		playerPos = new Vector3();
		currentCamera = GameObject.Find("PlayerCamera");
		cameraHeight = 19f;
		cameraDistance = 20f;
		//playerPos = currentPlayer.transform.position;
		//cameraPos = new Vector3(playerPos.x, playerPos.y + cameraHeight, playerPos.z - cameraDistance);
		//currentCamera.transform.position = cameraPos;
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		playerPos = currentPlayer.transform.position;
		playerPos.Set(playerPos.x, playerPos.y + cameraHeight, playerPos.z - cameraDistance);
		currentCamera.transform.position = playerPos;	
			
	}
	
	//get glinstances and initialize variables
	public void SetGLInstances(AllGLInstances gls)
	{
		GLS = gls;
		
	}
	
	public void rotateLeft90()
	{
		
		x = playerPos.x;
		y = playerPos.z;
		
		currentAngle += 90f;
		
		Vector3 pos = new Vector3(x + Mathf.Sin (Mathf.Deg2Rad * currentAngle) * cameraDistance,
		                                         cameraPos.y, 
		                                         y + Mathf.Cos (Mathf.Deg2Rad * currentAngle) * cameraDistance);
		Vector3 epos = new Vector3(currentCamera.transform.eulerAngles.x, currentCamera.transform.eulerAngles.y - 180f, currentCamera.transform.eulerAngles.z);                                        
		currentCamera.transform.position = pos;
		currentCamera.transform.eulerAngles = epos;
		
	}
	
	public void rotateRight90()
	{
		
	}
	
}
