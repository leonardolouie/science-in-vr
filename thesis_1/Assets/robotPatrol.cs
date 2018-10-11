using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class robotPatrol : MonoBehaviour {

	public int distance;

	private int randomizer = 0;

	private bool isLooking;


	private int state;
	public int index = 0;

	private bool gazeAt,robotStart;
	bool robotSelected;

	public float speed = 3f;
	public float rotSpeed = 50f;

	float gazeTime = 2f;
	private float timer,timerLook;


	Transform vrCamera;
	Animator robotAnim;
	public Transform pathParent;//,lookParent; for gizmoz
	public Transform[] target;
	Transform targetPoint;
	Quaternion lookAt;

	public void PointerEnter(){
		gazeAt = true;
	}
	public void PointerDown(){
		gazeAt = false;
		robotSelected = true;
		isLooking = true;
	}
	public void PointerExit(){
		timer = 0f;
		gazeAt = false;
	}

	void Start () {
		vrCamera = GameObject.FindWithTag ("vrCamera").transform;
		robotAnim = GetComponent<Animator> ();
		StartCoroutine (startRobot ());
	}

	IEnumerator startRobot(){
		yield return new WaitForSeconds (robotAnim.GetCurrentAnimatorStateInfo (0).length + 5);
		robotStart = true;
		state = 1;
	}

	void Update () {
		if (gazeAt) {
			timer += Time.deltaTime;
			if (timer >= gazeTime){
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}
		}
			
		if (!isLooking) {
			if (robotStart) {
				switch (state) {
				case 1:
					robotAnim.SetInteger ("anim", 1);
					rotateRobot ();
					break;
				case 2:
			//idle goes heer
						robotAnim.SetInteger ("anim", 0);
						StartCoroutine (idling ());
					
					break;
				default:
					robotAnim.SetInteger ("anim", 1);
					moveRobot ();
					break;
				}
			}
		} else {
			robotAnim.SetInteger ("anim", 1);
			robotAnim.speed = 1.5f;
			Vector3 direction = (vrCamera.position - transform.position).normalized;
			lookAt = Quaternion.LookRotation (direction);
			direction.y = 0;
			transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, rotSpeed * Time.deltaTime);
			if (transform.rotation == lookAt) {
				transform.position = Vector3.MoveTowards (transform.position,vrCamera.position, speed * Time.deltaTime);
				
				robotAnim.speed = 1f;
				if (Vector3.Distance (transform.position, vrCamera.position) < distance) {
					robotAnim.SetInteger ("anim", 0);
					timerLook += Time.deltaTime;
					if (timerLook > 30f){
						state = 1;
						isLooking = false;
						timerLook = 0f;
					}
				}

			}
		}
		
	}

	IEnumerator idling(){
		int x = Random.Range (1, 10);
		yield return new WaitForSeconds (x);
		state = 0;
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

	void moveRobot(){
			if (transform.position != target [index].position) {
			
				transform.position = Vector3.MoveTowards (transform.position, target [index].position, speed * Time.deltaTime);
			} 
			else
			{
				
				index = (index + 1) % target.Length;
				state = 1;
			}
	}
	void rotateRobot(){
		robotAnim.speed = 1.5f;
		Vector3 direction = (target[index].position - transform.position).normalized;
		lookAt = Quaternion.LookRotation (direction);
		direction.y = 0;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAt, rotSpeed * Time.deltaTime);
		if (transform.rotation == lookAt) {
			robotAnim.speed = 1f;
			state = 0;
				
		}
	}
}
