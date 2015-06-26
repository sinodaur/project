using UnityEngine;
using System.Collections;
using MyGame.DataObjects;
using MyGame.Enums;


namespace MyGame.EventManagment
{
	public class ObjectEventMaster : MonoBehaviour 
	{
		
		
		
		
		
		
		// Use this for initialization
		void Start () {
			
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		// gets ready to execute events for a particular object's side.
		public void executeEvent (ObjectTouch theObjectTouch)
		{	
			
			
			InGameObjectsList objectName; 
			string gOName =  theObjectTouch.getTheGameObject().name;
			
			//get the correct enum value from the "name" string
			objectName = 
			(InGameObjectsList)System.Enum.Parse(typeof(InGameObjectsList), gOName );
			
			
			SidesList sideAffected = theObjectTouch.getSideAffected();
			
			//Debug.Log("The " + side + " of the " + go + " game object is being touched" );	
			
			switch (objectName)
			{
			case InGameObjectsList.Rectangle :
				rectangleEvent (sideAffected);
				break;
			}    
		}
		
		// events for GO rectangle
		void rectangleEvent (SidesList sideAffected)
		{
			switch (sideAffected)
			{
			case SidesList.front:
				Debug.Log("I'm touching the front of the rectangle");
				break;
			}
		}
	}
}