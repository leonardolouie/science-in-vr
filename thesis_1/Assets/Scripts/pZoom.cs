using UnityEngine;

public class pZoom : TouchLogic {

	public float zoomSpeed = 5.0f;

	private Vector2 currTouch1 = Vector2.zero,
	lastTouch1 = Vector2.zero,
	currTouch2 = Vector2.zero,
	lastTouch2 = Vector2.zero;

	private float currDist = 0.0f,
	lastDist = 0.0f;

	public static float zoomFactor = 0.0f;
	void OnTouchMovedAnywhere()
	{
		Zoom ();
	}
	void OnTouchStayAnywhere()
	{
		Zoom ();
	}

	void Zoom()
	{
		switch (TouchLogic.currTouch)
		{
		case 0:
			currTouch1 = Input.GetTouch (0).position;
			lastTouch1 = currTouch1 - Input.GetTouch (0).deltaPosition;
			break;
		case 1:
			currTouch2 = Input.GetTouch (1).position;
			lastTouch2 = currTouch2 - Input.GetTouch (1).deltaPosition;
			break;
		}

		if (TouchLogic.currTouch >= 1) {
			currDist = Vector2.Distance (currTouch1, currTouch2);
			lastDist = Vector2.Distance (lastTouch1, lastTouch2);
		} 
		else 
		{
			currDist = 0.0f;
			lastDist = 0.0f;
		}

		zoomFactor = Mathf.Clamp (lastDist - currDist, -30.0f, 30.0f);

		Camera.main.transform.Translate (Vector3.back * zoomFactor * zoomSpeed * Time.deltaTime);
		


	}
}
