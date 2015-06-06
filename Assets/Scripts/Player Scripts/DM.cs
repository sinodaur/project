using UnityEngine;
using System.Collections;

//This is the script for the DM of the game

public class DM : MonoBehaviour {
	
	GameObject player;
	
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("listenForPlayerRequest", 0f, 0.1F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void listenForPlayerRequest()
	{
		if (Input.GetKey(KeyCode.Space)) seeWhatPlayerWants();
	}
	
	void seeWhatPlayerWants() 
	{
		player = GameObject.Find("Player");
		ObjectDetection.whatTouching(player);
	}
}
