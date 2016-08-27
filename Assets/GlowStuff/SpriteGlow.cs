using UnityEngine;
using System.Collections;

public class SpriteGlow : MonoBehaviour {

	public GameObject glowPrefab;
	public Material translucentMaterial;

	public int numIterations = 4;

	public Color startColor = Color.white;
	public Color endColor = Color.white;

	public float startTransparency = 0.2f;
	public float endTransparency = 0.05f;

	public float scaleIncrement = 0.1f;

	void Start () {

		var mySrnd = GetComponent<SpriteRenderer> ();
		var mySprite = mySrnd.sprite;


		// Create material copies and set their properties
		for (int i = 0; i < numIterations; i++) {

			// Create material
			var mat = new Material (translucentMaterial);


			// Interpolate between start and end values
			var p = (float)i / (numIterations - 1);
			var color = startColor + (endColor - startColor) * p;
			var transparency = startTransparency + (endTransparency - startTransparency) * p;


			// Set properties
			mat.SetColor ("_Tint", color);
			mat.SetFloat ("_Transparency", transparency);



			// Create child sprite
			var newSprite = Instantiate (glowPrefab) as GameObject;
			newSprite.name = "AUTO_Glow" + i;

			var srnd = newSprite.AddComponent<SpriteRenderer> ();
			srnd.sprite = mySprite;
			srnd.material = mat;
			srnd.sortingLayerID = mySrnd.sortingLayerID;
			srnd.sortingOrder = mySrnd.sortingOrder - i - 1;

			newSprite.transform.SetParent (transform);
			newSprite.transform.position = transform.position;
			newSprite.transform.localScale = Vector3.one * (1 + scaleIncrement * (i+1));
		}
	}
}
