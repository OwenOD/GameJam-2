using UnityEngine;
using System.Collections;

//put this component on camera
//drag target object (ball) onto the TargetObject public variable
public class CameraFollow : MonoBehaviour
{
	public GameObject player;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}