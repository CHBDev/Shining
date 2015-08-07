using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MainDunMapControl))]
public class MainDunMapCustomEdit : Editor
{
		public override void OnInspectorGUI ()
		{
				DrawDefaultInspector ();
		
				MainDunMapControl myScript = (MainDunMapControl)target;
		
				if (Application.isPlaying == false) {

						if (GUILayout.Button ("SAVE ALL EDITS TO PREFAB")) {
								MainDunMapControl.saveAllEditsToPrefab ();
						}

						if (GUILayout.Button ("UPDATE MAP CONTROLS")) {
								MainDunMapControl.updateAllRooms ();
						}

			
				} else {
						if (GUILayout.Button ("MAP EDIT DISABLED WHILE PLAYING")) {

						}
				}
		
		}	
	
}
