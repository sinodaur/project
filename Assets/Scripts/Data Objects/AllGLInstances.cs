using UnityEngine;
using System.Collections;

public class AllGLInstances {

	
	public CameraController cameraController;
	public DM dM;
	public ObjectEventMaster objectEventMaster;
	public MessageGuy messageGuy;
	public PlayerController playerController;
	
	
	public AllGLInstances(DM dm, CameraController cc, ObjectEventMaster oem, MessageGuy mg, PlayerController pc)
	{
		cameraController = cc;
		dM = dm;
		objectEventMaster = oem;
		messageGuy = mg;
		playerController = pc;
	}
}
