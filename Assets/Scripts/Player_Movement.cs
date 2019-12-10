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
	
	
	
	void Update () {
		HorizontalMove= Input.GetAxisRaw("Horizontal")* GaunguHradi;

		animator.SetFloat("Speed",Mathf.Abs(HorizontalMove));


		if (Input.GetButtonDown("Jump")& !RelCrouch)
		{
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
		if (Fart==1)
		{
		animator.SetBool("IsJumping",false);
		}
		Fart++;
		
	}
	public void OnCrouch(bool isCrouching){
		RelCrouch=isCrouching;
		animator.SetBool("IsCrouch",isCrouching);
	}

	
	void FixedUpdate() {
		controller.Move(HorizontalMove* Time.fixedDeltaTime,crouch,jump);
		jump=false;
	}
}
