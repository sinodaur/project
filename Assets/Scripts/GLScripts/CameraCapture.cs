using UnityEngine;
using System.Collections;


//gets a texture2d from a camera outputting to renderTexture

public class CameraCapture : MonoBehaviour 
{

	public Texture2D RenderResult;
	
	void OnPostRender () 
	{
		Camera owner = GetComponent< Camera >();
		RenderTexture target = owner.targetTexture;
		
		if( target == null )
			return; 
		
		RenderResult = new Texture2D( target.width, target.height, TextureFormat.ARGB32, true );
		Rect rect = new Rect( 0, 0, target.width, target.height );
		RenderResult.ReadPixels( rect, 0, 0, true );
	}
}
