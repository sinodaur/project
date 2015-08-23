using UnityEngine;
using System.Collections;



	

public class ObjectTouch
{
	
	public GameObject theGameObject;
	public SidesList sideAffected;
	public GameObject thePlayer;
	public bool isLit;
	public string sideAffectedString;
		
	
	
	public ObjectTouch()
	{
			
	}
	
	public ObjectTouch(GameObject theGO, SidesList side, GameObject theP, bool isL)
	{
		string[] sides = new string[]{"front", "back", "left", "right", "top", "bottom"};
		theGameObject = theGO;
		sideAffected = side;
		thePlayer = theP;
		isLit = isL;
		sideAffectedString = sides[(int)side];	
	}
	
	public SidesList GetSideAffected()
	{
		
		return sideAffected;
	}
	
	public GameObject GetTheGameObject()
	{
		return theGameObject;
	}
	
	
	
	
	
	
	
}
