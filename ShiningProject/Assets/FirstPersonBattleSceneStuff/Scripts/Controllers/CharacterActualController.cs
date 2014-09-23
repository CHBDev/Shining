﻿using UnityEngine;
using System.Collections;

public class CharacterActualController : MonoBehaviour
{

		

		public CharacterDataSet myDataSet;

		

		// Use this for initialization
		void Start ()
		{



		}

		public void changeMyType (CharacterDataSet.CharacterTypes_Enum theType)
		{

				


				foreach (Transform child in transform) {
			
						
						child.gameObject.SetActive (false);
						//SpriteRenderer aRenderer = child.GetComponent<SpriteRenderer> ();
						//aRenderer.enabled = false;
			
				}
				
				switch (theType) {
				case(CharacterDataSet.CharacterTypes_Enum.TIRE):

						transform.FindChild ("tire1").gameObject.SetActive (true);
						
						//activeRenderer = activeChild.GetComponent<SpriteRenderer> ();
						//activeRenderer.enabled = true;
			
			
						break;
			
				case(CharacterDataSet.CharacterTypes_Enum.CONE):
						
						transform.FindChild ("cone1").gameObject.SetActive (true);
						
						//activeRenderer = activeChild.GetComponent<SpriteRenderer> ();
						//activeRenderer.enabled = true;
			
			
						break;
			
				case(CharacterDataSet.CharacterTypes_Enum.BRICK):
			
						transform.FindChild ("brick1").gameObject.SetActive (true);
						
						//activeRenderer = activeChild.GetComponent<SpriteRenderer> ();
						//activeRenderer.enabled = true;
			
			
						break;
			
				}
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
