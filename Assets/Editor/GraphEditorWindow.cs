using UnityEditor;
using UnityEngine;
using System.Collections;

public class GraphEditorWindow : EditorWindow {
	TriggerAction[] actions;
	Rect[] actionRects;

	[MenuItem ("Window/Graph Editor Window")]
	static void Init() {
		EditorWindow.GetWindow(typeof(GraphEditorWindow));
	}
	
	void OnGUI() {
		// Draw the Connections
//		Handles.BeginGUI();
//		Handles.DrawBezier(windowRect.center, windowRect2.center, //
//		                   new Vector2(windowRect.xMax + 50f, windowRect.center.y), //
//		                   new Vector2(windowRect2.xMin - 50f, windowRect2.center.y), //
//		                   Color.red, null, 5f);
//		Handles.EndGUI();
		
		BeginWindows();
		if (actionRects != null) {
			for (int i = 0; i < actionRects.Length; i++) {
				actionRects[i] = GUI.Window(i, actionRects[i], WindowFunction, actions[i].gameObject.name);
			}
		}

		if (GUI.Button(new Rect(0, 0, 100, 30), "Sync")) {
			SyncObjects();
		}

		EndWindows();
	}

	void WindowFunction(int windowID) {
		if (GUI.Button(new Rect(0, 20, 100, 20), "[Select]")) {
			Debug.Log("Selected!");
			Selection.objects = new Object[]{ actions[windowID].gameObject };
		}

		// Allow for window dragging
		GUI.DragWindow();
	}

	public void SyncObjects() {
		// Get all the objects in the scene of type Action
		actions = GameObject.FindObjectsOfType<TriggerAction>();
		actionRects = new Rect[actions.Length];
		for (int i = 0; i < actionRects.Length; i++) {
			actionRects[i] = new Rect(100, 100, 150, 80);
		}
	}
}