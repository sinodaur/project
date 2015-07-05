using UnityEngine;
using System.Collections;
using MyGame.DataObjects;
using MyGame.PlayerInterface;
using MyGame.Static;
using MyGame.EventManagment;
using MyGame.Messaging;

//This is the script for the DM of the game

namespace MyGame 
{

	public class DM : MonoBehaviour {
		
		GameObject player;
		GameObject playerControllerGO;
		ObjectEventMaster objectEventMaster;
		GameObject objectEventMasterGO;
		PlayerController playerController;
		MessageGuy messageGuy; 
		
		
		
		public bool[] globalFlags;
		
		
		
		
		
		// This class has central control over the game and all it's objects.
		void Start () 
		{	
			
			//find subordinates
			objectEventMasterGO = GameObject.Find("ObjectEventMaster");
			playerControllerGO = GameObject.Find("PlayerController");
			
			//initialize globalFlags for game event control
			globalFlags = new bool[128];
			
			// find the main player of the game
			player = GameObject.Find("Player");
			
			// get ahold of the PlayerController instance that gives control of GameObjects to the player
			playerController = playerControllerGO.GetComponent<PlayerController>();
			
			// tell the PlayerController to give control to the Player GameObject
			playerController.SetGameObject(player);
			playerController.StartObjectPlayerControl();	
			
			// get objectEventMaster for object event control
			objectEventMaster = objectEventMasterGO.GetComponent<ObjectEventMaster>();
			
			//get messageGuy
			messageGuy = GameObject.Find("MessageGuy").GetComponent("MessageGuy") as MessageGuy;
			
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
				objectEventMaster.ExecuteEvent(objectTouchedByPlayer);
				
			else
				playerController.StartObjectPlayerControl();
				
		}
		
		// draw lines in editor to highlight lines of communication and heirarchy of GOs
		void OnDrawGizmos()
		{
			playerControllerGO = GameObject.Find("PlayerController");
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, playerControllerGO.transform.position);
			
			objectEventMasterGO = GameObject.Find("ObjectEventMaster");
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, objectEventMasterGO.transform.position);
		}
		
	}
}
