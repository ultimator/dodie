using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance = null;
	// Use this for initialization
	public GameObject box;
	public GameObject pointer;
	private Vector3 mousepos;
	private bool isClike;
	public GameObject obj;
	public GameObject rock;
	private float rate = 5;
    
    public TextMesh text;
	private int enemyLive;
	private int enemyWave;
	private int enemyTotalWave;
	public TextMesh textLive;
	public TextMesh textWave;
	public TextMesh textTotalWave;

	public tk2dTileMap tileMap;
	Ray ray;
	RaycastHit hit;
	private Rock rockObj;
	private Parabola para;
	private tk2dTiledSprite tSprite;

	//private SpawnData spawnData;
	//private ArrayList enemylist;
	private int enemywave;

	public int EnemyLive {
		get {
			return enemyLive;
		}
		set {
			enemyLive = value;
			//textLive.text = "还剩" + enemyLive.ToString() + "个敌人";
			textLive.text = "Live:" + enemyLive.ToString();
			//gameObject.find("textLive");
		}
	}
	public int EnemyWave {
		get {
			return enemyWave;
		}
		set {
			enemyWave = value;
			textWave.text = "Wave:" + enemyWave.ToString();
		}
	}
	
	public int EnemyTotalWave {
		get {
			return enemyTotalWave;
		}
		set {
			enemyTotalWave = value;
			textTotalWave.text = "TotalWave:" + enemyTotalWave.ToString();
		}
	}
	void Awake() 
	{

		if(instance == null)
		{
			instance = this;
		}
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
		//dill//dill//dill
	}

	void Start () 
	{

		isClike = false;
        //for (int i = 0; i < 5; i++)
        //{
        //    Instantiate(enemy, new Vector3(5f, 0.8f * i, 0f), Quaternion.identity);
        //}
        
		enemywave = 1;

		//EnemySpawner.instance.SendEnemy();

		//eSpawner = gameObject.GetComponent<EnemySpawner>();

		//eSpawner.m_enemyList[1]

		//Debug.Log(eSpawner.m_enemyList[1]);

        
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
//		if(Input.GetMouseButtonDown(0))
//		{
//			rock.collider.bounds.
//			Debug.Log("down");
//		}
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				GameObject obj;
//				obj = hit.collider.gameObject.transform.parent.gameObject;
//				if(obj == null)
//				{
					obj = hit.collider.gameObject;
				Debug.Log(tileMap.data.tileSize);
				//}

				rockObj = obj.GetComponent<Rock>(); //取不到值？？？？？
				para = obj.GetComponent<Parabola>();
				Debug.Log(obj.name);
				Debug.Log(hit.collider.gameObject.name);
				Debug.Log(rockObj);
				//if(rockObj != null)
				if(obj.tag == "ground")
				{
					tSprite = obj.GetComponent<tk2dTiledSprite>();
					tSprite.color = Color.yellow;

				}
				//obj.gameObject.
				if(rockObj != null )
				{
					rockObj.State = Rock.RockStateEnum.act4;
					//para.active = false;
					Debug.Log(hit.collider.gameObject.name);
				}
			}
//			Ray ray;
//			RaycastHit hit;
//
//				if (Input.GetMouseButton(0))
//				{
//					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//					if (Physics.Raycast(ray, out hit))
//						Debug.Log(hit.collider.gameObject.name);
//				}


		}

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
