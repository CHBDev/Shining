﻿using UnityEngine;
using System.Collections;

public class MainDataController : MonoBehaviour
{

		public static MainDataController singleton;
	
	
	
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
