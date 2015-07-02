using UnityEngine;
using System.Collections;
using MyGame.Enums;

namespace MyGame.Messaging
{
	
	

	public class MessageGuy : MonoBehaviour
	{
		GameObject messageBoard;
		Camera boardCamera;
		
		
		
		
		// Use this for initialization
		void Start () 
		{
			messageBoard = GameObject.Find("MessageBoard");
			boardCamera = GameObject.Find("MessageBoardCamera").GetComponent("Camera") as Camera;
			Debug.Log(boardCamera.name);
			boardCamera.enabled = false;
			//boardCamera.enabled = false;
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
		
		public void DisplayMessage (string message)
		{
			boardCamera.enabled = true;
			Debug.Log("Nothing is being touched");
		} 
	}
}
