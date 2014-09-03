using UnityEngine;
using System.Collections;

public class EnemyRowHolderController : MonoBehaviour
{

		public enum EnemyRowEnum
		{
				FRONT,
				MIDDLE,
				BACK
		}
		public EnemyRowEnum myEnemyRowEnum;
		public int myNumberOfEnemySlots;
		public float myRowScale;




		// Use this for initialization
		void Start ()
		{

				transform.localScale = new Vector3 (myRowScale, myRowScale, 1);



				switch (myEnemyRowEnum) {
				case(EnemyRowEnum.FRONT):
						break;


				}

		}


	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
