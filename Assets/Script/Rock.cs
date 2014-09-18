using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour 
{
	public float speed = 5;
	public bool isShot = false;
	private Transform mTransform;
	public float power = 3;
    public float enWeapon = 1;
	private float temp;
    public enum RockStateEnum
    {
        act1,
        act2
    }
    private RockStateEnum _state;

    public RockStateEnum State
    {
        get { return _state; }
        set { _state = value; }
    }
	// Use this for initialization
	void Start () 
	{
        _state = RockStateEnum.act1;
		mTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (_state == RockStateEnum.act2)
        {
            mTransform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
			


	
	}
	void OnTriggerEnter(Collider other)
	{
        //if(other.tag == "pointer" && _state == RockStateEnum.act1)
        //{
        //    _state = RockStateEnum.act2;
        //}
		if(other.tag == "enmey" || other.tag == "bund" )
		{
			Destroy(gameObject);
		}
        

	}
}
