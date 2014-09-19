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
    

	//private Transform m_transform;

	// Use this for initialization
	void Start () 
	{
		//m_transform = transform;
		isOver = false;
		//isOver = true;
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

		if(Input.GetMouseButton(0))
		{
			isOver = true;
			Debug.Log("enter");
		
		}
		else
		{
			isOver = false;
		}
//		if (Input.GetTouch(0).phase == TouchPhase.Moved)
//		{
//			isOver = true;
//		}
	}
	void OnTriggerEnter(Collider other)
	{
        rock = other.GetComponent<Rock>();
		if(other.tag == "weapon")
		{
			Debug.Log (relativePos);
			//Quaternion q;
			//q.SetFromToRotation;
			tempObj = other.gameObject;
			isMeet = true;
            rock.enWeapon = 0;
            

			//other.transform.rotation= transform.rotation;
		}
		Debug.Log(other.tag);
	}
	// Update is called once per frame
	void Update () 
	{
		if(isOver)
		{
			if(Input.GetMouseButton(0))
			{
				this.mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
			}
			if(Input.touchCount > 0)
			{
				this.mousepos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			}

			mousepos = new Vector3(mousepos.x,mousepos.y,0);

			//if(Input.GetMouseButton(0))
			if((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)) || Input.GetMouseButton(0))
			{

				//touchposition=Input.GetTouch(0).deltaPosition;  //[color=Red]获取手指touch最后一帧移动的xy轴距离[/color]
				//mTransform.Translate(touchposition.x * Time.deltaTime,touchposition.y * Time.deltaTime,0);//[color=Red]移动这个距离[/color]

				//this.transform.Translate(mousepos);

				//this.transform.position = mousepos;
				mTransform.position = mousepos;
				//farr
				relativePos = lastPos - mousepos;

				float f= 0;
				if(isMeet)
				{
                    if (rock != null)
                    {
                        if (rock.State == Rock.RockStateEnum.act1)
                        {
                            Debug.Log(a.ToString());
                            //relativePos = chest.transform.position - mousepos;
                            //f = Vector3.Angle(lastPos,new Vector3(mousepos.x,mousepos.y,mousepos.z));
                            f = Vector3.Angle(relativePos, Vector3.right);
                            //f = 180 + f;
                            //f = Vector3.Angle(Vector3.zero,mousepos);
                            //Debug.Log(relativePos);
                            Debug.Log(f);
                            if (lastPos.y < mousepos.y)
                            {
                                f = -f;
                            }


                            tempObj.transform.rotation = Quaternion.Euler(f, 270f, 0);


                            rock.State = Rock.RockStateEnum.act2;
                        }
                    }
				}
				//chest.transform.Rotate(new Vector3(0,0,f),-turnSpeed * Time.deltaTime);

				lastPos = mousepos;

				//Debug.Log (relativePos);
			}
			//if(Input.GetMouseButtonUp(0))
			if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButtonUp(0))
			{
				relativePos = lastPos - mousepos;
				//Quaternion.LookRotation(relativePos);
				//isUp = true;
				//Debug.Log (relativePos);

				//Instantiate(enemyRocket,this.m_transform.position,Quaternion.LookRotation(relativePos));
			}
			//transform.Translate(mousepos);
			//Debug.Log (transform.position);
		}
		//if(Input.GetMouseButtonUp(0))
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||Input.GetMouseButtonUp(0))
		{
			Destroy(gameObject);
		}
//		if(isUp )
//		{
//			mTransform.Translate(new Vector3(speed * Time.deltaTime,0,0));
//		}
	}
}
