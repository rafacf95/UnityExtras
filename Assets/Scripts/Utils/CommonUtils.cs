using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEditor;

public static class CommonUtils
{
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

#if UNITY_EDITOR
    [MenuItem("rafacf95/Create Cube %g")]
    public static void CreateCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Vector3.zero;
    }

    [MenuItem("rafacf95/Create Car Prefab %#g")]
    public static void CreateCarPrefab()
    {
        GameObject prefab = Resources.Load<GameObject>("Car");
        if (prefab != null)
        {
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        }
        else
        {
            Debug.LogError("Prefab not found!");
        }
    }
#endif
}
