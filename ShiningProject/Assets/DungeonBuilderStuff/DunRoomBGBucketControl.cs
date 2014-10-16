using UnityEngine;
using System.Collections;

public class DunRoomBGBucketControl : MonoBehaviour
{


		public enum BackgroundType
		{
				DungeonDefault,
				BossRoom1,
				SubBossRoom1,
				TreasureRoom1,
				CollapsedRoom1
		
		}



		

		public GameObject[] theBackgroundPrefabs;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public GameObject getBackgroundPrefabForRoom (DunRoomBGControl theController, GameObject theRoom)
		{
				switch (theController.myBackgroundType) {

				default:
						return theBackgroundPrefabs [0];
						break;

				}

		}
}
