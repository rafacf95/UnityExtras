using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MonoBehaviour
{

    public int speed = 20;
    public int gear = 5;
    public GameObject carbasePrefab;
    public List<int> speeds;


    public int TotalSpeed
    {
        get { return speed * gear; }
    }

    public void CreateCar()
    {
        var a = Instantiate(carbasePrefab);
        a.transform.position = Vector3.zero;
    }

    public void SetSpeed()
    {
        speed = speeds.GetRandom();
    }
}
