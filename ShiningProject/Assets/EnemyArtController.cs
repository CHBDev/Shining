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
						}

						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "EnemyRow1HPBar";
						}
						



						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow1Shadow";
						
						break;
				case(2):
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("mySelf").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
						}

						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "EnemyRow2HPBar";
						}

						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow2Shadow";
						
						break;
				case(3):
						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("mySelf").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
						}

						foreach (SpriteRenderer childRenderer in MyTransform.FindChild("myHPBar").GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "EnemyRow3HPBar";
						}

						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow3Shadow";
						
						break;

				}


		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
