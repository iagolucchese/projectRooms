using UnityEngine;
using System.Collections;

public class pressurePlateAnimation : MonoBehaviour {

	public GameObject triggeredBy;
	public float lengthOfAnimation = 1f;
	public float sinkAmount = 0.09f;

	private float timeElapsed = float.PositiveInfinity;
	private bool triggered = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (timeElapsed <= lengthOfAnimation) {
			timeElapsed += Time.deltaTime;

			transform.position -= new Vector3(0,Mathf.Lerp(0,sinkAmount*Time.deltaTime,timeElapsed/lengthOfAnimation),0); //shifts the plate in the Y axis
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals(triggeredBy) && !triggered) {
			timeElapsed = 0;
			triggered = true;
		}
	}
}
