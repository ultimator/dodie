using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	public TextMesh overText;
	void Start () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		//if(other.tag == "pointer" && _state == RockStateEnum.act1)
		//{
		//    _state = RockStateEnum.act2;
		//}
		if(other.tag == "weapon" )
		{
			overText.text = "Game Over";
			overText.fontSize = 64;
			Instantiate(overText, new Vector3(1,2,0), Quaternion.identity);
			GamePause ();
		}
		
		
	}
	void GamePause()
	{
		Time.timeScale = 0;
	}
	// Update is called once per frame

	void Update () 
	{
		//GamePause ();
	
	}
}
