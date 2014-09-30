using UnityEngine;
using System.Collections;

public class MainAIController : MonoBehaviour
{

		public static MainAIController singleton;
	
	
	
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


}
