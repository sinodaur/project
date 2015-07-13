using UnityEngine;
using System.Collections;



	

public class ObjectTouch
{
	
	public GameObject theGameObject;
	public SidesList sideAffected;
	public GameObject thePlayer;
	
		
	
	
	public ObjectTouch()
	{
			
	}
	
	public ObjectTouch(GameObject theGO, SidesList side, GameObject theP)
	{
		theGameObject = theGO;
		sideAffected = side;
		thePlayer = theP;	
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
