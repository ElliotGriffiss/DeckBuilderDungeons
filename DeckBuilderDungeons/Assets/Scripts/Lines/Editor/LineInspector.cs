using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{
    private void OnSceneGUI()
    {
        Debug.Log("GUI");

        Line line = target as Line;
        Transform handleTransform = line.transform;
        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        Vector3 startPoint = handleTransform.TransformPoint(line.StartingPoint);
        Vector3 endPoint = handleTransform.TransformPoint(line.EndingPoint);

        Handles.color = Color.white;
        Handles.DrawLine(line.StartingPoint, line.EndingPoint);

        EditorGUI.BeginChangeCheck();
        startPoint = Handles.DoPositionHandle(startPoint, handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            line.StartingPoint = handleTransform.InverseTransformPoint(startPoint);
        }
        EditorGUI.BeginChangeCheck();

        endPoint = Handles.DoPositionHandle(endPoint, handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            line.EndingPoint = handleTransform.InverseTransformPoint(endPoint);
        }
    }
}
