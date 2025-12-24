using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarBase))]
public class CarBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        CarBase myTarget = (CarBase)target;

        myTarget.carbasePrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carbasePrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("Velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade total", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calcule a velocidade total do carro", MessageType.Info);

        if (myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Velociade acima do permitido", MessageType.Error);
        }

        if (GUILayout.Button("Novo carro"))
        {
            myTarget.CreateCar();
        }

    }
}
