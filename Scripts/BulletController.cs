using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	Transform destination;
	public float power;
	public bool isSlower;

	void Start () 
	{
	
	}

	void FixedUpdate () 
	{
		if (destination == null) 
		{	
			Destroy(gameObject);
			return;	
		}

		float stepSize = Time.deltaTime * speed;	
		transform.position = Vector3.MoveTowards(transform.position, destination.position, stepSize);

		if ((Vector3.Distance(transform.position, destination.position) <= 10.0)) 
		{	
			EnemyMovementScript enemy = destination.GetComponent<EnemyMovementScript>();
			if (isSlower)
				enemy.Slow();
			else
				enemy.Attack(power);		         
			Destroy(gameObject);
		}
	}

	public void setDestination(Transform t) 
	{
		destination = t;	
	}
}
