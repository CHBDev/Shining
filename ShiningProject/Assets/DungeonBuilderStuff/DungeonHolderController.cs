using UnityEngine;
using System.Collections;

public class DungeonHolderController : MonoBehaviour
{


		public static DungeonHolderController singleton;

		public GameObject myDungeonActualObject;
		public DungeonActualController myDungeonActualController;
	
	
		void Awake ()
		{
				
				if (singleton == null) {
						
						singleton = this;
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}

		public void addActualDungeonObject (GameObject theActual)
		{
				myDungeonActualObject = MainMakeStuffController.instantiatePrefabInObject (theActual, gameObject);

		}

		// Use this for initialization
		void Start ()
		{
				

		}


		// Update is called once per frame
		void Update ()
		{
	
		}
}
