using UnityEngine;
using System.Collections;

public class MainUtilController : MonoBehaviour
{


		public static MainUtilController singleton;
	
	
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
}
