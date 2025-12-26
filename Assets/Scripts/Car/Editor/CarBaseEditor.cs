using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarBase))]
public class CarBaseEditor : Editor
{
    private SerializedProperty listProperty;

    private void OnEnable()
    {
        listProperty = serializedObject.FindProperty("speeds");
    }
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        CarBase myTarget = (CarBase)target;

        serializedObject.Update();

        myTarget.carbasePrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carbasePrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("Velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);

        EditorGUILayout.HelpBox("Calcule a velocidade total do carro", MessageType.Info);
        EditorGUILayout.LabelField("Velocidade total", myTarget.TotalSpeed.ToString());


        if (myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Velociade acima do permitido", MessageType.Error);
        }

        if (GUILayout.Button("Novo carro"))
        {
            myTarget.CreateCar();
        }

        EditorGUILayout.PropertyField(listProperty, true);

        if (myTarget.speeds.Count != 0)
        {
            if (GUILayout.Button("Random Speed"))
            {
                myTarget.SetSpeed();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Lista vazia!", MessageType.Error);
        }


    }
}
