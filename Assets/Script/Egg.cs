using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		//if(other.tag == "pointer" && _state == RockStateEnum.act1)
		//{
		//    _state = RockStateEnum.act2;
		//}
		if(other.tag == "weapon")
		{
			//Destroy(gameObject);
		}
		
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
