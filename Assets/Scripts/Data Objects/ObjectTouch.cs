using UnityEngine;
using System.Collections;



	

public class ObjectTouch
{
	
	public GameObject theGameObject;
	public SidesList sideAffected;
	public GameObject thePlayer;
	public bool isLit;
	
		
	
	
	public ObjectTouch()
	{
			
	}
	
	public ObjectTouch(GameObject theGO, SidesList side, GameObject theP, bool isL)
	{
		theGameObject = theGO;
		sideAffected = side;
		thePlayer = theP;
		isLit = isL;	
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
