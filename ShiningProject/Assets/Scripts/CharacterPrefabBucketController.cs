using UnityEngine;
using System.Collections;



public class CharacterPrefabBucketController : MonoBehaviour
{

		public float baseCharacterHolderScale = 1.3f;

		public enum CharacterTypes
		{
				NULL_CHARACTER,
				CONE,
				BRICK,
				TIRE,
		}

		[System.Serializable]
		public class CharacterTypePrefabPair
		{

				public CharacterPrefabBucketController.CharacterTypes characterType;
				public GameObject prefab;


		}

		public CharacterTypePrefabPair[] myCharacterArray;

		public GameObject returnCharacterPrefabForType (CharacterTypes theType)
		{
				foreach (CharacterTypePrefabPair thePair in myCharacterArray) {
						if (thePair.characterType == theType) {
								return thePair.prefab;
						}
				}
		
				
				return null;
		}
	
}
