using UnityEngine;
using System.Collections;

public class RandomOffsetMotion : MonoBehaviour {

	public float speed = 0.1f;
	public float maxDist = 4f;
	public float angularSpeed = 0.1f;

	private Vector3 origLocalPos;

	private float lastAngle;
	private Vector2 lastVelocity;

	void Start () {
		origLocalPos = transform.localPosition;
		lastAngle = Random.value * 2 * Mathf.PI;
		lastVelocity = Vector2.zero;
	}

	void Update () {

		var offset = transform.localPosition - origLocalPos;

		var maxAngleDif = angularSpeed * Time.deltaTime;
		var angleDif = Random.value * maxAngleDif;
		var angle = lastAngle + angleDif - maxAngleDif/2;


		var dir = maxDist * new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle)) - new Vector2 (offset.x, offset.y);

		if (dir.magnitude > maxDist)
			dir = dir.normalized * maxDist;


		var velocity = lastVelocity + dir * speed * Time.deltaTime * (0.5f + Random.value);

		var newPos = transform.localPosition + new Vector3 (velocity.x, velocity.y);
		transform.localPosition = newPos;


		lastAngle = angle;
		lastVelocity = velocity;
	}
}
