using UnityEngine;
using System.Collections;



public class ObjectEventMaster : MonoBehaviour 
{
	
	public string[] sides;
	MessageGuy messageGuy;
	
	
	
	// Use this for initialization
	void Start () {
		sides = new string[]{"front", "back", "left", "right", "top", "bottom"};
		messageGuy = GameObject.Find("MessageGuy").GetComponent("MessageGuy") as MessageGuy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// gets ready to execute objectevents
	public void ExecuteTouchEvent (ObjectTouch anObjectTouch)
	{	
		
		
	    
	
		GameObject gO = anObjectTouch.GetTheGameObject();
		SidesList side = anObjectTouch.GetSideAffected();
		
		messageGuy.DisplayMessage("I'm touching the " + sides[(int)side] + " of the " + gO.name);
		
		
		
			
		
		
		
	}
	
	
}
