using UnityEngine;
using System.Collections;
using UnityEngine.UI;



	

public class MessageGuy : MonoBehaviour
{
	//GameObject messageBoard;
	public Camera boardCamera;
	Text boardText;
	PlayerController playerController;
	float timer;
	public bool freezeMessage;
	
	
	
	
	// Use this for initialization
	void Start () 
	{	
		freezeMessage = false;
		//messageBoard = GameObject.Find("MessageBoard");
		boardCamera = GameObject.Find("MessageBoardCamera").GetComponent("Camera") as Camera;
		boardCamera.enabled = false;
		boardText = GameObject.Find("MessageBoardText").GetComponent("Text") as Text;
		playerController = 
			GameObject.Find("PlayerController").GetComponent("PlayerController") 
			as PlayerController;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{	Debug.Log (Input.GetButton("Fire1"));
		if (boardCamera.enabled == true)
			if (Time.fixedTime > timer && Input.GetButton("Fire1") == true)
				EraseMessage();
		
		
	}
	
	public void DisplayMessage (string message)
	{
		boardText.text = message;
		if (!boardCamera.enabled) timer = Time.fixedTime + .5f;
		boardCamera.enabled = true;
		freezeMessage = true;
		
		
	}
	
	
	
	void EraseMessage()
	{	
		
		boardCamera.enabled = false;
		freezeMessage = false;
		
	}
}

