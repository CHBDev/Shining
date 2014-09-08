using UnityEngine;
using System.Collections;

public class EnemyArtController : MonoBehaviour
{
		public float myHPBarOffsetXValue;
		public float myHPBarOffsetYValue;
		public float myBodyOffsetXValue;
		public float myBodyOffsetYValue;
		public float myShadowOffsetYValue;
		public float myShadowOffsetXValue;
		public float myShadowScaleSizeX;
		public float myShadowScaleSizeY;

		public bool shouldDoHealthBar = false;

		// Use this for initialization
		void Start ()
		{
	
		}


		public void setupLayersForRow (int rowNumber, int enemyNumber)
		{

				Transform MyTransform = transform;

				switch (rowNumber) {
				case(1):
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("mySelf").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;

								if (shouldDoHealthBar == true) {
										if (childRenderer.transform.parent.gameObject.name == "myHPBar") {
												childRenderer.sortingLayerName = "EnemyRow1HPBar";
										}
								}
			
						}
			/*
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								
						}
						*/
						



						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow1Shadow";
						
						break;
				case(2):
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("mySelf").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
								
								if (shouldDoHealthBar == true) {
										if (childRenderer.transform.parent.gameObject.name == "myHPBar") {
												childRenderer.sortingLayerName = "EnemyRow2HPBar";
										}
								}
				
						}
			/*
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								
						}
						*/

						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow2Shadow";
						
						break;
				case(3):
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("mySelf").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
								
								if (shouldDoHealthBar == true) {
										if (childRenderer.transform.parent.gameObject.name == "myHPBar") {
												childRenderer.sortingLayerName = "EnemyRow3HPBar";
										}
								}
				
						}
			/*
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								
						}
						*/

						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow3Shadow";
						
						break;

				}


		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
