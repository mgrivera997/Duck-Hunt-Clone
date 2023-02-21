using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;
    public Rigidbody2D rb;
    public int scoreValue;

    

    // Start is called before the first frame update
    void Start()
    {
        StartMove();
        StartCoroutine("Moving");
    }

    public void OnMouseDown()
    {
        KillSelf();
    }

    public void KillSelf() 
    {
        Destroy(this.gameObject);
    }

    public int GiveScoreValue()
    {
        return scoreValue;
    }

    public void VerticalMove() 
    {
        float y = Random.Range(-1, 1);
        if (rb.velocity.x == 0)y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(rb.velocity.x, vSpeed * y);
    }

    public void HorizontalMove()
    {
        float x = Random.Range(-1, 1);
        if (rb.velocity.y == 0) x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(hSpeed * x, rb.velocity.y);
    }

    public void StartMove() 
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(hSpeed * x, vSpeed);
    }

    public virtual IEnumerator Moving() 
    {
        WaitForSeconds waitTime = new WaitForSeconds((float)2);
        while (true) 
        {
            VerticalMove();
            HorizontalMove();
            Debug.Log(rb.velocity);
            yield return waitTime;
        }
    }
}
