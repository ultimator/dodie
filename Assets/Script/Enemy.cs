using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	//tk2dAnimatedSprite anim;
	tk2dSpriteAnimator anim;
	protected bool isWalk;
	protected bool isThrow;
	private float speed = 0.1f;
	private Transform m_transform;
	private float throwRate = 5f;
	private float rateTemp;
	public GameObject weapon;
	private float life = 10;
    public enum EnemyStateEnum
    {
        Walking,
        ThrowWeapon,
        Hited,
        Dead
    }
    private EnemyStateEnum _state;

    public EnemyStateEnum State
    {
        get { return _state; }
        set { _state = value; }
    }
    private Vector3 throwDirection = new Vector3( 1.0f, 0.5f, 80.0f );
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<tk2dSpriteAnimator>();
        _state = EnemyStateEnum.Walking;
		//isWalk = false;
		m_transform = transform;
		//isThrow = false;
        //GameObject.Find("MyRock");
		Invoke("ThrowWeapon",throwRate);
	
	
	}
	
	// Update is called once per frame
	void ThrowWeapon()
	{
		//isWalk = false;
		//anim.playAutomatically = false;
        _state = EnemyStateEnum.ThrowWeapon;
		anim.Play("EnemyThrow");

		//anim.animationCompleteDelegate =  ;
		anim.AnimationCompleted = ThrowCompleteDelegate;
        
		GameObject obj = (GameObject)Instantiate(weapon,m_transform.position,Quaternion.identity);
        //weapon.rigidbody.AddRelativeForce(throwDirection * 5000f);
        //obj.rigidbody.AddRelativeForce(new Vector3(-50, 0, 0), ForceMode.Impulse);
        obj.rigidbody.AddRelativeForce(new Vector3(-5.0f, 4.0f, 0.0f), ForceMode.Impulse);
        //obj.rigidbody.velocity = obj.transform.right * -3;
		Invoke("ThrowWeapon",throwRate);
		//isWalk = true;


	}
    void ThrowCompleteDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
	{
        _state = EnemyStateEnum.Walking;
		if (_state == EnemyStateEnum.Walking)
		{
			anim.Play("EnemyWalk");
		}
		else if(_state == EnemyStateEnum.Hited)
		{
			anim.Play("EnemyHited");
		}
	}
    void HitCompleteDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
    {
        _state = EnemyStateEnum.Walking;
        if (_state == EnemyStateEnum.Walking)
        {
            anim.Play("EnemyWalk");
        }
        else if (_state == EnemyStateEnum.ThrowWeapon)
        {
            anim.Play("ThrowWeapon");
        }
    }
    void DeadCompleteDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
    {
        _state = EnemyStateEnum.Dead;
        Destroy(gameObject);
 
    }

	void OnTriggerEnter(Collider other)
	{
        Rock rock = other.GetComponent<Rock>();
        //Debug.Log(this.life);
		if(other.tag == "weapon" && rock.enWeapon == 0)
		{
            _state = EnemyStateEnum.Hited;
			anim.Play("EnemyHited");
            anim.AnimationCompleted = HitCompleteDelegate;
			
			this.life = life - rock.power;
            //Debug.Log(life.ToString());
			if(life <= 0)
			{
                anim.Play("EnemyDead");
                anim.AnimationCompleted = DeadCompleteDelegate;
			}
            
		}
	}


	void Update () 
	{


        if (anim != null)
        {


            if (_state == EnemyStateEnum.Walking)
            {

                anim.Play("EnemyWalk");
                
            }



        }
			if(_state == EnemyStateEnum.Walking)
			{
				m_transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
				


			}


			

		
	
	}
}
