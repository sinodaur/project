using UnityEngine;
using System.Collections;

public class ObjectDetection : MonoBehaviour 

{
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		whatTouching(this.gameObject);
	}
	
	
	
	public static ObjectActionInfo whatTouching(GameObject myGameObject)
	{
		
		ObjectActionInfo objectActionInfo = new ObjectActionInfo();
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
		string myObjectsSide = "";
		
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
			
			if (largestPower == 0 && upDot < 0) myObjectsSide = "bottom";
			else if (largestPower == 0 && upDot > 0) myObjectsSide = "top";
			else if (largestPower == 1 && fwdDot < 0) myObjectsSide = "front";
			else if (largestPower == 1 && fwdDot > 0) myObjectsSide = "back";
			else if (largestPower == 2 && rightDot < 0) myObjectsSide = "left";
			else if (largestPower == 2 && rightDot > 0) myObjectsSide = "right";
			
			objectActionInfo = new ObjectActionInfo(myBox.gameObject, myObjectsSide);
			
			return objectActionInfo;
			
		}
			
		return objectActionInfo;	
			
	}
		
		
	
	
	 
}
