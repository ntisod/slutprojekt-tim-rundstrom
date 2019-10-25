using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor {

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		GameController gc = (GameController)target;

		EditorGUILayout.LabelField($"White Points: {gc.whitePoints}");
		EditorGUILayout.LabelField($"Black Points: {gc.blackPoints}");

		if (GUILayout.Button("Restart Game")) {
			gc.Restart();
		}

	}

}
