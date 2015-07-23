using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour{

	public Vector3 tapPosition;
	public Vector3 tapDirection;
	public float speed;

	public bool swipping;
	public bool moving;
	private bool tapping;

	MovementTYPE moveTo;
	MovementTYPE movementDir;
	GameObject[] Buttons;

	BoxCollider2D first;
	BoxCollider2D second;

	Vector3 firstInitialPos; 
	Vector3 secondInitialPos;

	float[] ButtonsCenter;
	float[] ButtonsLeft;
	float[] ButtonsRight;
	float[] ButtonsUp;
	float[] ButtonsDown;

	TableBasic table;



	void Awake () 
	{

		// Check device
//		Debug.Log ("Hello");
//		if (Application.platform == RuntimePlatform.Android) Debug.Log ("Android");
//			
//		else if(Application.platform == RuntimePlatform.IPhonePlayer) Debug.Log("iPhone");
//
//		else if(Application.platform == RuntimePlatform.WindowsPlayer) Debug.Log("Windows");
//
//		else if(Application.platform == RuntimePlatform.OSXPlayer) Debug.Log("Mac");

		// End check device


	
	}

	void Start()
	{

		moveTo = MovementTYPE.LEFT;
		BoxCollider2D Button0Box;

		Buttons = new GameObject[16];
		ButtonsCenter = new float[16];
		ButtonsLeft = new float[16];
		ButtonsRight = new float[16];
		ButtonsUp = new float[16];
		ButtonsDown = new float[16];

		findButtonsGameobject ();

		for (int i = 0; i < 16; i++)
		{

			Button0Box = Buttons[i].GetComponent<BoxCollider2D>();

//			Debug.Log(Button0Box.transform.position.x);
//			Debug.Log(Button0Box.size);
//			Debug.Log (Button0Box.bounds.extents.x);

			ButtonsCenter[i] = Button0Box.bounds.center.x;
			ButtonsLeft[i] = ButtonsCenter [i] - (Button0Box.bounds.extents.x / 2);
			ButtonsRight [i] = ButtonsCenter [i] + (Button0Box.bounds.extents.x / 2);
			ButtonsCenter[i] = Button0Box.bounds.center.y;
			ButtonsDown[i] = ButtonsCenter [i] - (Button0Box.bounds.extents.y / 2);
			ButtonsUp [i] = ButtonsCenter [i] + (Button0Box.bounds.extents.y / 2);

//			Debug.Log ("\n BUTTON  " + i);
//			Debug.Log ("\n LEFT : " + ButtonsLeft [i]);
//			Debug.Log ("\n Right : " + ButtonsRight [i]);
//			Debug.Log ("\n Up : " + ButtonsUp [i]);
//			Debug.Log ("\n Down : " + ButtonsDown [i]);
//			Debug.Log ("\n Button Finished");

		}

		table = new TableBasic ();
		table.LoadLevel (1);

	}

	void Update()
	{
		if (Input.touchCount > 0) 
		{
			switch ( Input.GetTouch(0).phase)
			{

			case TouchPhase.Began:

				//When a touch starts, better to use "end phase for single tap tough

				tapPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);// Camera's relative position needed
				//Debug.Log ( " TAP HERE : " + tapPosition);
				//Debug.Log("Simple Tap");

				break;

			case TouchPhase.Canceled:

				// Canceled touch
				//Debug.Log ("Canceled");
				swipping = false;
				break;

			case TouchPhase.Ended:

				// End of single tap

				//Debug.Log ( "Ended");
				swipping = false;
				break;

			case TouchPhase.Moved:
				//	swipes
				if(swipping == false)
				{
					tapDirection = tapPosition - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

					if(tapDirection.x > 40)
					{
						//Debug.Log("Swipe Left");
						moveTo = MovementTYPE.LEFT;
						swipping = true;
						swipeTo(tapPosition);
					}
					if(tapDirection.x < -40)
					{
						//Debug.Log("Swipe Right");
						moveTo = MovementTYPE.RIGHT;
						swipping = true;
						swipeTo(tapPosition);
					}
					if(tapDirection.y > 40)
					{
						//Debug.Log("Swipe Down");
						moveTo = MovementTYPE.DOWN;
						swipping = true;
						swipeTo(tapPosition);
					}
					if(tapDirection.y < -40)
					{
						//Debug.Log("Swipe Up");
						moveTo = MovementTYPE.UP;
						swipping = true;
						swipeTo(tapPosition);
					}

				}
				break;

			default:

				break;
			}

		}




		// Move Animation

		if (moving == true) {
			switch (movementDir) {
			
			case MovementTYPE.RIGHT:
			
				if (secondInitialPos.x > first.transform.position.x) {

					first.transform.Translate (new Vector3 (1, 0, 0) * speed * Time.deltaTime);
					second.transform.Translate (new Vector3 (-1, 0, 0) * speed * Time.deltaTime);
				
				} else {

					if(moving == true ) 
					{
						setFinalPos();
					}
				
					moving = false;
				}
				break;
			
			case MovementTYPE.LEFT:
			
				if (secondInitialPos.x < first.transform.position.x) {

					first.transform.Translate (new Vector3 (-1, 0, 0) * speed * Time.deltaTime);
					second.transform.Translate (new Vector3 (1, 0, 0) * speed * Time.deltaTime);
				
				} else {

					if(moving == true ) 
					{
						setFinalPos();
					}
					moving = false;
				}
				break;
			
			case MovementTYPE.DOWN:
			
				if (secondInitialPos.y < first.transform.position.y) {
			
					first.transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
					second.transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
				
				} else {

					if(moving == true ) 
					{
						setFinalPos();
					}
				
					moving = false;

				}
				break;
			
			case MovementTYPE.UP:
			
				if (secondInitialPos.y > first.transform.position.y) {
				
					first.transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
					second.transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
				
				} else {

					if(moving == true ) 
					{
						setFinalPos();
					}

					moving = false;
				}
			
				break;
			default:
				break;
			}
		}
	}
	
	void swipeTo (Vector2 position)
	{
	
		//Swipping = true; when the animation starts
		for (int i = 0; i < 16; i++) 
		{
			if(( ButtonsLeft[i] < position.x ) && (ButtonsRight[i] > position.x ))
			{
				if( ButtonsUp[i] > position.y && ButtonsDown[i] < position.y )
				{

					int tmp = table.boardTable.CheckMove(i,moveTo);
					if(tmp != 16) // checkMove
					{


						table.boardTable.SWAP(i,tmp);

						moveThem ( Buttons[i],Buttons[tmp],moveTo,speed);
						Debug.Log(table.boardTable);
					}

				}
			}
		}

		
		//Swipping = false; when the animation ends
	}

	public void moveThem(GameObject firstGO,GameObject secondGO,MovementTYPE movementDirTmp,float movSpeedTmp) 
	{
		
	
		speed = movSpeedTmp;
		first = firstGO.GetComponent<BoxCollider2D> ();
		second = secondGO.GetComponent<BoxCollider2D>();
		movementDir = movementDirTmp;
		moving = true;
		
		firstInitialPos = firstGO.transform.position;
		secondInitialPos = secondGO.transform.position;
		
		
		
	}

	void findButtonsGameobject()
	{
		Buttons[0] = GameObject.Find("Button0");
		Buttons[1] = GameObject.Find("Button1");
		Buttons[2] = GameObject.Find("Button2");
		Buttons[3] = GameObject.Find("Button3");
		Buttons[4] = GameObject.Find("Button4");
		Buttons[5] = GameObject.Find("Button5");
		Buttons[6] = GameObject.Find("Button6");
		Buttons[7] = GameObject.Find("Button7");
		Buttons[8] = GameObject.Find("Button8");
		Buttons[9] = GameObject.Find("Button9");
		Buttons[10] = GameObject.Find("Button10");
		Buttons[11] = GameObject.Find("Button11");
		Buttons[12] = GameObject.Find("Button12");
		Buttons[13] = GameObject.Find("Button13");
		Buttons[14] = GameObject.Find("Button14");
		Buttons[15] = GameObject.Find("Button15");
	}

	void setFinalPos()
	{
		first.transform.position = new Vector3 ( secondInitialPos.x, secondInitialPos.y,secondInitialPos.z);
		second.transform.position = new Vector3 (firstInitialPos.x,firstInitialPos.y,firstInitialPos.z);
	}

}

















