using UnityEngine;
using System.Collections;

public class DunRoomBGControl : MonoBehaviour
{

		public GameObject myCurrentBGObjectArt;
		public DunBackdropSwitch myDunBackdropSwitch;
		
		public DunRoomBGBucketControl.BackgroundType myBackgroundType = DunRoomBGBucketControl.BackgroundType.DungeonDefault;
		public DunRoomControl myDunRoomControl;
		

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void tearDownSelf ()
		{
				myCurrentBGObjectArt.SetActive (false);
				Destroy (myCurrentBGObjectArt);
		}

		public void tintBGContents (Color aColor)
		{
				foreach (SpriteRenderer aRenderer in myCurrentBGObjectArt.GetComponentsInChildren<SpriteRenderer>()) {
						aRenderer.color = aColor;
				}
		}

		public void activate (DunRoomControl theDunRoomControl)
		{

				myDunRoomControl = theDunRoomControl;
				GameObject theRoom = theDunRoomControl.gameObject;
				
				GameObject thePrefab = MainDungeonData.singleton.theDunRoomBGBucketControl.getBackgroundPrefabForRoom (this, theRoom);

				myCurrentBGObjectArt = MainMakeStuffController.instantiatePrefabInObject (thePrefab, theRoom);

				myDunBackdropSwitch = myCurrentBGObjectArt.GetComponent<DunBackdropSwitch> ();
				myDunBackdropSwitch.setupBaseRoom (theDunRoomControl);
				myDunBackdropSwitch.setExitsForBackdrop ();
		}

		public void loadDataOntoSelfFromSaveData (DunRoomBGControl theSaveData)
		{

				myBackgroundType = theSaveData.myBackgroundType;

		}
}


