using UnityEngine;
using System.Collections;

public class ScaleToWindowContraints : MonoBehaviour
{

		public float gameBaseWidth;
		public float gameBaseHeight;
		//public Sprite myBackgroundImage;


		public enum ScaleConstraintEnum
		{
				SCALE_TO_ACTUAL_FRAME_SIZE,
				SCALE_TO_SHOW_ALL_OF_IMAGE,
				SCALE_TO_FILL_SCREEN_WITH_IMAGE,
		}
		;
		public ScaleConstraintEnum scaleConstraintEnum;
		private SpriteRenderer spriteRenderer;

		// Use this for initialization
		void Start ()
		{
				Camera myCamera = Camera.main;
				/*
				GameObject myChildObject = new GameObject ();
				myChildObject.AddComponent<SpriteRenderer> ();
				myChildObject.GetComponent<SpriteRenderer> ().sprite = myBackgroundImage;

				myChildObject = Instantiate (myChildObject) as GameObject;
				myChildObject.transform.parent = transform;
*/

				float actualScreenHeight = myCamera.orthographicSize * 2.0f;
				float actualScreenWidth = myCamera.orthographicSize * myCamera.aspect * 2.0f;

				

				//Debug.Log ("actual screen height " + (actualScreenHeight * 100));
				//Debug.Log ("actual screen width " + (actualScreenWidth * 100));

				//Debug.Log ("this object's height " + actualMyHeight);
				//Debug.Log ("this object's width" + actualMyWidth);

				switch (scaleConstraintEnum) {
				case ScaleConstraintEnum.SCALE_TO_ACTUAL_FRAME_SIZE:
						float heightMod = actualScreenHeight / gameBaseHeight;
						float widthMod = actualScreenWidth / gameBaseWidth;

						transform.localScale = new Vector3 (widthMod, heightMod, 1);
						break;

			
				case ScaleConstraintEnum.SCALE_TO_SHOW_ALL_OF_IMAGE:
						widthMod = actualScreenWidth / gameBaseWidth;
						heightMod = actualScreenHeight / gameBaseHeight;

						//Debug.Log ("width mod " + widthMod);
						//Debug.Log ("height mod " + heightMod);

						transform.localScale = new Vector3 (widthMod, widthMod, 1);

				
						if (widthMod < heightMod) {
								transform.localScale = new Vector3 (widthMod, widthMod, 1);
				
						} else {
								transform.localScale = new Vector3 (heightMod, heightMod, 1);
				
				
						}
						
						break;

			
				case ScaleConstraintEnum.SCALE_TO_FILL_SCREEN_WITH_IMAGE:
					
						widthMod = actualScreenWidth / gameBaseWidth;
						heightMod = actualScreenHeight / gameBaseHeight;
			
						//Debug.Log ("width mod " + widthMod);
						//Debug.Log ("height mod " + heightMod);
			
						transform.localScale = new Vector3 (widthMod, widthMod, 1);
			
			
						if (widthMod > heightMod) {
								transform.localScale = new Vector3 (widthMod, widthMod, 1);
				
						} else {
								transform.localScale = new Vector3 (heightMod, heightMod, 1);
				
				
						}

						break;
			
				}

	

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
