using UnityEngine;
using System.Collections;

public class MoveIt : MonoBehaviour {
	public float speed;
	bool right;
	bool left;
	// Use this for initialization
	void Start () {
	
		right = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 200) 
		{
			left = true;
			right = false;
		}
		if (transform.position.x < -200)
		{
			left = false;
			right = true;
		}
		if( right ) transform.Translate (new Vector3(1,0,0) * speed *  Time.deltaTime);
		if( left ) transform.Translate (new Vector3(-1,0,0) * speed *  Time.deltaTime);
	}
	void FixedUpdate(){
		//transform.Translate (new Vector3 ( 10,0,0));
	}
	
}
