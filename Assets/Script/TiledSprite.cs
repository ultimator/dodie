using UnityEngine;
using System.Collections;

public class TiledSprite : MonoBehaviour {

	private tk2dTiledSprite tSprite;
	// Use this for initialization
	void Start () 
	{

		tSprite = gameObject.GetComponent<tk2dTiledSprite>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter()
	{

		tSprite.color = Color.yellow;
		//test
		//ok
		
	}
	void OnMouseExit()
	{
		tSprite.color = Color.white;
		
	}
}
