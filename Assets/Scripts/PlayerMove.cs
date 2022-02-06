using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [Tooltip("Tips")] [SerializeField] float xRange = 8.5f;

    void Start()
    {       
        Time.timeScale = 0;
    }

    void Update()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float xThrow = Input.GetAxis("Horizontal"); 
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawXPos = transform.position.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.position = new Vector2(clampedXPos, transform.position.y);

        //float MoveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 move = new Vector2(MoveHorizontal, 0.0f);
        //transform.Translate(move * speed * Time.deltaTime);
    }    
}
