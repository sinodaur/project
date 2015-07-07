using UnityEngine;
using System.Collections;



	

public class ObjectTouch
{

	GameObject theGameObject;
	SidesList sideAffected;
	
		
	
	
	public ObjectTouch()
	{
			
	}
	
	public ObjectTouch(GameObject theGO, SidesList side)
	{
		theGameObject = theGO;
		sideAffected = side;	
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
