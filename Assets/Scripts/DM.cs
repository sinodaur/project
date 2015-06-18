using UnityEngine;
using System.Collections;
using MyGame.DataObjects;
using MyGame.PlayerInterface;
using MyGame.Static;

//This is the script for the DM of the game

namespace MyGame 
{

	public class DM : MonoBehaviour {
		
		GameObject player;
		GameObject playerControllerGO;
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
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		
		// fuction to notify DM of player pushing a non-movement button
		public void notifyPlayerRequest(string button)
		{
			// suspend player control until checked by DM
			playerController.stopObjectPlayerControl();
			// action key that was pressed
			if (button == "Fire1") seeWhatPlayerWants();
			
			// give control back to player
			playerController.startObjectPlayerControl();
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
		
		void OnDrawGizmos()
		{
			playerControllerGO = GameObject.Find("PlayerController");
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, playerControllerGO.transform.position);
		}
		
	}
}
