using UnityEngine;
using System.Collections;

public class DunRoomSetDecControl : MonoBehaviour
{


		public enum SetDecType
		{
				None,
				ManualOverride,
				Cluttered,
				OrnateFloor,

		}

		public SetDecType mySetDecType;

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

		}

		public void loadDataOntoSelfFromSaveData (DunRoomSetDecControl theSaveData)
		{
				mySetDecType = theSaveData.mySetDecType;
		}



}


