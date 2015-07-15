using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public Vector2 tapPosition;
	public Vector2 tapDirection;

	GameObject thisObject;

	public float speed;
	private bool swipping;
	private bool tapping;

	bool left;
	bool right;
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("POINT ENTER");
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("POINT ENTER");
	}
	void Awake () 
	{
		thisObject = gameObject;
		// Check device
		Debug.Log ("Hello");
		if (Application.platform == RuntimePlatform.Android) Debug.Log ("Android");
			
		else if(Application.platform == RuntimePlatform.IPhonePlayer) Debug.Log("iPhone");

		else if(Application.platform == RuntimePlatform.WindowsPlayer) Debug.Log("Windows");

		else if(Application.platform == RuntimePlatform.OSXPlayer) Debug.Log("Mac");

		// End check device
	
	}


	public void checkTouch()
	{
		Debug.Log ("CHECK TOUCH");
		if (Input.touchCount > 0) 
		{
			while(Input.touchCount > 0) 
			{
				Debug.Log ("Touch Detected");
				//Vector2 deltaPos = Input.GetTouch(0).deltaPosition;
				
				switch (Input.GetTouch(0).phase)
				{
					
				case TouchPhase.Began:
					
					//When a touch starts, better to use "end" phase for a single tap tough
					
					tapPosition = Input.GetTouch(0).position; // used on swipes
					Debug.Log (" Simple tap ");
					
					
					break;
					
				case TouchPhase.Canceled:
					
					//Canceled touch
					Debug.Log (" CANCELED ");
					swipping = false;
					
					break;
					
				case TouchPhase.Ended:
					
					//End of a single tap.
					Debug.Log ( " ENDED " );
					swipping = false;
					
					break;
					
				case TouchPhase.Moved:
					
					// Swipes 
					
					
					if(swipping == false)
					{	
						tapDirection = tapPosition - Input.GetTouch(0).position ;
						
						if(tapDirection.x > 40)
						{
							Debug.Log ("Swipe Left");
							swipeToLeft();
							swipping = true;
						}
						
						if(tapDirection.x < -40)
						{
							Debug.Log ("Swipe Right");
							swipeToRight();
							swipping = true;
						}
						if(tapDirection.y > 40)
						{
							Debug.Log ("Swipe Down");
							swipeToDown();
							swipping = true;
						}	
						if(tapDirection.y < -40)
						{
							Debug.Log ("Swipe Up");
							swipeToUp();
							swipping = true;	
						}
					}
					
					
					break;
					
				default:
					
					break;
				}
				
			}
		}
	}
	void swipeToLeft ()
	{
		//Swipping = true; when the animation starts
		int i = 0;
		while (i == 0) 
		{
			if (transform.position.x > 200) {
				left = true;
				right = false;
			}
			if (transform.position.x < -200) {
				left = false;
				right = true;
			}
			if (right)
				thisObject.transform.Translate (new Vector3 (1, 0, 0) * speed * Time.deltaTime);
			if (left)
				thisObject.transform.Translate (new Vector3 (-1, 0, 0) * speed * Time.deltaTime);

		}
		//Swipping = false; when the animation ends
	}
	void swipeToRight ()
	{
		//Swipping = true; when the animation starts
		

		//Swipping = false; when the animation ends
	}
	void swipeToDown ()
	{
		//Swipping = true; when the animation starts
		
		
		//Swipping = false; when the animation ends
	}
	void swipeToUp ()
	{
		//Swipping = true; when the animation starts
		
		
		//Swipping = false; when the animation ends
	}
}

















