using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomHolderController : MonoBehaviour
{
	
		
		public GameObject myRoomArtPrefab;
		public GameObject myRoomDataPrefab;
	
		[HideInInspector]
		public GameObject
				myRoomArtObject;

		public enum RoomDifficultyMod
		{
				DEFAULT,
				EASIEST,
				EASIER,
				NORMAL,
				HARDER,
				HARDEST}
		;
		


		// Use this for initialization
		void Start ()
		{

				
				myRoomArtObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myRoomArtPrefab, gameObject);



		}

		



		// Update is called once per frame
		void Update ()
		{
	
		}
}
