using UnityEngine;
using System.Collections;

public class Parabola : MonoBehaviour 
{
    private GameObject target;
    public float speed = 10;
    private float distanceToTarget;
    private bool move = true;
    private bool status = true;
	public bool active = true;

    void Start()
    {
        string targetName = "SpriteChest" + Random.Range(1,6).ToString();
        target = GameObject.Find(targetName);
        distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
		//rock = gameObject.GetComponent<Rock>();
        StartCoroutine(Shoot());
    }
    void OnTriggerEnter(Collider other)
    {
        
//		Rock rock = gameObject.GetComponent<Rock>();
//        if (other.tag == "pointer" || other.tag == "chest")
//        {
//            move = false;
//
//        }
        
    }

    IEnumerator Shoot()//如果rock的状态是act1则保持抛物线运动
    {

		while (active)
        {
            Vector3 targetPos = target.transform.position;
            this.transform.LookAt(targetPos);
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            //Debug.Log("jjj" + this.transform.rotation.ToString());
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            //Mathf.Clamp(-angle, -42, 42)
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            //print("currentDist" + currentDist);
            //if (currentDist < 0.5f)
                //move = false;
            
                this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            
            yield return null;
        }
    }
}
