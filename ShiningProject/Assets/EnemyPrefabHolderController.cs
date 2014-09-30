using UnityEngine;
using System.Collections;
using System;

public class EnemyPrefabHolderController : ScriptableObject
{

		public enum EnemyArtType
		{
				Null_Entry,
				Head_Mushroom_Red,
				Head_Block_Green,
				Whole_ArmorGuy_Pink,
				Whole_RockGuy_Green
		
		}
	
		
		[Serializable]
		public class EnemyTypeAndArtPair
		{

			
				public EnemyPrefabHolderController.EnemyArtType enemyType;
				public GameObject prefab;
		}

		public EnemyTypeAndArtPair[] myEnemyArray;



		public GameObject returnEnemyPrefabForType (EnemyArtType theType)
		{
				foreach (EnemyTypeAndArtPair thePair in myEnemyArray) {
						if (thePair.enemyType == theType) {
								return thePair.prefab;
						}
				}

				
				return null;
		}

}

