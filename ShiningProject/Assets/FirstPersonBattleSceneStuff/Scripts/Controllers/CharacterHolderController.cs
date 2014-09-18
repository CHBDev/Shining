using UnityEngine;
using System.Collections;

public class CharacterHolderController : MonoBehaviour
{


		

		
		public GameObject myCharacterActualPrefab;

		[HideInInspector]
		public GameObject
				myCharacterActualObject;

		[HideInInspector]
		public Vector2
				myLocation;

		[HideInInspector]
		public CharacterActualController.CharacterTypeEnum
				myCharacterTypeEnum;

		GameObject theGameHolder;
		Transform myTransform;
		RelativeStuff LocationScaler;



		// Use this for initialization
		void Start ()
		{

				myCharacterActualObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myCharacterActualPrefab, gameObject);
				
				myCharacterActualObject.GetComponent<CharacterActualController> ().changeMyType (myCharacterTypeEnum);

				

		}


	

		// Update is called once per frame
		void Update ()
		{
	
		}
}
