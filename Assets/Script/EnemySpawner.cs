using UnityEngine;
using System.Collections;

//using System.IO;
//using System.Text;

//using System.Xml;
//using xmlParser;

public class EnemySpawner : MonoBehaviour
{
	//保存所有的从XML读取的数据 
	ArrayList m_enemyList;
	//距离下一个敌人出场的时间
	float m_timer = 0;
	//出场敌人的序列号
	int m_index = 0;
	//当前波的敌人数量，只有销毁当前波内的所有敌人，才能进入下一波。
	public int m_liveEnemy = 0;
	//XMLParser
	public TextAsset xmlData;

	//敌人
	public EnemyTable[] m_enemies;
	//public PathNode m_startNode;
	//存储敌人出场顺序的xml


	//public PathNode m_startNode;


		// Use this for initialization
	void Start ()
	{
		//m_enemyList = new ArrayList();
		//TextAsset xmlData =(TextAsset)Resources.Load("EnemyData",System.Xml);

		ReadXML();
	
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
	void Update ()
	{
	
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

