using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyArtController : MonoBehaviour
{

		//in order to line up the shadow at the "row height", and have a rough anchor point
		//at the bottom of the image, we instead ask them to put everything in and then add an offset.
		
		public float myOverallXOffsetFromShadow;
		public float myOverallYOffsetFromShadow;
		public float myHeadXOffsetVal;
		public float myHeadYOffsetVal;
		public bool hasBody = false;
		public float myBodyXOffsetVal;
		public float myBodyYOffsetVal;
		public bool hasLeft = false;
		public float myLeftPartXOffsetVal;
		public float myLeftPartYOffsetVal;
		public bool hasRight = false;
		public float myRightPartXOffsetVal;
		public float myRightPartYOffsetVal;
		public bool hasFeet = false;
		public float myFeetXOffsetVal;
		public float myFeetYOffsetVal;
		public float myShadowXOffsetVal;
		public float myShadowYOffsetVal;
		public float myShadowScaleX = 1;
		public float myShadowScaleY = 1;
		public float myHitBoxYOffsetFromCenter = 0;
		public float myHitBoxRadiusScaleMultiplier = 1;


		[HideInInspector]
		public EnemyActualController
				myEnemyActualController;

		[HideInInspector]
		public string
				myBaseSortingLayer;

		SpriteRenderer[] mySpriteRenderers;

		// Use this for initialization
		void Start ()
		{
				
		}

		void Awake ()
		{
				
		}

		public void changeSortingLayerTo (string theName, bool overrideToAttack, bool overrideToBase)
		{
				string theFinal;

				if (overrideToBase == true) {
						theFinal = myBaseSortingLayer;
				} else if (overrideToAttack == true) {
						theFinal = "EnemyAttacking";
				} else {
						theFinal = theName;
				}
				foreach (SpriteRenderer childRenderer in mySpriteRenderers) {
						childRenderer.sortingLayerName = theFinal;
				}
		}


		public void setupLayersForRow (int rowNumber, int enemyNumber)
		{

				Transform MyTransform = transform;

				Transform theShadow = MyTransform.FindChild ("myShadow");

				myBaseSortingLayer = "Enemy" + enemyNumber;

				mySpriteRenderers = MyTransform.GetComponentsInChildren<SpriteRenderer> ();
				List<SpriteRenderer> tempList = new List<SpriteRenderer> ();


				foreach (SpriteRenderer childRenderer in mySpriteRenderers) {
						childRenderer.sortingLayerName = myBaseSortingLayer;
						tempList.Add (childRenderer);
				}

				SpriteRenderer theShadowRenderer = theShadow.gameObject.GetComponent<SpriteRenderer> ();
				tempList.Remove (theShadowRenderer);
				mySpriteRenderers = tempList.ToArray ();

				


				switch (rowNumber) {
				case(1):
						
						theShadowRenderer.sortingLayerName = "EnemyRow1Shadow";
						
						break;
				case(2):
						
						theShadowRenderer.sortingLayerName = "EnemyRow2Shadow";
						
						break;
				case(3):
						
						theShadowRenderer.sortingLayerName = "EnemyRow3Shadow";
						
						break;

				}

				myEnemyActualController.tellEnemyActualToTakeShadowOver (theShadow);


		}







	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
}

