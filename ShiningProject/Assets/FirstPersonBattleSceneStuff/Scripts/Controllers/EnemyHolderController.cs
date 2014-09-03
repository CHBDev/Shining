using UnityEngine;
using System.Collections;

public class EnemyHolderController : MonoBehaviour
{

		public GameObject myEnemyImHoldingPrefab;

		[HideInInspector]
		public GameObject
				myEnemyImHoldingObject;

		public int myEnemyLevel;

		// Use this for initialization
		void Start ()
		{
				myEnemyImHoldingObject = (GameObject)Instantiate (myEnemyImHoldingPrefab);

				myEnemyImHoldingObject.transform.parent = transform;


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
