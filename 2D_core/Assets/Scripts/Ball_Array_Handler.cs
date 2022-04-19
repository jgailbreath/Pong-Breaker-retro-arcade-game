using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Array_Handler : MonoBehaviour
{
    public Ball[] balls = new Ball[2];

    void Update()
    {
        if (balls[0].reset || balls[1].reset)
        {
            foreach (Ball ball in balls)
            {
                ball.Reset();
            }
        }
    }
}
