using UnityEngine;
using System.Collections;


//This is the script for the DM of the game


public class DM : MonoBehaviour {
	
	public GameObject player;
	CameraController cameraController;
	DM dM;
	ObjectEventMaster objectEventMaster;
	PlayerController playerController;
	MessageGuy messageGuy;
	public AllGLInstances allGLInstances; 
	Light playerLight;
	
	Texture texture;
	Texture2D texture2D;
	
	
	
	
	public bool[] globalFlags;
	
	
	
	
	
	// This class is central gl
	void OnEnable () 
	{	
		// find the main player of the game
		player = GameObject.Find("Player");
		
		// initialize subordinate game logic scripts
		playerController = GameObject.Find("PlayerController").AddComponent<PlayerController>();
		objectEventMaster = GameObject.Find("ObjectEventMaster").AddComponent<ObjectEventMaster>();
		messageGuy = GameObject.Find("MessageGuy").AddComponent<MessageGuy>();
		cameraController = GameObject.Find("CameraController").AddComponent<CameraController>();
		dM = this.GetComponent<DM>();
		
	
		//initialize AllGLInstances
		allGLInstances = 
			new AllGLInstances(dM,cameraController,objectEventMaster,messageGuy,playerController);
		
		//give allGLInstances to other class instances
		cameraController.SetGLInstances(allGLInstances);
		
		
		//initialize globalFlags for game event control
		globalFlags = new bool[128];
		
		
		
		// get ahold of the PlayerController instance that gives control of GameObjects to the player
		playerController.SetGLInstances(allGLInstances);
		
		
		// tell the PlayerController to give control to the Player GameObject
		playerController.SetGameObject(player);
		playerController.StartObjectPlayerControl();	
		
	
		
		//get messageGuy
		//messageGuy = GameObject.Find("MessageGuy").GetComponent("MessageGuy") as MessageGuy;
		
		//get players light
		playerLight = GameObject.Find("PlayerLight").GetComponent("Light") as Light;
		
		
		//texture = GameObject.Find("RenderTextureCamera").GetComponent<Camera>().targetTexture;
		//texture2D = new Texture2D(32,32);
		//StartCoroutine(getTexture());
		
		//Debug.Log (texture.name + " and " + texture2D.name);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	// fuction to notify DM of player pushing a non-movement button
	public void NotifyPlayerRequest(string button)
	{
		// suspend player control until checked by DM
		playerController.StopObjectPlayerControl();
		// action key that was pressed
		if (button == "Fire1") SeeWhatPlayerWants();
		else if (button == "Fire2")
		{
			if (playerLight.enabled == true) playerLight.enabled = false;
			else  playerLight.enabled = true;
			playerController.StartObjectPlayerControl();
		}	
		else if (button == "CameraLeft")
		{
			cameraController.rotateLeft90();
			//playerController.StartObjectPlayerControl();
		}
		else if (button == "CameraRight")
		{
			
			cameraController.rotateRight90();
			//playerController.StartObjectPlayerControl();
		}		
		
		//give control back to player
		
	}
	
	void SeeWhatPlayerWants() 
	{
		// get the GameObject that PlayerController is currently giving control to player
		player = playerController.GetGameObject();
		
		// get the touch information 
		ObjectTouch objectTouchedByPlayer = ObjectDetection.WhatTouching(player);

		// if not null send the ObjectTouch to ObjectEventMaster to handle
		if (objectTouchedByPlayer.GetTheGameObject() != null)
			objectEventMaster.ExecuteTouchEvent(objectTouchedByPlayer);
			
		else
			playerController.StartObjectPlayerControl();
			
	}
	
	public GameObject GetPlayer()
	{
		return player;
	}
	
	//IEnumerator getTexture()
	//{
	//	yield return new WaitForEndOfFrame();
	//	texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
	//	texture2D.Apply();
	//}
//	
//	// draw lines in editor to highlight lines of communication and heirarchy of GOs
//	void OnDrawGizmos()
//	{
//		playerControllerGO = GameObject.Find("PlayerController");
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawLine(transform.position, playerControllerGO.transform.position);
//		
//		objectEventMasterGO = GameObject.Find("ObjectEventMaster");
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawLine(transform.position, objectEventMasterGO.transform.position);
//	}
//	
}

