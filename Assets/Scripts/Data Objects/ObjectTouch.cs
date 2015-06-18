using UnityEngine;
using System.Collections;



namespace MyGame.DataObjects
{
	
	
	
	public class ObjectTouch
	{
	
		GameObject theGameObject;
		string sideAffected;
		
		
		public ObjectTouch()
		{
				
		}
		
		public ObjectTouch(GameObject theGO, string side)
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
}