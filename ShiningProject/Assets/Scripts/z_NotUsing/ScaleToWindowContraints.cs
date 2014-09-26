using UnityEngine;
using System.Collections;

public class ScaleToWindowContraints : MonoBehaviour
{

		public float gameBaseWidth = 11.36f;
		public float gameBaseHeight = 6.4f;
		//public Sprite myBackgroundImage;


		public enum ScaleConstraintEnum
		{
				SCALE_TO_MATCH_WIDTH,
				SCALE_TO_SHOW_ALL_OF_IMAGE,
				SCALE_TO_FILL_SCREEN_WITH_IMAGE,
				SCALE_TO_WIDTH_AND_HEIGHTH,
		}
		;
		public ScaleConstraintEnum scaleConstraintEnum;
		private SpriteRenderer spriteRenderer;

		// Use this for initialization
		void Start ()
		{
				//Camera myCamera = Camera.main;
				/*
				GameObject myChildObject = new GameObject ();
				myChildObject.AddComponent<SpriteRenderer> ();
				myChildObject.GetComponent<SpriteRenderer> ().sprite = myBackgroundImage;

				myChildObject = Instantiate (myChildObject) as GameObject;
				myChildObject.transform.parent = transform;
*/

				float actualScreenHeight = Screen.height;
				float actualScreenWidth = Screen.width;



				//Debug.Log ("SCREEN: " + actualScreenWidth + "/ " + actualScreenHeight);
				//Debug.Log ("BASE SIZE: " + gameBaseWidth + "/ " + gameBaseHeight);


				

				//Debug.Log ("actual screen height " + (actualScreenHeight * 100));
				//Debug.Log ("actual screen width " + (actualScreenWidth * 100));

				//Debug.Log ("this object's height " + actualMyHeight);
				//Debug.Log ("this object's width" + actualMyWidth);

				switch (scaleConstraintEnum) {
				
				case ScaleConstraintEnum.SCALE_TO_SHOW_ALL_OF_IMAGE:
						float widthMod = actualScreenWidth / gameBaseWidth;
						float heightMod = actualScreenHeight / gameBaseHeight;

						//Debug.Log ("width mod " + widthMod);
						//Debug.Log ("height mod " + heightMod);

						
				
						if (widthMod < heightMod) {
								transform.localScale = new Vector3 (widthMod, widthMod, 1);
				
						} else {
								transform.localScale = new Vector3 (heightMod, heightMod, 1);
				
				
						}
						
						break;
				case ScaleConstraintEnum.SCALE_TO_WIDTH_AND_HEIGHTH:
						widthMod = actualScreenWidth / gameBaseWidth;
						heightMod = actualScreenHeight / gameBaseHeight;

						transform.localScale = new Vector3 (widthMod, heightMod, 1);

			
						break;

			
				case ScaleConstraintEnum.SCALE_TO_FILL_SCREEN_WITH_IMAGE:
					
						widthMod = actualScreenWidth / gameBaseWidth;
						heightMod = actualScreenHeight / gameBaseHeight;

						if (widthMod > heightMod) {
								transform.localScale = new Vector3 (widthMod, widthMod, 1);
				
						} else {
								transform.localScale = new Vector3 (heightMod, heightMod, 1);
				
				
						}

						break;
				case ScaleConstraintEnum.SCALE_TO_MATCH_WIDTH:
			
						widthMod = actualScreenWidth / gameBaseWidth;
					
						transform.localScale = new Vector3 (widthMod, widthMod, 1);
			
						break;
			
				}

	

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
