using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject[] Obj;
    

    private void Start()
    {

        Obj[Obj.Length].SetActive(false);
    }
    public void H1()
    {

        Obj[Obj.Length].SetActive(false);
        Obj[0].SetActive(true);
        
        
    }

    public void H2(GameObject Gobj)
    {
        Gobj.SetActive(true);
    }
}
