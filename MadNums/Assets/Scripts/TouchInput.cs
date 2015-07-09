using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public Vector2 TapPosition;
	public Vector2 TapDirection;

	void Start () 
	{
		// Check device
		Debug.Log ("Hello");
		if (Application.platform == RuntimePlatform.Android) Debug.Log ("Android");
			
		else if(Application.platform == RuntimePlatform.IPhonePlayer) Debug.Log("iPhone");

		else if(Application.platform == RuntimePlatform.WindowsPlayer) Debug.Log("Windows");

		else if(Application.platform == RuntimePlatform.OSXPlayer) Debug.Log("Mac");

		// End check device
	
	}

	void Update () 
	{

		if (Input.touchCount > 0 ) 
		{
			Debug.Log ("Touch Detected");
			Vector2 deltaPos = Input.GetTouch(0).deltaPosition;

			switch (Input.GetTouch(0).phase)
			{
				case TouchPhase.Began:

					//When a touch starts, better to use "end" phase for a single tap tough

					TapPosition = Input.GetTouch(0).position; // used on swipes
					Debug.Log (" Simple tap ");
					

				break;

				case TouchPhase.Canceled:
				
					//Canceled touch
				
				break;

				case TouchPhase.Ended:
				
					//End of a single tap.
				
				break;

				case TouchPhase.Moved:
				
					// Swipes 
					
					TapDirection = TapPosition - TapPosition;
					
					if(TapDirection.x > TapPosition.x + 100)
					Debug.Log ("Swipe ");


				
				break;

				default:
				break;
			}

		}



	}



}

















