using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public Vector2 TapPosition;
	public Vector2 TapDirection;

	private bool Swipping;



	void Awake () 
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

		if (Input.touchCount > 0 && Swipping == false) 
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

					Swipping = false;
				
					break;

				case TouchPhase.Ended:
				
					//End of a single tap.
					Swipping = false;
				
					break;

				case TouchPhase.Moved:
				
					// Swipes 
						
					if(Swipping == false)
					{	
				   		TapDirection = TapPosition - Input.GetTouch(0).position ;
					
						if(TapDirection.x > 40)
						{
							Debug.Log ("Swipe Left");
							SwipeToLeft();
							Swipping = true;
						}

						if(TapDirection.x < -40)
						{
							Debug.Log ("Swipe Right");
							SwipeToRight();
							Swipping = true;
						}
						if(TapDirection.y > 40)
						{
							Debug.Log ("Swipe Down");
							SwipeToDown();
							Swipping = true;
						}	
						if(TapDirection.y < -40)
						{
							Debug.Log ("Swipe Up");
							SwipeToUp();
							Swipping = true;	
						}
					}
					
				
					break;

				default:

					break;
			}

		}



	}


	void SwipeToLeft ()
	{
		//Swipping = true; when the animation starts


		//Swipping = false; when the animation ends
	}
	void SwipeToRight ()
	{
		//Swipping = true; when the animation starts
		
		
		//Swipping = false; when the animation ends
	}
	void SwipeToDown ()
	{
		//Swipping = true; when the animation starts
		
		
		//Swipping = false; when the animation ends
	}
	void SwipeToUp ()
	{
		//Swipping = true; when the animation starts
		
		
		//Swipping = false; when the animation ends
	}
}

















