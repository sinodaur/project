using UnityEngine;
using System.Collections;


	
	
public class ObjectTouchEvent
{

	GameObject affectedGO;
	GameObject affectingGO;
	SidesList sideAffected;
	
		
	
	
	public ObjectTouchEvent()
	{
			
	}
	
	public ObjectTouchEvent(GameObject touchedGO, GameObject toucherGO, SidesList side)
	{
		affectedGO = touchedGO;
		affectingGO = toucherGO;
		sideAffected = side;
			
	}
	
	public SidesList GetSideAffected()
	{
		
		return sideAffected;
	}
	
	public GameObject GetAffectedGO()
	{
		return affectedGO;
	}
	
	public GameObject GetAffectingGO()
	{
		return affectingGO;
	}
	
	
}
