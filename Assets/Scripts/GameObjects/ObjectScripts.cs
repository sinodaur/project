using UnityEngine;
using System.Collections;
using MyGame.Enums;
using MyGame.Messaging;

namespace MyGame.ObjectScripts
{
	//base class for making in-game object scripts
	
	public class ObjectScripts : MonoBehaviour 
	{	
		string myGOName;
		MessageGuy messageGuy; 
	
		// Use this for initialization
		void Start () {
			
			myGOName = this.gameObject.name;
			
			Debug.Log ("I'm a " + myGOName  + " on the edge, two days from " +
			"retirement");
			
			messageGuy = GameObject.Find("MessageGuy").GetComponent("MessageGuy") as MessageGuy;
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		public void TouchEvent (SidesList side)
		{
			switch (side)
			{
			case SidesList.front:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.back:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.left:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.right:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.top:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.bottom:
				messageGuy.DisplayMessage("I'm touching the " + side + " of the " + myGOName);
				break;
				
			}
		}
	}
}