using UnityEngine;
using System.Collections;

public class CharacterActualController : MonoBehaviour
{

		public enum CharacterTypeEnum
		{
				TIRE,
				CONE,
				BRICK}
		;

		

		// Use this for initialization
		void Start ()
		{



		}

		public void changeMyType (CharacterTypeEnum theType)
		{

				


				foreach (Transform child in transform) {
			
						
						child.gameObject.SetActive (false);
						//SpriteRenderer aRenderer = child.GetComponent<SpriteRenderer> ();
						//aRenderer.enabled = false;
			
				}
				
				switch (theType) {
				case(CharacterTypeEnum.TIRE):

						transform.FindChild ("tire1").gameObject.SetActive (true);
						
						//activeRenderer = activeChild.GetComponent<SpriteRenderer> ();
						//activeRenderer.enabled = true;
			
			
						break;
			
				case(CharacterTypeEnum.CONE):
						
						transform.FindChild ("cone1").gameObject.SetActive (true);
						
						//activeRenderer = activeChild.GetComponent<SpriteRenderer> ();
						//activeRenderer.enabled = true;
			
			
						break;
			
				case(CharacterTypeEnum.BRICK):
			
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
