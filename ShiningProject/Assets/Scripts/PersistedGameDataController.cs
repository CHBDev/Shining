using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PersistedGameDataController : MonoBehaviour
{
		[HideInInspector]
		public PlayerDataController
				thePlayerDataController;
		[HideInInspector]
		public SettingsController
				theSettingsController;
		[HideInInspector]
		public AchievementsController
				theAchievementsController;
		
		
		private string myPlayerDataFileName = "/ss_dat777888.dat";
		private string myPlayerDataFileBackupName = "ss_dat777888.bak" ;
		//private string mySettingsFileName = "/ss_dat666777.dat";
		//private string myAchievementsFileName = "/ss_dat555666.dat";
		//private string myGameDataFileName = "/ss_dat444555.dat";



		public static PersistedGameDataController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}

				thePlayerDataController = GetComponent<PlayerDataController> ();
				theSettingsController = GetComponent<SettingsController> ();
				theAchievementsController = GetComponent<AchievementsController> ();
				
		}

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void SavePlayerData ()
		{

				
				if (File.Exists (Application.persistentDataPath + myPlayerDataFileName)) {
						File.Copy (Application.persistentDataPath + myPlayerDataFileName, Application.persistentDataPath + myPlayerDataFileBackupName);
						
				}
	
				BinaryFormatter theFormatter = new BinaryFormatter ();

				FileStream theFile = File.Create (Application.persistentDataPath + myPlayerDataFileName);

				
				PlayerDataSerializableObject theObject = new PlayerDataSerializableObject (thePlayerDataController);

				theFormatter.Serialize (theFile, theObject);
				theFile.Close ();

				if (File.Exists (Application.persistentDataPath + myPlayerDataFileName) && theObject != null) {
						//all is good
				} else {
						//revert backup, and then try save again
						if (File.Exists (Application.persistentDataPath + myPlayerDataFileBackupName)) {
								File.Copy (Application.persistentDataPath + myPlayerDataFileBackupName, Application.persistentDataPath + myPlayerDataFileName);
								

						}

						this.SavePlayerData ();

				}

				
		}

		public void SaveSettings ()
		{

		}

		public void SaveAchievements ()
		{

		}

		

		public void LoadPlayerData ()
		{
				if (File.Exists (Application.persistentDataPath + myPlayerDataFileName)) {
						BinaryFormatter theFormatter = new BinaryFormatter ();
						FileStream theFile = File.Open (Application.persistentDataPath + myPlayerDataFileName, FileMode.Open);

						PlayerDataSerializableObject theObject = (PlayerDataSerializableObject)theFormatter.Deserialize (theFile);
						theFile.Close ();

						thePlayerDataController.setDataFromSerial (theObject);
				} else {
						Debug.Log ("No Player Data Controller Save File");
						thePlayerDataController.setDataFromSerial (null);
						
				}
						

						
		}

		public void LoadSettings ()
		{
		
		}

		

		public void LoadAchievements ()
		{
		
		}

		public void DeletePlayerData ()
		{
				if (File.Exists (Application.persistentDataPath + myPlayerDataFileName)) {
						File.Delete (Application.persistentDataPath + myPlayerDataFileName);
				}


		}








		//all platforms except for web
		public void SaveAll ()
		{
				

		}

		public bool LoadAll ()
		{

				this.LoadPlayerData ();
				this.LoadSettings ();
				
				this.LoadAchievements ();

				return true;
			

		}






}

//container class because mono classes are not good at it.















