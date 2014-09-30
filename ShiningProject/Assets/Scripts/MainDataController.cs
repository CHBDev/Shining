using UnityEngine;
using System.Collections;

public class MainDataController : MonoBehaviour
{

		public static MainDataController singleton;
	
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;

				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}
		
		public GameObject theEnemyHolderPrefab;
		public GameObject theCharacterHolderPrefab;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
