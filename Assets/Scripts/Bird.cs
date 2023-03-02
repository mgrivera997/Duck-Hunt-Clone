using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;
    public Rigidbody2D rb;
    public int scoreValue;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(rb.velocity.x, vSpeed);
        HorizontalMove();

        StartCoroutine("Moving");
    }

    public void OnMouseDown()
    {
        if (gameManager != null) 
        {
            gameManager.OnBirdShot(this);
        }
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
        float y = Random.Range(-1.0f, 1.0f);
        if (rb.velocity.x == 0.0f) y = Random.Range(0.0f, 2.0f) == 0.0f ? -1.0f : 1.0f;
        rb.velocity = new Vector2(rb.velocity.x, vSpeed * y);
    }

    public void HorizontalMove()
    {
        float x = Random.Range(-1.0f, 1.0f);
        if (rb.velocity.y == 0.0f) x = Random.Range(0.0f, 2.0f) == 0.0f ? -1.0f : 1.0f;
        rb.velocity = new Vector2(hSpeed * x, rb.velocity.y);
    }

    public virtual IEnumerator Moving() 
    {
        WaitForSeconds waitTime = new WaitForSeconds((float)2);
        while (true) 
        {
            yield return waitTime;
            VerticalMove();
            HorizontalMove();
        }
    }
}