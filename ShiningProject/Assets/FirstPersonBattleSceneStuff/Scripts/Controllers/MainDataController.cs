using UnityEngine;
using System.Collections;

public class MainDataController : MonoBehaviour
{

		public int numberOfCharacters;
		public int numberOfEnemies;

		public enum RoomType
		{
				DUNGEON,
				PUZZLE,
				DIALOGUE}
		;
		public RoomType currentRoomType;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
