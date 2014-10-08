using UnityEngine;
using System.Collections;

public class MainDungeonData : MonoBehaviour
{



		public static MainDungeonData singleton;
		private DungeonActualController theActiveDungeonActualController;
		private GameObject theActiveDungeon;

		public GameObject theDungeonBucketPrefab;
		private DungeonPrefabBucketController theDungeonPrefabBucketController;


		
		
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
				theActiveDungeon = theDungeonPrefabBucketController.myDungeonPrefabs [(int)hubNumber];
				theActiveDungeonActualController = theActiveDungeon.GetComponent<DungeonActualController> ();

				if (theActiveDungeonActualController != null) {
						Debug.Log ("DC IS NOT NULL");
				}

				DungeonHolderController.singleton.addActualDungeonObject (theActiveDungeon);



				
				
		}


		
		// Use this for initialization
		void Start ()
		{
				theDungeonPrefabBucketController = theDungeonBucketPrefab.GetComponent<DungeonPrefabBucketController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}




}
