using UnityEditor;
using UnityEngine;

public class ObjectSelectionTool : EditorWindow
{
    private Vector2 startDragPosition;
    private bool isDragging = false;

    [MenuItem("Tools/Object Selection Tool")]
    public static void ShowWindow()
    {
        GetWindow<ObjectSelectionTool>("Object Selection Tool");
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += DuringSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= DuringSceneGUI;
    }

    private void DuringSceneGUI(SceneView sceneView)
    {
        Event currentEvent = Event.current;

        switch (currentEvent.type)
        {
            case EventType.MouseDown:
                if (currentEvent.button == 0)
                {
                    startDragPosition = currentEvent.mousePosition;
                    isDragging = true;
                }
                break;

            case EventType.MouseUp:
                if (currentEvent.button == 0)
                {
                    isDragging = false;
                    HandleSelection();
                }
                break;

            case EventType.MouseDrag:
                if (isDragging)
                {
                    Handles.BeginGUI();
                    GUI.color = new Color(1f, 1f, 1f, 0.2f);
                    GUI.DrawTexture(new Rect(startDragPosition.x, startDragPosition.y, currentEvent.mousePosition.x - startDragPosition.x, currentEvent.mousePosition.y - startDragPosition.y), EditorGUIUtility.whiteTexture);
                    Handles.EndGUI();
                }
                break;
        }
    }

    private void HandleSelection()
    {
        Rect selectionRect = new Rect(startDragPosition.x, startDragPosition.y, Event.current.mousePosition.x - startDragPosition.x, Event.current.mousePosition.y - startDragPosition.y);

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            Vector3 screenPosition = HandleUtility.WorldToGUIPoint(obj.transform.position);
            screenPosition.y = SceneView.currentDrawingSceneView.position.height - screenPosition.y;

            if (selectionRect.Contains(screenPosition, true))
            {
                // Object is within the selection rectangle
                Selection.objects = new Object[] { obj };
            }
        }
    }
}
