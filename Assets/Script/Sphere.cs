using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

	private Vector3 mousepos;
	private bool isOver;
	private bool isUp;
	private Vector3 lastPos;
	private Transform mTransform;
	private float speed = 1;
	private Vector3 relativePos;
	private bool isMeet;
	private GameObject tempObj;
	private float turnSpeed = 10000;
	public GameObject chest;
    private bool a = false;
    private Rock rock;
	private Vector2 touchposition;
	private float[,] farr;
	private Parabola para;
    

	//private Transform m_transform;

	// Use this for initialization
	void Start () 
	{
		//m_transform = transform;
		#if UNITY_STANDALONE_WIN
			isOver = false;
		#endif

		#if UNITY_IPHONE
			isOver = true;
		#endif
		isUp = false; 
		isMeet = false;

		mTransform = transform;
	}
	void OnMouseOver()
	{
		//isOver = true;
	}
	void OnMouseUp()
	{
		//isUp = true;
		//Debug.Log ("isUp");
	}

	void OnMouseEnter()
	{
		#if UNITY_STANDALONE_WIN
		if(Input.GetMouseButton(0))
		{
			isOver = true;
			//Debug.Log("enter");
		
		}
		else
		{
			isOver = false;
		}
		#endif
//		if (Input.GetTouch(0).phase == TouchPhase.Moved)
//		{
//			isOver = true;
//		}
	}
	void OnTriggerEnter(Collider other)
	{
        rock = other.GetComponent<Rock>();
		para = other.GetComponent<Parabola>();
		if(other.tag == "weapon")
		{

			//Debug.Log (relativePos);
			//Quaternion q;
			//q.SetFromToRotation;
			tempObj = other.gameObject;


				//Debug.Log("else");
				isMeet = true;
				rock.enWeapon = 0;


            

			//other.transform.rotation= transform.rotation;
		}
		//Debug.Log(other.tag);
	}
	// Update is called once per frame
	void Update () 
	{


		if(isOver)
		{
			#if UNITY_STANDALONE_WIN
				if(Input.GetMouseButton(0))
				{
					this.mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
				}
			#endif
			#if UNITY_IPHONE
			if(Input.touchCount > 0)
			{
				this.mousepos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			}
			#endif
			mousepos = new Vector3(mousepos.x,mousepos.y,0);


			if((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)) || Input.GetMouseButton(0))
			{

				mTransform.position = mousepos;

				relativePos = lastPos - mousepos;

				float f= 0;
				if(isMeet)
				{
                    if (rock != null)
                    {
                        if (rock.State == Rock.RockStateEnum.act1)
                        {

//								if(Input.touchCount > 0 && (lastPos == mousepos || Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
//								{
//									Debug.Log("clikeDown");
//									mousepos = GameObject.Find("SpriteChest5").transform.position;
//									relativePos = lastPos - mousepos;
//								}

                            f = Vector3.Angle(relativePos, Vector3.right);
                            if (lastPos.y < mousepos.y)
                            {
                                f = -f;
                            }

                            tempObj.transform.rotation = Quaternion.Euler(f, 270f, 0);
							para.active = false;
							//if(Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Began)
							//{
								rock.State = Rock.RockStateEnum.act2;
							//}

                        }
                    }
				}
				lastPos = mousepos;
			}
			if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButtonUp(0))
			{
				relativePos = lastPos - mousepos;
			}
		}

		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||Input.GetMouseButtonUp(0))
		{
			Destroy(gameObject);
		}

	}
}
