using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
public GameObject player;

	public Vector3 offset;

	public bool horizontal = true;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Vector3 temp = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);


		transform.position = player.transform.position + offset;

		//if (horizontal) {
			//transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), 20 * Time.deltaTime);
		//}
		//else {
			//transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), 20 * Time.deltaTime);
		//}
	}

}
