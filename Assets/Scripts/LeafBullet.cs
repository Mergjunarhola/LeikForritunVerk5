using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBullet : MonoBehaviour {


	public float Hradi =20f;
	public Rigidbody2D rb;
	public int damage = 30;
	void Start () {
		rb.velocity=transform.right*Hradi;
	}
	
	private void OnTriggerEnter2D(Collider2D HitInf) {
		EnemyScript enemy = HitInf.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			Debug.Log("Sneez");
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}

		
			
	}
	
}
