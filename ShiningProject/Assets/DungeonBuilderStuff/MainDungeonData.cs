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

				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}

		

		public void setupDungeon (MainHubData.HubNumber hubNumber)
		{
			

				
				
		}


		
		// Use this for initialization
		void Start ()
		{
				theDunBucketControl = theDungeonBucket.GetComponent<DunBucketControl> ();
				theDunRoomBGBucketControl = theDungeonRoomBackgroundBucket.GetComponent<DunRoomBGBucketControl> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}




}
