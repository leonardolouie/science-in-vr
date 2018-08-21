using UnityEngine;

public class cameraOrbit : MonoBehaviour {
	private Touch touch = new Touch();
	protected Transform xFormCamera;
	protected Transform xFormaParent;

	protected Vector3 localRotation;
	protected float cameraDistance = 719;

	public float mouseSensitivity = 4f;
	public float scrollSensitivity = 2f;
	public float orbitDampening = 10f;
	public float scrollDampening = 6f;

	public bool cameraDisabled = false;

	// Use this for initialization
	void Start () {
		this.xFormCamera = this.transform;
		this.xFormaParent = this.transform.parent;
	}
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			cameraDisabled = !cameraDisabled;
		}

		if (!cameraDisabled) {
			//turnoff the ZOOM AND ROTATION OF CAMERA
		}

		switch(Input.touchCount) {
		case 1:
			Touch t = Input.GetTouch (0);
			if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary) {
				localRotation.x += t.deltaPosition.x * mouseSensitivity;
				localRotation.y -= t.deltaPosition.y * mouseSensitivity;

				//clamp the y rotation to horizon  and not flipping over at the top
				localRotation.y = Mathf.Clamp (localRotation.y, 0f, 90f);
			}
			break;
		case 2:
			float scrollAmount = pZoom.zoomFactor * -1f * scrollSensitivity * Time.deltaTime;

			// make camera zoom faster the further away it is from the target 
			scrollAmount *= (this.cameraDistance * 0.3f);
			this.cameraDistance += scrollAmount * -1f;
			//this is the boundaries
			this.cameraDistance = Mathf.Clamp (this.cameraDistance, 200f, 1500f);
			break;
		}

		Quaternion QT = Quaternion.Euler (localRotation.y, localRotation.x, 0);
		this.xFormaParent.rotation = Quaternion.Lerp (this.xFormaParent.rotation, QT, Time.deltaTime * orbitDampening);

		if (this.xFormCamera.localPosition.z != this.cameraDistance * -1f) {
			this.xFormCamera.localPosition = new Vector3 (0f, 0f, Mathf.Lerp (this.xFormCamera.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollDampening));
		}

	}
}
