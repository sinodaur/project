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
		ObjectActionInfo objectTouchedByPlayer = ObjectDetection.whatTouching(player);
		string side = objectTouchedByPlayer.getSideAffected();
		GameObject go = objectTouchedByPlayer.getTheGameObject();
		
		if (objectTouchedByPlayer.getTheGameObject() != null)
			Debug.Log("The " + side + " of the " + go + " game object is being touched" );
		else
			Debug.Log("Nothing is being touched" );
	}
}
