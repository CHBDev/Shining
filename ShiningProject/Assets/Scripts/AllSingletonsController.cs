using UnityEngine;
using System.Collections;

public class AllSingletonsController : MonoBehaviour
{


		public static AllSingletonsController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
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
}
