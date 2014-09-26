using UnityEngine;
using System.Collections;

public class GameContentsHolderController : MonoBehaviour
{


		public static GameContentsHolderController singleton;
	
	
		void Awake ()
		{
				Debug.Log ("awake gamecontents");
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}

		public GameObject myRoomHolder;
		
		[HideInInspector]
		public GameObject
				myRoomHolderObject;

		//[HideInInspector]
		public RoomHolderController
				myRoomHolderController;

		// Use this for initialization
		void Start ()
		{
				Debug.Log ("start gamecontents");
				setupRoom ();

		}

		public void setupRoom ()
		{
				//myRoomHolderObject = MainMakeStuffController.newGameObjectInObject (gameObject);
				myRoomHolderObject = MainMakeStuffController.instantiatePrefabInObject (myRoomHolder, gameObject);
				//busted




		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
