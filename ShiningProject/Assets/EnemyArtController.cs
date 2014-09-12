using UnityEngine;
using System.Collections;

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
	
		// Use this for initialization
		void Start ()
		{
	
		}


		public void setupLayersForRow (int rowNumber, int enemyNumber)
		{

				Transform MyTransform = transform;

				foreach (SpriteRenderer childRenderer in MyTransform.GetComponentsInChildren<SpriteRenderer>()) {
						childRenderer.sortingLayerName = "Enemy" + enemyNumber;
				}



				switch (rowNumber) {
				case(1):
						
						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow1Shadow";
						
						break;
				case(2):
						
						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow2Shadow";
						
						break;
				case(3):
						
						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow3Shadow";
						
						break;

				}


		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
