using UnityEngine;
using System.Collections;

public class GameContentsHolderController : MonoBehaviour
{

		public GameObject myRoomHolderPrefab;
		
		[HideInInspector]
		public GameObject
				myRoomHolderObject;

		// Use this for initialization
		void Start ()
		{
				
				myRoomHolderObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myRoomHolderPrefab, gameObject);



		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
