using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] float movSpeed = 0.1f;
    [SerializeField] float horizontalPadding;
    [SerializeField] float verticalPadding;
    Vector2 rawInput;
    Vector2 minBound;
    Vector2 maxBound;
    void Start()
    {
      InitBounds();
    }
    void Update()
    {
      move();
    }
    void InitBounds()
    {
      Camera mainCamera = Camera.main;
      minBound = mainCamera. ViewportToWorldPoint(new Vector2(0,0));
      maxBound = mainCamera. ViewportToWorldPoint(new Vector2(1,1)); 
    }
      void OnMove(InputValue value)
    {
      rawInput = value.Get<Vector2>();
    }
    void move()
    {
        Vector2 delta = rawInput*movSpeed*Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x +horizontalPadding,maxBound.x -horizontalPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y+verticalPadding,maxBound.y-verticalPadding);
        transform.position = newPos;
    }
}

