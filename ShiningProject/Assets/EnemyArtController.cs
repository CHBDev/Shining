using UnityEngine;
using System.Collections;

public class EnemyArtController : MonoBehaviour
{
	

		// Use this for initialization
		void Start ()
		{
	
		}


		public void setupLayersForRow (int rowNumber, int enemyNumber)
		{

				switch (rowNumber) {
				case(1):
						foreach (SpriteRenderer childRenderer in GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
						}
						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow1Shadow";
						break;
				case(2):
						foreach (SpriteRenderer childRenderer in GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
						}
						transform.FindChild ("myShadow").gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "EnemyRow2Shadow";
						break;
				case(3):
						foreach (SpriteRenderer childRenderer in GetComponentsInChildren<SpriteRenderer>()) {
								childRenderer.sortingLayerName = "Enemy" + enemyNumber;
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
