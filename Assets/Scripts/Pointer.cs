using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float DefaultLenght = 5.0f;
    public GameObject dot;
    public VR_InputModule inputModule;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateLine();
    }

    public void UpdateLine()
    {
        // Use default distance
        PointerEventData data = inputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance==0?DefaultLenght:data.pointerCurrentRaycast.distance;
        //Raycast
        RaycastHit hit = CreateRaycast(targetLength);
        //Default
        Vector3 endPos = transform.position + (transform.forward * targetLength);
        //or based on hit
        if (hit.collider != null)
            endPos = hit.point;
        // Set pos of dot
        dot.transform.position = endPos;
        // Set Line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPos);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, DefaultLenght);
        return hit;
    }
}
