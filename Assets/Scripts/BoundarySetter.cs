using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundarySetter : MonoBehaviour
{
    public GameObject topRightBoundary;
    public GameObject bottomLeftBoundary;

    // Start is called before the first frame update
    void Start()
    {
        SetBoundary(); 
    }

    void SetBoundary()
    {
        Vector3 newPosition = new Vector3();

        newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        topRightBoundary.transform.position = newPosition;

        newPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        bottomLeftBoundary.transform.position = newPosition;
    }
}
