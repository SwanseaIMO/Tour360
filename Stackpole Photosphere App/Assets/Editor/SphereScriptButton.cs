using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

 [CustomEditor(typeof(PhotoSphereCreation))]
public class SphereScriptButton : Editor
{
	public override void OnInspectorGUI(){

		DrawDefaultInspector ();

		EditorGUILayout.HelpBox ("Drag an equirectangular image into the photo selection box and press Update Sphere.", MessageType.Info);

		PhotoSphereCreation myScript = (PhotoSphereCreation)target;
		if (GUILayout.Button("Update Sphere")) {
			myScript.Start ();
		}
			
			
	}
}
