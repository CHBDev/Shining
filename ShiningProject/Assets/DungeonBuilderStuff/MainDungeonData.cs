using UnityEngine;
using System.Collections;

public class MainDungeonData : MonoBehaviour
{



		public static MainDungeonData singleton;
		
		private GameObject theActiveDungeon;

		public GameObject theDungeonBucket;
		[HideInInspector]
		public DunBucketControl
				theDunBucketControl;

		public GameObject theDungeonRoomBackgroundBucket;
		[HideInInspector]
		public DunRoomBGBucketControl
				theDunRoomBGBucketControl;

		
		
		
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
						theDunBucketControl = theDungeonBucket.GetComponent<DunBucketControl> ();
						theDunRoomBGBucketControl = theDungeonRoomBackgroundBucket.GetComponent<DunRoomBGBucketControl> ();

				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}

		

		public void setupDungeon (MainHubData.HubNumber hubNumber)
		{
			
				GameObject theDunPrefab = theDunBucketControl.returnDungeonPrefabFor (DunBucketControl.DungeonName.BigBadDungeon);
				
				theActiveDungeon = MainMakeStuffController.instantiatePrefabInObject (theDunPrefab, GameAssetsControl.singleton.gameObject);

				DunControl theDunControl = theActiveDungeon.GetComponent<DunControl> ();

				theDunControl.theRooms = new DunRoomControl[theDunControl.numberOfLevels, theDunControl.roomsInX, theDunControl.roomsInY];

				foreach (DunRoomControl theRoomControl in theActiveDungeon.GetComponentsInChildren<DunRoomControl>()) {
						theDunControl.theRooms [theRoomControl.myZ, theRoomControl.myX, theRoomControl.myY] = theRoomControl;
						theRoomControl.gameObject.transform.localPosition = new Vector2 (3000f, 3000f);
						theRoomControl.setRefForParentAndParentTransform ();
						theRoomControl.gameObject.SetActive (false);
				}

				DunRoomControl startRoomControl = theDunControl.theRooms [theDunControl.startRoomZ, theDunControl.startRoomX, theDunControl.startRoomY];
				GameObject theStartRoom = startRoomControl.myRoomObject;

				theStartRoom.SetActive (true);
				startRoomControl.activateDungeonRoomForRuntime ();
		}

		
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}




}
