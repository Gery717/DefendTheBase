using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerController : MonoBehaviour 
{
	public BulletController bullet;
	public float interval = 2.0f;
	float timeLeft = 0.0f;
	public float range;
	EnemyMovementScript target;
	public GameObject rangeSphere;
	public bool isSlower;

	EnemyMovementScript findClosestTarget(bool includePrevious) 
	{	
		EnemyMovementScript closest = null;
		
		Vector3 pos = transform.position;
			
		EnemyMovementScript[] allEnemies = (EnemyMovementScript[])FindObjectsOfType(typeof(EnemyMovementScript));
		
		if (allEnemies != null) 
		{	
			if (allEnemies.Length > 0) 
			{		
				closest = allEnemies[0];
				
				for (int i = 1; i < allEnemies.Length; ++i) 
				{	
					float cur = Vector3.Distance(pos, allEnemies[i].transform.position);				
					float old = Vector3.Distance(pos, closest.transform.position);
				
					if (cur < old) 
					{
						closest = allEnemies[i];	
					}

					if (allEnemies[i] == target && includePrevious)
						return allEnemies[i];
				}	
			}
		}
		return closest;	
	}

	void Update() 
	{

		if (GameController.showRange)
		{
			rangeSphere.SetActive (true);
			if (!isSlower)
				rangeSphere.transform.localScale = new Vector3 (range / 3, range / 3, range / 3);
			else
				rangeSphere.transform.localScale = new Vector3 (range / 10, range / 10, range / 10);
		} 
		else 
		{
			rangeSphere.SetActive(false);
		}
		if (GameController.EnemyOnField > 0) 
		{
			timeLeft -= Time.deltaTime;

			target = findClosestTarget (true);
			if (target != null && Vector3.Distance (transform.position, target.transform.position) > range)
				target = findClosestTarget (false);

			if ((target != null && !isSlower) || (isSlower && !target.isSlowed)) 
			{      
				transform.LookAt (target.transform.position);

				if (timeLeft <= 0.0f) 
				{	
					if (Vector3.Distance (transform.position, target.transform.position) < range) 
					{
						GameObject g = (GameObject)Instantiate (bullet.gameObject, new Vector3 (transform.position.x, transform.position.y + 20, transform.position.z), Quaternion.identity);				
						BulletController b = g.GetComponent<BulletController> ();
						b.setDestination (target.transform);
						timeLeft = interval;	
					}	
				}	
			} 
		}
	}
}
