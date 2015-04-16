using UnityEngine;
using System.Collections;

//using System.IO;
//using System.Text;

//using System.Xml;
//using xmlParser;

public class EnemySpawner : MonoBehaviour
{
	public static EnemySpawner instance = null;
	//保存所有的从XML读取的数据 
	private ArrayList m_enemyList;
	//距离下一个敌人出场的时间
	private float m_timer = 0;
	//出场敌人的序列号
	int m_index = 0;
	//当前波的敌人数量，只有销毁当前波内的所有敌人，才能进入下一波。
	public int m_liveEnemy = 0;
	//XMLParser
	public TextAsset xmlData;
	private SpawnData enemyData;

	//敌人
	private GameObject  enemyObj;
	public EnemyTable[] m_enemies;
	float tep;
	string eneName;
	//public PathNode m_startNode;
	//存储敌人出场顺序的xml
	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		ReadXML();
	}

	//public PathNode m_startNode;


		// Use this for initialization
	void Start ()
	{
		//enemyObj = Instantiate(Resources.Load("Enemy", typeof(GameObject))) as GameObject;
		//Debug.Log (enemyObj);
		//m_enemyList = new ArrayList();
		//TextAsset xmlData =(TextAsset)Resources.Load("EnemyData",System.Xml);

		//读取XML中敌人数据
		//ReadXML();
		//生成敌人
		//Invoke("SendEnemy", 8);

		SpawnData sData = (SpawnData)m_enemyList[m_enemyList.Count - 1];
		//Debug.Log (sData.wave);
		GameControl.instance.EnemyTotalWave = sData.wave;

	
	
	}
	void ReadXML()
	{
		//m_enemyList = new ArrayList

		//string str = File.ReadAllText(@"d:\EnemyData.xml", Encoding.UTF8);   //读取XML文件  
		m_enemyList = new ArrayList();

		XMLParser xmlparse = new XMLParser();

		XMLNode node = xmlparse.Parse(xmlData.text);
		XMLNodeList list = node.GetNodeList("ROOT>0>table");



		for (int i = 0; i < list.Count; i++) 
		{
			string wave = node.GetValue("ROOT>0>table>" + i + ">@wave");
			//Debug.Log(wave);
			string enemyname = node.GetValue("ROOT>0>table>" + i + ">@enemyname");
			string level = node.GetValue("ROOT>0>table>" + i + ">@level");
			string wait = node.GetValue("ROOT>0>table>" + i + ">@wait");

			SpawnData data = new SpawnData();
			data.wave = int.Parse(wave);
			data.enemyName = enemyname;
			data.level = int.Parse(level);
			data.wait = float.Parse(wait);
			Debug.Log(data.enemyName);
			m_enemyList.Add(data);

		}
		 
	}

		
		// Update is called once per frame
	void SendEnemy()
	{
		//Debug.Log (enemyData.wait);

		if(m_index >= m_enemyList.Count)
		{
			return;
		}
		//第一次刷新敌人，初始化
		//Debug.Log (m_index);
		//Debug.Log (m_timer);
		if(m_index == 0 && m_timer == 0)
		{
			enemyData = (SpawnData)m_enemyList[m_index];
			//SpawnData data = (SpawnData)m_enemyList[m_index];
			m_timer = enemyData.wait;
			GameControl.instance.EnemyWave = enemyData.wave;

			//Debug.Log(enemyData.wait);

			//Debug.Log(enemyData.wait);
		}


		if(enemyData.wave > GameControl.instance.EnemyWave && GameControl.instance.EnemyLive > 0)
		{
			return;
			
		}
		else if(enemyData.wave > GameControl.instance.EnemyWave && GameControl.instance.EnemyLive == 0)
		{
			GameControl.instance.EnemyWave++;
		}

		//不满足延迟时间则返回

		Debug.Log (m_timer);
		m_timer = m_timer - Time.deltaTime ;
		//m_timer = m_timer - 0.02f;
		if(m_timer > 0)
		{
			return;
		}

		//满足延迟时间刷新下一个敌人

		eneName = enemyData.enemyName;

		enemyObj =  Instantiate(Resources.Load(eneName,typeof(GameObject))) as GameObject;
		string spawnName;
		spawnName = "EnemySpawner" + enemyData.level;
		Debug.Log (spawnName);
		GameObject obj = GameObject.Find(spawnName);


		//tep = Time.deltaTime;
		//m_timer = m_timer - (1.0f * Time.deltaTime);
		enemyObj.transform.position = obj.transform.position;
		//Instantiate(enemyObj, obj.transform.position, Quaternion.identity);
		GameControl.instance.EnemyLive++;
		m_index++;
		if(m_index >= m_enemyList.Count)
		{
			return;
		}
		enemyData = (SpawnData)m_enemyList[m_index];
		m_timer = enemyData.wait;






		//GameControl.instance.EnemyWave = enemyData.wave;
		//Debug.Log (m_timer);




		//int i;
		//i = Random.Range(1, 6);
		//Debug.Log(i.ToString());

		//Debug.Log (obj);
		
		//Instantiate(enemy, new Vector3(5f, 0.6f * i, 0f), Quaternion.identity);

		//Invoke("SendEnemy", 8);
		
	}
	void Update ()
	{
		SendEnemy();
	
	}

	[System.Serializable]
	public class EnemyTable
	{
		public string enemyName = "";
		public Transform enemyPrefab;
	}
	public class SpawnData 
	{
		public int wave = 1;
		public string enemyName = "";
		public int level = 1;
		public float wait = 1.0f;
	}

}

