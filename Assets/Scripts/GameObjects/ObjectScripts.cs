using UnityEngine;
using System.Collections;
using MyGame.Enums;

namespace MyGame.ObjectScripts
{
	//base class for making in-game object scripts
	
	public class ObjectScripts : MonoBehaviour 
	{	
		string myGOName;
	
		// Use this for initialization
		void Start () {
			
			myGOName = this.gameObject.name;
			
			Debug.Log ("I'm a " + myGOName  + " on the edge, two days from " +
			"retirement");
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		public void TouchEvent (SidesList side)
		{
			switch (side)
			{
			case SidesList.front:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.back:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.left:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.right:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.top:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
			case SidesList.bottom:
				Debug.Log ("I'm touching the " + side + " of the " + myGOName);
				break;
				
			}
		}
	}
}