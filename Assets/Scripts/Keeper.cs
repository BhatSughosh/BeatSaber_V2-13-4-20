using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Green" || other.tag=="Blue")
        Destroy(other.gameObject);
    }
}
