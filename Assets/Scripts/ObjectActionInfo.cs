using UnityEngine;
using System.Collections;

public class ObjectActionInfo
{

	GameObject theGameObject;
	string sideAffected;
	
	
	public ObjectActionInfo()
	{
			
	}
	
	public ObjectActionInfo(GameObject theGO, string side)
	{
		theGameObject = theGO;
		sideAffected = side;	
	}
	
	public string getSideAffected()
	{
		
		return sideAffected;
	}
	
	public GameObject getTheGameObject()
	{
		return theGameObject;
	}
	
}
