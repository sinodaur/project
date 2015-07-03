using UnityEngine;
using System.Collections;
using MyGame.Enums;
using UnityEngine.UI;
using MyGame.PlayerInterface;

namespace MyGame.Messaging
{
	
	

	public class MessageGuy : MonoBehaviour
	{
		GameObject messageBoard;
		Camera boardCamera;
		Text boardText;
		PlayerController playerController;
		
		
		
		
		
		// Use this for initialization
		void Start () 
		{	
			
			messageBoard = GameObject.Find("MessageBoard");
			boardCamera = GameObject.Find("MessageBoardCamera").GetComponent("Camera") as Camera;
			boardCamera.enabled = false;
			boardText = GameObject.Find("MessageBoardText").GetComponent("Text") as Text;
			playerController = 
				GameObject.Find("PlayerController").GetComponent("PlayerController") 
				as PlayerController;
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
		
		public void DisplayMessage (string message)
		{
			
			boardText.text = message;
			boardCamera.enabled = true;
			//Debug.Log("Nothing is being touched");
			InvokeRepeating("WaitForPlayerToRead", .5f, 0.05F);
		}
		
		void WaitForPlayerToRead()
		{
			if (Input.GetButton("Fire1")) EraseMessage();
		}
		
		void EraseMessage()
		{	
			CancelInvoke("WaitForPlayerToRead");
			boardCamera.enabled = false;
			playerController.StartObjectPlayerControl();
		}
	}
}
