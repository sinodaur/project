using UnityEngine;
using System.Collections;



public class ObjectEventMaster : MonoBehaviour 
{
	
	public string[] sides;
	MessageGuy messageGuy;
	AllGLInstances GLS;
	DM dm;
	
	
	// Use this for initialization
	void Start () {
		sides = new string[]{"front", "back", "left", "right", "top", "bottom"};
		messageGuy = GameObject.Find("MessageGuy").GetComponent("MessageGuy") as MessageGuy;
		dm = GameObject.Find("DM").GetComponent<DM>();
		GLS = dm.allGLInstances;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// gets ready to execute objectevents
	public void ExecuteTouchEvent (ObjectTouch anObjectTouch)
	{	
		GameObject gO = anObjectTouch.GetTheGameObject();
		SidesList side = anObjectTouch.GetSideAffected();
		
		if (anObjectTouch.isLit == true)
		{
			switch (anObjectTouch.theGameObject.name)
			{
				case "FlatScreen":
					anObjectTouch.theGameObject.GetComponent<FlatScreen>().Interact(anObjectTouch);
					
					break;
				default:
					messageGuy.DisplayMessage("I, " + anObjectTouch.thePlayer.name +
						" am touching the " + sides[(int)side] + " of the " + gO.name);
					GLS.playerController.StartObjectPlayerControl();
					break;
			}
			
		}
		else
		{
			messageGuy.DisplayMessage("I, " + anObjectTouch.thePlayer.name +
			 " am touching something but I can't see it.");
			GLS.playerController.StartObjectPlayerControl();
		}
		
	}
	
	 
	
	
}
