using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour 
{

	// Use this for initialization
	public GameObject box;
	public GameObject pointer;
	private Vector3 mousepos;
	private bool isClike;
	public GameObject obj;
	public GameObject rock;
	private float rate = 5;
    public Enemy enemy;
    public TextMesh text;
    


	void Start () 
	{
		isClike = false;
        //for (int i = 0; i < 5; i++)
        //{
        //    Instantiate(enemy, new Vector3(5f, 0.8f * i, 0f), Quaternion.identity);
        //}
        Invoke("SendEnemy", 8);
        
        
	}
    void SendEnemy()
    {
        int i;
        i = Random.Range(1, 6);
        Debug.Log(i.ToString());
        Instantiate(enemy, new Vector3(5f, 0.6f * i, 0f), Quaternion.identity);
        Invoke("SendEnemy", 8);
 
    }
	// Update is called once per frame
	void Update () 
	{
//        int i = 0;
//        //Debug.Log(Input.touchCount.ToString());
//        while (i < Input.touchCount)
//        {
//            if (Input.GetTouch(i).phase == TouchPhase.Began)
//            {
//                //Instantiate(box, Input.GetTouch(i).deltaPosition, Quaternion.identity);
//                text.text = i.ToString() + "#" + Input.GetTouch(i).deltaPosition.ToString() + "#" + Input.touchCount.ToString();
//				i = i + 1;
//            }
//        }


		        int i = 0;
		        //Debug.Log(Input.touchCount.ToString());
		        //while (i < Input.touchCount)
		        //{
//		            if (Input.GetTouch(i).phase == TouchPhase.Began)
//		            {
//		                //Instantiate(box, Input.GetTouch(i).deltaPosition, Quaternion.identity);
//		                //text.text = i.ToString() + "#" + "Began" + "#" + Input.touchCount.ToString();
//			//text.text = "Began" + "#" + Input.touchCount.ToString()+ "#" + Camera.main.ScreenPointToRay(Input.GetTouch(i).position).ToString();/////Input.GetTouch(i).deltaPosition.ToString();
//			//i = i + 1;
//			text.text = "Began" + "#" + Input.touchCount.ToString()+ "#" + Input.GetTouch(i).position.ToString();
//			Instantiate(this.pointer, mousepos, Quaternion.identity);
//		            }
//		if (Input.GetTouch(i).phase == TouchPhase.Moved)
//		{
//			//text.text = "Moved" + "#" + Input.touchCount.ToString() + "#" + Input.GetTouch(i).deltaPosition.ToString();
//			text.text = "Moved" + "#" + Input.touchCount.ToString() + "#" + Input.GetTouch(i).deltaPosition.ToString();
//
//		}
//		if (Input.GetTouch(i).phase == TouchPhase.Ended)
//		{
//			text.text = "Ended" + "#" + Input.touchCount.ToString()+ "#" + Input.GetTouch(i).deltaPosition.ToString();
//		}
		        //}



//		int k = 0;
//		if (Input.GetMouseButton(0))
//		{
//			k = 5;
//		}
//			
//			int i = 0;
//		        //Debug.Log(Input.touchCount.ToString());
//
//		while (i < k)
//		  {
//			if (Input.GetMouseButton(0) )
//			{
//
//		                //Instantiate(box, Input.GetTouch(i).deltaPosition, Quaternion.identity);
//		                text.text = i.ToString() + "#" + "ddd" + "#" + k.ToString();
//						++i;
//		    }
//		  }

	
			if ( Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Began)
		{
			this.mousepos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
			//this.mousepos = Input.GetTouch(i).position;

			mousepos = new Vector3(mousepos.x, mousepos.y, 0);

			if (!isClike)
			{
				 obj = Instantiate(this.pointer, mousepos, Quaternion.identity) as GameObject;
				text.text = i.ToString() +"@" + this.mousepos.ToString();
				 isClike = true;
			}
		}
		//if (Input.GetMouseButtonUp(0))
		if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Ended)
		{
		    isClike = false;
		}
		////////////////////////////////////////////////mouse//////////////////////////////////////
        if (Input.GetMouseButton(0))
        {
            this.mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

            mousepos = new Vector3(mousepos.x, mousepos.y, 0);
            if (!isClike)
            {
                obj = Instantiate(this.pointer, mousepos, Quaternion.identity) as GameObject;
                
                isClike = true;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isClike = false;
        }
		////////////////////////////////////////////////mouse//////////////////////////////////////
        
			

	
	}
}
