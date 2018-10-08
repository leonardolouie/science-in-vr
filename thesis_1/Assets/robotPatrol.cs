using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class robotPatrol : MonoBehaviour {



	//public static bool ret;
	private bool gazeAt;
	bool robotSelected;
	float gazeTime = 2f;
	private float timer,timers;

	Transform vrCamera;




	Animator robotAnim;

	public static bool isLookingAt;
	public Transform pathParent,lookParent;
	public Transform[] target;

	Transform targetPoint;
	public int index = 0,flag;

	public float speed = 3f;
	public float rotSpeed = 50f;
	Quaternion lookAt;

	public bool isWalking,isTurning,idling;
	public int animationRandom;

	void Update () {
		if (gazeAt) {
			timer += Time.deltaTime;
			if (timer >= gazeTime){
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}
		}
	}
	public void PointerEnter(){
		gazeAt = true;
		isLookingAt = true;
		robotAnim.SetInteger ("anim", 0);
		//ret = true;
	}
	public void PointerDown(){
		gazeAt = false;
		robotSelected = true;
	}
	public void PointerExit(){
		timers = 0f;
		timer = 0f;
		gazeAt = false;
		robotAnim.SetInteger ("anim", 0);
		float x = Random.Range (1f, 4f);
		Invoke ("lookAway", x);
		//ret = false;
	}

	void lookAway(){
		isLookingAt = false;
		isTurning = true;
	}

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a=0; a<pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a+1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 50, 0);
			Gizmos.DrawLine (from, to);
		}
	}
	void Start () {
		vrCamera = GameObject.FindWithTag ("MainCamera").transform;
		robotAnim = GetComponent<Animator> ();
		idling = true;
	}
	void moveRobot(){

		//animation walking goes here

		if (transform.position != target [index].position) {
			transform.position = Vector3.MoveTowards (transform.position, target [index].position, speed * Time.deltaTime);
		} else {
			robotAnim.SetInteger ("anim", 0);
			index = (index + 1) % target.Length;
			isWalking = false;
			animationRandom = Random.Range (1, 4);
			if (animationRandom < 3) {
				animationRandom = Random.Range (1, 15);
				idling = true;
			} else {
				robotAnim.SetInteger ("anim", 3);
				isTurning = true;
			}
		}
	}
		

	void rotateRobot(){
		Vector3 direction = (target[index].position - transform.position).normalized;
		lookAt = Quaternion.LookRotation (direction);
	
		/*transform.rotation.y = Quaternion.RotateTowards (transform.rotation, lookAt, rotSpeed * Time.deltaTime).y;
		if (transform.rotation.y == lookAt.y) {
			isTurning = false;
			robotAnim.SetInteger ("anim", 0);
			//Debug.Log ("turning");
			animationRandom = Random.Range (1, 4);
			if (animationRandom != 3) {
				StartCoroutine (waitForSeconds());
			} else {
				animationRandom = Random.Range (1, 10);
				idling = true;
			}
		}*/
	}

	IEnumerator waitForSeconds(){
		float a = Random.Range (1f, 10f);
		yield return new WaitForSeconds (a);

		isWalking = true;
		robotAnim.SetInteger("anim",3);
	}



	void idleRobot(){
		if (animationRandom < 5) {
			StartCoroutine (animateIdle ());
		} 
		else{
			isTurning = true;
			robotAnim.SetInteger ("anim", 3);
		}
	}

	IEnumerator animateIdle(){

		yield return new WaitForSeconds (2f);

		int idleRandom = Random.Range (1,3);
		robotAnim.SetInteger ("anim", idleRandom);
		//AnimatorClipInfo[] currentClip = robotAnim.GetCurrentAnimatorClipInfo (0);
		Debug.Log ("idle animating....");
		yield return new WaitForSeconds (5f);

		robotAnim.SetInteger ("anim", 0);
		Debug.Log ("done idling");
		int r = Random.Range (1, 3);
		if (r == 1) {
			idleRobot ();
		}
		else {
			float j = Random.Range (0, 5f);
			yield return new WaitForSeconds (j);
			robotAnim.SetInteger ("anim", 3);
			isTurning = true;

		}
	}
		





	void LateUpdate () {

		if (!isLookingAt) {
			if (isWalking) {
				moveRobot ();
			} else if (isTurning) {
				rotateRobot ();
			} else if (idling) {
				idleRobot ();
				idling = false;
			}
		} else {
			StopAllCoroutines ();
			isTurning = false;
			isWalking = false;
			idling = false;
			timers += Time.deltaTime;
			if (timers >= 2f){
				lookAtPlayer ();
				timer = 0f;
			}

		}
	}
	void lookAtPlayer(){
		robotAnim.SetInteger ("anim", 3);
		Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
		lookAt = Quaternion.LookRotation (direction);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, rotSpeed * Time.deltaTime);
		if (transform.rotation == lookAt) {
			//move towards
			if (robotSelected) {
				transform.position = Vector3.MoveTowards (transform.position, vrCamera.position, speed * Time.deltaTime);
				if (Vector3.Distance(transform.position,vrCamera.position) < 2f) {
					StartCoroutine (delayy ());
				}
			}
		}
	}

	IEnumerator delayy(){
		float x = Random.Range (15f, 20f);
		yield return new WaitForSeconds (x);
		robotSelected = false;
	}
	
}
