using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberSpeed : MonoBehaviour
{
    public int speed = 1;
   public void ExtraSpeed()
    {
        if (speed <= 1)
        {
            speed++;
        }
        if (speed > 4)
        {
            speed = 1;
        }
    }
}
