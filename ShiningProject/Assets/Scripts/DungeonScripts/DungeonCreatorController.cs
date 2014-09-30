using UnityEngine;
using System.Collections;

public class DungeonCreatorController
{

		DungeonRoomCreatorController myDungeonRoomCreatorController;

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public GameObject returnActualRoomFromRawData (DungeonRoomRawData theData)
		{
				if (myDungeonRoomCreatorController == null) {
						myDungeonRoomCreatorController = new DungeonRoomCreatorController ();
				}

				return myDungeonRoomCreatorController.makeAnActualRoomHolderFromData (theData);
		}

		public void setupDungeonForHub (MainHubData.HubNumber theHub, DungeonActualController theActual)
		{

				//parse through each hub to get specific data i guess

				switch (theHub) {
				case MainHubData.HubNumber.House1:
						{
								theActual.createCubeGridOfChunks (3, 3, 3, 8, 8);
								//then we somehow set the data on each of these rooms
						}
						break;
				}


		}

}
