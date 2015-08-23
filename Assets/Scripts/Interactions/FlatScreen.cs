using UnityEngine;
using System.Collections;

public class FlatScreen : Interaction
{

	protected override void bottomTouch (ObjectTouch ot)
	{
		//base.bottomTouch (ot);
		
		
		if (step == 0)
		{ 
			GLS.messageGuy.DisplayMessage("The TV has no power right now.");
			step++;
		}
		else if (step == 1)
		{
			if (!GLS.messageGuy.boardCamera.enabled)
				step++;
		}		
		else if (step == 2)
		{
			step++;
			GLS.messageGuy.DisplayMessage("I wish I could watch my favorite show.");
		}	
		else
			if (!GLS.messageGuy.boardCamera.enabled)
			{
				touchtype = "";
				GLS.playerController.StartObjectPlayerControl();
			}
	}
}
