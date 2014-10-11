using UnityEngine;
using System.Collections;

public class DunRoomBGControl : MonoBehaviour
{

		public GameObject myCurrentBGObjectArt;
		
		public DunRoomBGBucketControl.BackgroundType myBackgroundType = DunRoomBGBucketControl.BackgroundType.DungeonDefault;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void activate (DunRoomControl theDunRoomControl)
		{
				GameObject theRoom = theDunRoomControl.gameObject;
				
				MainDungeonData.singleton.theDunRoomBGBucketControl.addBackgroundObjectToRoom (this, theRoom);
		}

		public void loadDataOntoSelfFromSaveData (DunRoomBGControl theSaveData)
		{

				myBackgroundType = theSaveData.myBackgroundType;

		}
}


