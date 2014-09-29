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
    
	void Awake() 
	{
		Debug.Log (Application.platform);
		
		#if UNITY_ANDROID
		Debug.Log("this is android");
		#endif
		
		#if UNITY_IPHONE
		Debug.Log("this is ios");
		#endif

		#if UNITY_STANDALONE_WIN
		Debug.Log("this is win");
		#endif        
		//dill
	}

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
        //Debug.Log(i.ToString());
        Instantiate(enemy, new Vector3(5f, 0.6f * i, 0f), Quaternion.identity);
        Invoke("SendEnemy", 8);
 
    }
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_IPHONE
		int i = 0;
		    
		if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
		    isClike = false;
		}
		#endif

		#if UNITY_STANDALONE_WIN
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
		#endif
		
		
		
	}
}
