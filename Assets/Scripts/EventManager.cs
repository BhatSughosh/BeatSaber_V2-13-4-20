using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject[] Obj;
    

    private void Start()
    {
        Obj[Obj.Length].SetActive(false);
    }
    public void H1()
    {
        Obj[0].SetActive(true);
    }
}
