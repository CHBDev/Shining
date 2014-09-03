using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomHolderController : MonoBehaviour
{
	
		public GameObject myMainBackGroundPrefab;
		public GameObject myRoomPrefab;
		

		[HideInInspector]
		public GameObject
				myMainBackGroundObject;
		[HideInInspector]
		public GameObject
				myRoomObject;
		


		// Use this for initialization
		void Start ()
		{

				myMainBackGroundObject = (GameObject)Instantiate (myMainBackGroundPrefab);

				myRoomObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myRoomPrefab, gameObject);


				this.changeMainBackGroundSprite (myRoomObject.GetComponent<RoomController> ().myBackGround);


		}

		public void changeMainBackGroundSprite (Sprite theSprite)
		{
				myMainBackGroundObject.GetComponent<SpriteRenderer> ().sprite = theSprite;
		}



		// Update is called once per frame
		void Update ()
		{
	
		}
}
