using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour
{


		public static MainCameraController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
						Camera.main.orthographicSize = targettedScreenWidth / Camera.main.aspect / 2 / 100.0f;
						Debug.Log ("Camera.main orthosize " + Camera.main.orthographicSize);

				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}

		public float targettedScreenWidth = 1136;
		public float targettedScreenHeight = 640;

		// Use this for initialization
		void Start ()
		{

				


				/*

		  float targettedScreenWidth = 1136.0f;
				float targettedScreenHeight = 640.0f;
				int pixelsPerUnit = 100;

				float neededAspectRatio = targettedScreenWidth / targettedScreenHeight;
				float actualAspectRatio = (float)Screen.width / (float)Screen.height;



				if (actualAspectRatio >= neededAspectRatio) {

						Camera.main.orthographicSize = targettedScreenHeight / 2 / pixelsPerUnit;
				}else {
						float offsetAmount = neededAspectRatio / actualAspectRatio;
						Camera.main.orthographicSize = targettedScreenHeight / 2 / pixelsPerUnit * offsetAmount;
				}
				*/



		}

		

		public float returnCameraOrthoScreenWidth ()
		{
				return Camera.main.orthographicSize * Camera.main.aspect * 2;
		}

		public float returnCameraOrthoScreenHeight ()
		{
				return Camera.main.orthographicSize * 2;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
