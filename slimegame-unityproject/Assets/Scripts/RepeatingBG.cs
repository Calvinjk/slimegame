using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    public float speed;

    public float endX;
    public float startX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //set for the rigidbody instead of moving it a fix distance every frame and make sure it does not have drag at start()

        if (transform.position.x <= endX)
		{
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
		}
    }
}
