using UnityEngine;
using System.Collections;


public class Control : MonoBehaviour 
{
	public GameObject box;
	public GameObject ball;
	private Quaternion quat;
	// Use this for initialization
	void Start () 
	{
	
		//ball.transform.Rotate(30f);

		quat.SetFromToRotation(ball.transform.position,box.transform.position);
		ball.transform.rotation = quat;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//quat.SetLookRotation(box.transform.position,ball.transform.position);
		//ball.transform.rotation=quat;
		//box.transform.Rotate(Quaternion(0,0,0,1));

		quat.SetFromToRotation(ball.transform.position,box.transform.position);
		ball.transform.rotation = quat;

	
	}
}
