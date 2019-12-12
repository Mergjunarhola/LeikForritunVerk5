using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBullet : MonoBehaviour {


	public float Hradi =20f;
	public Rigidbody2D rb;
	void Start () {
		rb.velocity=transform.right*Hradi;
	}
	
	private void OnTriggerEnter2D(Collider2D HitInf) {
		if (HitInf.name=="player")
		{
			Debug.Log(HitInf.name);
		}
		else
		{
			Debug.Log(HitInf.name);
			Destroy(gameObject);
		}
			
	}
	
}
