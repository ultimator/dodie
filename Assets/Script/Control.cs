using UnityEngine;
using System.Collections;


public class Control : MonoBehaviour 
{
	public GameObject box;
	public GameObject ball;
	private Quaternion quat;
	public tk2dTileMap tileMap;

//	private Camera mainCrma;
//	private RaycastHit objhit;
//	private Ray _ray;
	// Use this for initialization
	void Start () 
	{
	//tileMap.transform.position.x
		//ball.transform.Rotate(30f);
		//mainCrma = Camera.main;

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

//		//投射
//		if (Input.GetMouseButtonDown(0)) 
//		{
//			Debug.Log("gogogo");
//			_ray=mainCrma.ScreenPointToRay(Input.mousePosition);//从摄像机发出一条射线,到点击的坐标
//			Debug.DrawLine(_ray.origin,objhit.point,Color.red,2);//显示一条射线，只有在scene视图中才能看到
//			
//			if (Physics.Raycast (_ray, out objhit, 100)) 
//			{
//				GameObject gameObj = objhit.collider.gameObject;
//				
//				Debug.Log("Hit objname:"+gameObj.name+"Hit objlayer:"+gameObj.layer);
//			}
//		}


	
	}
}
