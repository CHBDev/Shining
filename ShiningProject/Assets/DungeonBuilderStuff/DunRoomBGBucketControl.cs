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

		public void addBackgroundObjectToRoom (DunRoomBGControl theController, GameObject theRoom)
		{
				switch (theController.myBackgroundType) {

				default:
						MainMakeStuffController.instantiatePrefabInObject (theBackgroundPrefabs [0], theRoom);
						break;

				}

		}
}
