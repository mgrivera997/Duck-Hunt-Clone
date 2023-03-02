using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameManager gameManager;

    private void OnMouseDown()
    {
        gameManager.OnMissShot();
    }
}
