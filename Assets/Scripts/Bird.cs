    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int scoreValue;

    public double speedIncrement;

    

    // Start is called before the first frame update
    void Start()
    {
        Move();
        StartCoroutine("ChangeDirection");

        speedIncrement = 0.1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Down");
    }

    public void Move()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;

        Debug.Log(x);
        Debug.Log(y);
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    IEnumerator ChangeDirection() 
    {
        WaitForSeconds waitTime = new WaitForSeconds(2);
        while (true) 
        {
            Move();
            speed += (float)speedIncrement;
            yield return waitTime;
        }
    }
}
