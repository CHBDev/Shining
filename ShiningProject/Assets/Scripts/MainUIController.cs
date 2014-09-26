using UnityEngine;
using System.Collections;

public class MainUIController : MonoBehaviour
{


		public static MainUIController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
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

		public void putUpMovementOptions (MainNavigationController.MovementDirections[] theDirections)
		{
				foreach (MainNavigationController.MovementDirections theDir in theDirections) {
						//put a thing on screen to click or something like that
				}
		}
}
