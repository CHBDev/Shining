using UnityEngine;
using System.Collections;

public class MainDunMapControl : MonoBehaviour
{

		public bool dunMakerMapOn = false;
		public GameObject[,,] mapRooms;
		public GameObject mapHolder;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		class mapRoomControl: MonoBehaviour
		{

				public MainNavigationController.DungeonExits[] myDungeonExits;

		}

		public void doMakerMapForDunControl (GameObject theDungeonObject)
		{

				mapHolder = new GameObject ();


				DunControl theDunControl = theDungeonObject.GetComponent<DunControl> ();

				DunRoomControl[] tempDunRoomControls = theDungeonObject.GetComponentsInChildren<DunControl> ();

				int numberOfLevels = theDunControl.numberOfLevels;
				int roomsInX = theDunControl.roomsInX;
				int roomsInY = theDunControl.roomsInY;

				DunRoomControl dunRoomControls = DunRoomControl [numberOfLevels, roomsInX, roomsInY];
		
				foreach (DunRoomControl theRoomControl in tempDunRoomControls) {
						dunRoomControls [theRoomControl.myZ, theRoomControl.myX, theRoomControl.myY] = theRoomControl;
				}


				for (int z = 0; z < numberOfLevels; z++) {
						for (int x = 0; x < roomsInX; x++) {
								for (int y = 0; y < roomsInY; y++) {

										DunRoomControl tempRoomControl = dunRoomControls [z, x, y];
										MainNavigationController.DungeonExits[] tempDunExits = tempRoomControl.myDungeonExits;

										float netRoomWidth = 25 + 5;
										float netRoomHeight = 25 + 5;
					
					
										float xPos = z * (roomsInX * netRoomWidth) + (x * netRoomWidth);
										float yPos = y * netRoomHeight;

										Vector2 thisPos = new Vector2 (xPos / 100f, yPos / 100f);




										GameObject theMapRoom = MainMakeStuffController.newGameObjectInObject (mapHolder, thisPos);
										mapRoomControl tempMapRoomControl = theMapRoom.AddComponent<mapRoomControl> ();
										tempMapRoomControl.myDungeonExits = tempDunExits;
										SpriteRenderer tempSpriteRenderer = theMapRoom.AddComponent<SpriteRenderer> ();
										tempSpriteRenderer.sprite = MainMakeStuffController.returnWhiteBoxSprite ();

					

										mapRooms [z, x, y] = theMapRoom;
					
					
					
			
					
								}
				
						}
			
				}
		}

		


}
