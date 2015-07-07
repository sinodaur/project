using UnityEngine;
using System.Collections;

// list of sides of GOs that player can touch
public enum SidesList
{
	front,
	back,
	left,
	right,
	top,
	bottom
}

public enum GOList
{
	Player,
	Rectangle,
	Sphere,
	MainCamera
}


public class GOInterface : MonoBehaviour 
{

	
	
	
	
	Player player;
	Rectangle rectangle;
	Sphere sphere;
	MainCamera mainCamera;
	Object[] unsortedGOs;
	GameObject[] GOs;
	MainGLObjects glObjects;
	
	
	//receive glOnject struct
	
	public void recieveGLObjects(MainGLObjects theglObjects)
	{
		glObjects =  theglObjects;
	}
	
	//get all the scene GOs and  attached scripts
	public void GLInitialize () 
	{
		 Debug.Log (glObjects.gOInterface.name);
		 
		 unsortedGOs = Object.FindObjectsOfType(typeof(GameObject));
		 GOs = new GameObject[unsortedGOs.Length];
		 
		 
		 
		 // sort GameObjects to match enum GOList
		 foreach (Object go in unsortedGOs)
		 {
		 	switch (go.name)
		 	{
		 		case "Player":
		 		GOs[0] = go as GameObject;
		 		Debug.Log (go.name);
		 		break;
		 		
				case "Rectangle":
				GOs[1] = go as GameObject;
				Debug.Log (go.name);
				break;
				
				case "Sphere":
				GOs[2] = go as GameObject;
				Debug.Log (go.name);
				break;
				
				case "MainCamera":
				GOs[3] = go as GameObject;
				Debug.Log (go.name);
				break;
			}
		 }
		 
		 
		 
		//initialize script object variables   
		 
		player = GOs[(int)GOList.Player].GetComponent<Player>();
		rectangle = GOs[(int)GOList.Rectangle].GetComponent<Rectangle>();
		sphere = GOs[(int)GOList.Sphere].GetComponent<Sphere>();
		mainCamera = GOs[(int)GOList.MainCamera].GetComponent<MainCamera>();
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	
	public static ObjectTouchEvent WhatTouching(GameObject myGameObject)
	{
		
		ObjectTouchEvent objectTouch = new ObjectTouchEvent();
		BoxCollider myBox = new BoxCollider();
		RaycastHit hit;
		Vector3 localPoint = new Vector3();
		Vector3 localDir = new Vector3();
		float upDot = 0f;
		float fwdDot = 0f;
		float rightDot = 0f;
		float upPower = 0f; 
		float fwdPower = 0f;  
		float rightPower = 0f;
		int largestPower = 1;
		SidesList myObjectsSide = SidesList.front;
		
		Vector3 fwd = myGameObject.transform.TransformDirection(Vector3.forward);
		
		
		if (Physics.Raycast(myGameObject.transform.position, fwd, out hit, 1f))
		{
			
			myBox = hit.collider as BoxCollider;
			
			
			
			localPoint = hit.transform.InverseTransformPoint(hit.point);
			localDir = localPoint.normalized;
			
			upDot = Vector3.Dot(localDir,Vector3.up); 
			fwdDot = Vector3.Dot(localDir,Vector3.forward); 
			rightDot = Vector3.Dot(localDir,Vector3.right);
			
			upPower = Mathf.Abs(upDot); 
			fwdPower = Mathf.Abs(fwdDot); 
			rightPower = Mathf.Abs(rightDot);
			
			if (fwdPower > upPower && fwdPower > rightPower) largestPower = 1;
			else if (rightPower > upPower && rightPower > fwdPower) largestPower = 2;
			else largestPower = 0;
			
			if (largestPower == 0 && upDot < 0) myObjectsSide = SidesList.bottom;
			else if (largestPower == 0 && upDot > 0) myObjectsSide = SidesList.top;
			else if (largestPower == 1 && fwdDot < 0) myObjectsSide = SidesList.front;
			else if (largestPower == 1 && fwdDot > 0) myObjectsSide = SidesList.back;
			else if (largestPower == 2 && rightDot < 0) myObjectsSide = SidesList.left;
			else if (largestPower == 2 && rightDot > 0) myObjectsSide = SidesList.right;
			
			objectTouch = new ObjectTouchEvent(myGameObject, myBox.gameObject, myObjectsSide);
			
			return objectTouch;
			
		}
		
		return objectTouch;	
		
	}
}
