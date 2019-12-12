using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public AudioClip SneezSou;
	public Transform Snoot;
	public GameObject Shot;
	private AudioSource Ananas;
	
	
	
	void Shoot(){
		Instantiate(Shot,Snoot.position,Snoot.rotation);
	}


	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
			Ananas=gameObject.AddComponent<AudioSource>();
			Ananas.clip=SneezSou;
			Ananas.Play();
		}
	}


}
