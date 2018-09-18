using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scivreAi : MonoBehaviour {


	public Transform neck,body;
	Transform startNeck,startBody;

	Transform player;
	public float moveSpeed = 3f;
	public float rotSpeed = 100f;
	private Animator anim;
	private bool isWandering = true;
	private bool isRotatingLeft = false;
	private bool isRotatingRight = false;
	private bool isWalking = false;
	bool onEnter;


	private float stoppingDistance = .5f;
	private float timer;
	public float delay = 2f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	public void onenter(bool a) {
		onEnter = a;
	}


	IEnumerator lookToPlayer(){
		startNeck = neck;
		startBody = body;
		Vector3 direction = player.position - transform.position;
		direction.y = 0;
		this.neck.rotation = Quaternion.Slerp (this.neck.rotation,
			Quaternion.LookRotation (direction), 0.05f);
		yield return new WaitForSeconds (5f);
		anim.SetInteger ("robot", 1);
		this.body.rotation = Quaternion.Slerp (this.body.rotation,
			Quaternion.LookRotation (direction), 0.05f);
		yield return new WaitForSeconds (1f);
		anim.SetInteger ("robot", 0);


		/*
		timer += Time.deltaTime;
		if (Vector3.Distance (transform.position, player.position) > stoppingDistance) {
			if (timer >= 4f) {
				transform.position = Vector3.MoveTowards (transform.position, player.position, moveSpeed * Time.deltaTime);
				anim.SetInteger ("robot", 1);
			}
		}*/
	}

	void FixedUpdate(){


		if (onEnter) {
			StartCoroutine (lookToPlayer());
		}




		if (isWandering) {
			//IDLE ANIMATION
			//StartCoroutine (walking());

		}


		/*
		if (isRotatingRight == true) {
			//animation right goes here aj tandaan mo yan
			anim.SetInteger ("robot", 1);
			transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
		}	
		if (isRotatingLeft == true) {
			//animation Left goes here aj tandaan mo yan
			anim.SetInteger ("robot", 1);
			transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
		}
		if (isWalking == true) {
			anim.SetInteger ("robot", 1);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}*/
	}

	/*
	IEnumerator walking(){
		float rotTime = Random.Range (1f,3f);
		float rotateWait = Random.Range (4f,7f);
		int rotateLorR = Random.Range (1,3);
		float walkWait = Random.Range (3f,8f);
		float walkTime = Random.Range (1f,3f);

		isWandering = false;
		yield return new WaitForSeconds (walkWait);
		isWalking = true;
		yield return new WaitForSeconds (walkTime);
		isWalking = false;
		anim.SetInteger ("robot", 0);
		yield return new WaitForSeconds (rotateWait);
		if (rotateLorR == 1) {
			isRotatingRight = true;
			yield return new WaitForSeconds (rotTime);
			isRotatingRight = false;
		}

		if (rotateLorR == 2) {
			isRotatingLeft = true;
			yield return new WaitForSeconds (rotTime);
			isRotatingLeft = false;
		}
		anim.SetInteger ("robot", -1);
		isWandering = true;
	}
	*/

}
