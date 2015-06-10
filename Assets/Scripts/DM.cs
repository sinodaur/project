using UnityEngine;
using System.Collections;

//This is the script for the DM of the game

public class DM : MonoBehaviour {
	
	GameObject player;
	
	PlayerController playerController;
	
	
	// This class gives the DM GameObject central control over the game and all it's objects.
	void Start () 
	{
		// find the main player of the game
		player = GameObject.Find("Player");
		
		// get ahold of the PlayerController instance that gives control of GameObjects to the player
		playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
		
		// tell the PlayerController to give control to the Player GameObject
		playerController.setGameObject(player);
		playerController.startObjectPlayerControl();
		
		// start listening for requests
		InvokeRepeating("listenForPlayerRequest", 0f, 0.1F);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void stopListenForPlayerRequest()
	{
		CancelInvoke("listenForPlayerRequest");
	}
	
	void listenForPlayerRequest()
	{
		// listen for action key to be pressed
		if (Input.GetKey(KeyCode.Space)) seeWhatPlayerWants();
	}
	
	void seeWhatPlayerWants() 
	{
		// get the GameObject that PlayerController is currently giving control to player
		player = playerController.getGameObject();
		
		// get the touch information 
		ObjectTouch objectTouchedByPlayer = ObjectDetection.whatTouching(player);
		string side = objectTouchedByPlayer.getSideAffected();
		GameObject go = objectTouchedByPlayer.getTheGameObject();
		
		if (objectTouchedByPlayer.getTheGameObject() != null)
			Debug.Log("The " + side + " of the " + go + " game object is being touched" );
		else
			Debug.Log("Nothing is being touched" );
	}
}
