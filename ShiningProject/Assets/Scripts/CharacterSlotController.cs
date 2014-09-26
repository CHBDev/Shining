using UnityEngine;
using System.Collections;

public class CharacterSlotController : MonoBehaviour
{

		public float myXPos;
		public float myYPos;
		public GameObject myCharacterHolder;

		// Use this for initialization
		void Start ()
		{
				transform.localPosition = new Vector3 (myXPos, myYPos, 1);
				myCharacterHolder.transform.localPosition = transform.localPosition;


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
