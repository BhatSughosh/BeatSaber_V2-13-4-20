using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluecube : MonoBehaviour
{
    ScoreBoard score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue")
        {
            Destroy(other.gameObject);
            score.scoreCard++;
        }
    }
}
