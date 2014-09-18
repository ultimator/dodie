using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{
	private float moveSpeed = 10;
	private float turnSpeed = 10;
	private Vector3 ver;

	// Use this for initialization
	void Start () 
	{
	  
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);

	
	}
}
