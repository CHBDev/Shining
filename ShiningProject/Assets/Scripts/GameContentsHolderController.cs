using UnityEngine;
using System.Collections;

public class GameContentsHolderController : MonoBehaviour
{


		public static GameContentsHolderController singleton;
	
	
		void Awake ()
		{
				
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
				
				
				getMyRoom ();

		}



		public GameObject hackARoom ()
		{
				
				//myRoomHolderObject = MainMakeStuffController.newGameObjectInObject (gameObject);
				myRoomHolderObject = MainMakeStuffController.instantiatePrefabInObject (myRoomHolder, gameObject);
				return myRoomHolderObject;
				//busted




		}
	

		

		public void getMyRoom ()
		{
				MainNavigationController.singleton.addRoomToGameContents (gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
