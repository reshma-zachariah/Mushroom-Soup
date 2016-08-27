using UnityEngine;
using System.Collections;

public class MushroomCounter : MonoBehaviour {
	private Animator anm;

	private int numMushrooms;

	// Use this for initialization
	void Start () {
		anm = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			
			numMushrooms += 1;
			print ("+1 mushroom");

			anm.SetInteger ("numMushrooms", numMushrooms);
		}
	}
}
