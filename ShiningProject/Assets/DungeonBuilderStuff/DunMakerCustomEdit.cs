using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DunMakerControl))]
public class DunMakerCustomEdit : Editor
{
		public override void OnInspectorGUI ()
		{
				DrawDefaultInspector ();
		
				DunMakerControl myScript = (DunMakerControl)target;
				
				if (myScript.importSlotForDungeonExportObject != null) {
						if (GUILayout.Button ("Do Offline Maker Map")) {
								MainDunMapControl.doMakerMapForDunControl (myScript.importSlotForDungeonExportObject);
						}
				} else {
						if (GUILayout.Button ("NO IMPORT SLOT FOR MAP")) {

						}
				}

				if (Application.isPlaying == true) {
						if (GUILayout.Button ("Load Import Slot")) {
								myScript.loadImportSlotIntoEditSlot ();
						}
						if (GUILayout.Button ("Export to Prefab")) {
								myScript.exportEditSlotToPrefab ();
						}
						if (GUILayout.Button ("New Dungeon")) {
								myScript.newObjectInEditSlot ();
						}

				} else {
						if (GUILayout.Button ("MAKER DISABLED/HIT PLAY BUTTON")) {
								Debug.Log ("need to be online to use maker functions");
						}
				}
				
		}	
		
}
