using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuveee : MonoBehaviour
{
    float yPosition;
    float xPosition;
    float speed = 0.5f;
    float dir;
    
    // Start is called before the first frame update
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += 1f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            dir -= 1;
        }
        else
        {
            dir = 0;
        }
        xPosition = xPosition + dir * speed * Time.deltaTime;
        transform.position = new Vector2(xPosition, 0);
    }
}
