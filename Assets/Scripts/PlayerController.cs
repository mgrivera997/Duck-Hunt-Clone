using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftward();
        MoveRightward();
        MoveBackward();
        MoveForward();
    }

    public virtual void MoveLeftward()
    {
        if(Input.GetKey("a") || Input.GetKey("left") )
        {
            transform.position += new Vector3(-1*moveSpeed*Time.deltaTime,0,0);
        }
    }
    public virtual void MoveRightward()
    {
        if(Input.GetKey("d") || Input.GetKey("right") )
        {
            transform.position += new Vector3(1*moveSpeed*Time.deltaTime,0,0);
        }
    }
    public virtual void MoveForward()
    {
        if(Input.GetKey("w") || Input.GetKey("up") )
        {
            transform.position += new Vector3(0,0,1*moveSpeed*Time.deltaTime);
        }
    }
    public virtual void MoveBackward()
    {
        if(Input.GetKey("s") || Input.GetKey("down") )
        {
            transform.position += new Vector3(0,0,-1*moveSpeed*Time.deltaTime);
        }
    }
}
