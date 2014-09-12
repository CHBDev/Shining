using UnityEngine;
using System.Collections;

public class gameTempEffectsController : MonoBehaviour
{

		public GameObject tempCircleAddPrefab;

		[HideInInspector]
		public Vector2
				offscreenStoragePoint;

		// Use this for initialization
		void Start ()
		{
	
				offscreenStoragePoint = new Vector2 (0, -Screen.height * 3);
		}

		public void tempPlaceCircle (Vector2 pt)
		{

				GameObject thisObject = (GameObject)Instantiate (tempCircleAddPrefab, pt, Quaternion.identity);
				SpriteRenderer thisRenderer = thisObject.transform.GetComponentInChildren<SpriteRenderer> ();
				thisRenderer.sortingLayerName = "OverlayUI2";




		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
