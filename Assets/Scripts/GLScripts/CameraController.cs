using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	
	AllGLInstances GLS;
	GameObject currentCamera; 
	GameObject currentPlayer;
	Vector3 playerPos;
	
	
	// Use this for initialization
	void Start () {
		
		currentPlayer = GLS.dM.GetPlayer();
		playerPos = new Vector3();
		currentCamera = GameObject.Find("PlayerCamera");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		playerPos = currentPlayer.transform.position;
		playerPos.Set(playerPos.x, playerPos.y + 19f, playerPos.z - 20f);
		currentCamera.transform.position = playerPos;	
			
	}
	
	//get glinstances and initialize variables
	public void SetGLInstances(AllGLInstances gls)
	{
		GLS = gls;
		
	}
}
