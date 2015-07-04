using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	
	Camera theCamera;
	GameObject thePlayer;
	Vector3 playerPos; 
	
	
	// Use this for initialization
	void Start () {
		theCamera = this.GetComponent("Camera") as Camera;
		thePlayer = GameObject.Find("Player");
		playerPos = new Vector3();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerPos = thePlayer.transform.position;
		playerPos.Set(playerPos.x, playerPos.y + 19f, playerPos.z - 20f);
		transform.position = playerPos;		
	}
}
