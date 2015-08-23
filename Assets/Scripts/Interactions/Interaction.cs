using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	
	
	protected AllGLInstances GLS;
	protected DM dm; 
	protected int steps;
	protected string touchtype;
	protected int step;
	protected ObjectTouch objtouch;
	
	protected virtual void Start()
	{
		dm = GameObject.Find("DM").GetComponent<DM>();
		GLS = dm.allGLInstances;
		touchtype = "";
	}
	
	protected virtual void FixedUpdate()
	{
		if (touchtype != "")
			Debug.Log ("fixedupdate");
			Debug.Log (touchtype);
			Debug.Log (step);
			switch (touchtype)
			{
			case ("front"):
				frontTouch(objtouch);
				break;
			case ("back"):
				backTouch(objtouch);
				break;	
			case ("right"):
				rightTouch(objtouch);
				break;
			case ("left"):
				leftTouch(objtouch);
				break;
			case ("bottom"):
				bottomTouch(objtouch);
				break;	
			case ("top"):
				topTouch(objtouch);
				break;
			}
	}
	
	public virtual void Interact(ObjectTouch ot)
	{
		objtouch = ot;
		touchtype = ot.sideAffectedString;
		step = 0;
		switch (touchtype)
		{
			case ("front"):
				frontTouch(objtouch);
				break;
			case ("back"):
				backTouch(objtouch);
				break;	
			case ("right"):
				rightTouch(objtouch);
				break;
			case ("left"):
				leftTouch(objtouch);
				break;
			case ("bottom"):
				bottomTouch(objtouch);
				break;	
			case ("top"):
				topTouch(objtouch);
				break;
			
		}
	}
	
	protected virtual void frontTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = "";                         
		GLS.playerController.StartObjectPlayerControl();
	}
	protected virtual void backTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = ""; 
		GLS.playerController.StartObjectPlayerControl();
	}
	protected virtual void leftTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = ""; 
		GLS.playerController.StartObjectPlayerControl();
	}
	protected virtual void rightTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = ""; 
		GLS.playerController.StartObjectPlayerControl();
	}
	protected virtual void bottomTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = ""; 
		GLS.playerController.StartObjectPlayerControl();
	}
	protected virtual void topTouch(ObjectTouch ot)
	{
//		GLS.messageGuy.DisplayMessage("I, " + ot.thePlayer.name +
//		                          " am touching the " + ot.sideAffectedString + " of the " + ot.theGameObject.name);
		touchtype = ""; 
		GLS.playerController.StartObjectPlayerControl();
	}
	
	
}
