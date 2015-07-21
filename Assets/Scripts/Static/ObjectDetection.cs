using UnityEngine;
using System.Collections;
using System.IO;

public class ObjectDetection 

{
	
	
	
	
	//detect what object the gameObject is touching with a ray and return an ObjectTouch Object
	
	public static ObjectTouch WhatTouching(GameObject myGameObject)
	{
		
		//get texture image for light detection purposes
		takePicture(myGameObject);
		// use takePicture return data to determine if lighted
		// isLit(texture2d)
		
		
		ObjectTouch objectTouch = new ObjectTouch();
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
			
			objectTouch = new ObjectTouch(myBox.gameObject, myObjectsSide, myGameObject);
			
			return objectTouch;
			
		}
			
		return objectTouch;	
			
	}
	
	static void takePicture(GameObject viewer)
	{
		//Get the sensor camera and CameraCapture instance
		Camera camera = GameObject.Find("Sensor").GetComponent<Camera>();
		CameraCapture capture = GameObject.Find("Sensor").GetComponent<CameraCapture>();
		
		//place camera in right place
		camera.transform.position = viewer.transform.position;
		camera.transform.rotation = viewer.transform.rotation;
		
		//enable cam
		camera.enabled = true;
		
		// allows CameraCapture to do it's thing.
		camera.Render();
		
		// get pixels
		Color32[] pixels = capture.RenderResult.GetPixels32();
		Debug.Log (pixels[0].r + " " + pixels[0].g + " " + pixels[0].b + " " + pixels[0].a);
		
		//save CameraCapture to PNG file
		byte[] bytes = capture.RenderResult.EncodeToPNG();
		File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
		
		//close camera
		camera.enabled = false;
	}
	
	
		
		
	
	
	 
}

