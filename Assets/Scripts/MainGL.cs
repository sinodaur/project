using UnityEngine;
using System.Collections;



public struct MainGLObjects 
{
	public GOInterface gOInterface;
	public ControllerInterface controlInterface;
	public GameUI gameUI;
}


public class MainGL : MonoBehaviour 
{
	MainGLObjects gLObjects;
	
	bool[] GameFlags;
	GOInterface gOInterface;
 	ControllerInterface controlInterface;
	GameUI gameUI;
	
	
	
	// Use this for initialization
	void Start () 
	{	
		//initialize glObjects variables
		gLObjects = new MainGLObjects();
		gLObjects.gOInterface = GameObject.Find("GOInterface").GetComponent<GOInterface>();
		
		
		//initialize glObject instances
		gLObjects.gOInterface.recieveGLObjects(gLObjects);
		gLObjects.gOInterface.GLInitialize();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public MainGLObjects GetMainGLObjects()
	{
		return gLObjects;
	}
}
