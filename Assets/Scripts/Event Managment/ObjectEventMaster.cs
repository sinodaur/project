using UnityEngine;
using System.Collections;
using MyGame.DataObjects;
using MyGame.Enums;
using MyGame.ObjectScripts;


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
		
		// gets ready to execute objectevents
		public void ExecuteEvent (ObjectTouch theObjectTouch)
		{	
			
			
		    
			InGameObjectsList name = theObjectTouch.GetGOName();
			GameObject gO = theObjectTouch.GetTheGameObject();
			SidesList side = theObjectTouch.GetSideAffected();
			
			switch (name)
			{
			case InGameObjectsList.Rectangle:
				gO.GetComponent<Rectangle>().TouchEvent(side);
				break;
			case InGameObjectsList.Sphere:
				gO.GetComponent<Sphere>().TouchEvent(side);
				break;
			}
			
			
				
			
			
			
		}
		
		
	}
}