using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	public CharacterController2D controller;
	public Animator animator;
	public float GaunguHradi= 40f;
	float HorizontalMove = 0f;
	bool jump = false;
	bool crouch =false;
	bool RelCrouch=false;
	int Fart= 1;
	public Transform Snoot;

	public AudioClip FartSou;
	
	private AudioSource Ananas;
	
	
	void Update () {
		HorizontalMove= Input.GetAxisRaw("Horizontal")* GaunguHradi;

		animator.SetFloat("Speed",Mathf.Abs(HorizontalMove));


		if (Input.GetButtonDown("Jump")& !RelCrouch)
		{	
			Ananas=gameObject.AddComponent<AudioSource>();
			Ananas.clip=FartSou;
			Ananas.Play();
			jump=true;
			Fart=0;
			animator.SetBool("IsJumping",true);
		}
		if (Input.GetButtonDown("Crouch"))
		{
			crouch=true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch=false;
		}
	}
	public void OnLanding(){
		Debug.Log("Fart");
		//if (Fart==1){
		animator.SetBool("IsJumping",false);
		//}Fart++;
		
	}
	public void OnCrouch(bool isCrouching){
		RelCrouch=isCrouching;
		if (RelCrouch)
		{
			Snoot.localPosition=new Vector3(0.111f,-0.101f,0f);
		}
		else
		{
			Snoot.localPosition=new Vector3(0.076f,-0.043f,0f);
		}
		animator.SetBool("IsCrouch",isCrouching);
	}

	
	void FixedUpdate() {
		controller.Move(HorizontalMove* Time.fixedDeltaTime,crouch,jump);
		jump=false;
	}
}
