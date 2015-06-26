using UnityEngine;
using System.Collections;
using MyGame.Enums;



namespace MyGame.DataObjects
{
	
	
	
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
		
		public SidesList getSideAffected()
		{
			
			return sideAffected;
		}
		
		public GameObject getTheGameObject()
		{
			return theGameObject;
		}
		
		
		
	}
}