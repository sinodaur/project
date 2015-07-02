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
		
		public SidesList GetSideAffected()
		{
			
			return sideAffected;
		}
		
		public GameObject GetTheGameObject()
		{
			return theGameObject;
		}
		
		public InGameObjectsList GetGOName()
		{
			return (InGameObjectsList)System.Enum.Parse(typeof(InGameObjectsList), theGameObject.name );
		}
		
		
		
	}
}