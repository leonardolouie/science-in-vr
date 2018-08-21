
using UnityEngine;

public class selectPlanet : MonoBehaviour {

	public Transform pivot;
	public int planetNumber = 0;
	void Update(){
		if (planetNumber < 10 && planetNumber > 0) {
			switch (planetNumber) {
			case 1:
				pivot.transform.position = transform.position;
				break;
			case 2:
				pivot.transform.position = transform.position;
				break;
			case 3:
				pivot.transform.position = transform.position;
				break;
			case 4:
				pivot.transform.position = transform.position;
				break;
			case 5:
				pivot.transform.position = transform.position;
				break;
			case 6:
				pivot.transform.position = transform.position;
				break;
			case 7:
				pivot.transform.position = transform.position;
				break;
			case 8:
				pivot.transform.position = transform.position;
				break;

			default:
				pivot.transform.position = pivot.position;
				break;
			}
		}

	}

}
