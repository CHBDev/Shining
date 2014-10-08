using UnityEngine;
using System.Collections;

public class MainHubData : MonoBehaviour
{

		public enum HubNumber
		{
				House1 = 0,
				Junkyard1 = 1,
		
		}

		public HubNumber currentHubNumber;
	
		public static MainHubData singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	

		public void hackEnterDungeonFromHackMenu ()
		{
				MainNavigationController.singleton.HubCallsDungeon ();
		}


}
