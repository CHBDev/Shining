using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour
{


		public static MainCameraController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}

		public float targettedScreenWidth = 1136;
		public float targettedScreenHeight = 640;

		// Use this for initialization
		void Start ()
		{

				Camera.main.orthographicSize = targettedScreenWidth / Camera.main.aspect / 2 / 100.0f;




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
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
