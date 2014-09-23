using UnityEngine;
using System.Collections;
using System;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;

public class PlayerDataController : MonoBehaviour
{
		public static PlayerDataController singleton {
				get {
						return PersistedGameDataController.singleton.thePlayerDataController;
				}
		}
	
	

		[HideInInspector]
		public PlayerStableController
				myPlayerStableController;

		
		void Awake ()
		{

				Debug.Log ("awake");
				myPlayerStableController = gameObject.AddComponent ("PlayerStableController") as PlayerStableController;
		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		

		public void setDataFromSerial (PlayerDataSerializableObject theObject)
		{
				if (theObject == null) {
						resetAllData ();
				} else {
						myPlayerStableController.setDataFromSerial (theObject.myPlayerStableObject);
				}
		}

		public void resetAllData ()
		{
				myPlayerStableController.resetAllData ();
		}

}

[Serializable]
public class PlayerDataSerializableObject
{
		public PlayerStableSerializableData myPlayerStableObject;

		public PlayerDataSerializableObject (PlayerDataController theData)
		{
				if (theData == null) {
						
				} else {

						myPlayerStableObject = new PlayerStableSerializableData (theData.myPlayerStableController);
				}

		}

		


}
