using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveTo
{
    Move_Left,
    Move_Right
}

public class Component_Example : MonoBehaviour
{
    MoveTo move = MoveTo.Move_Right;
    void Start()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (transform.position.x < -4)
            {
                move = MoveTo.Move_Right;
            }
            else if (transform.position.x > 4)
            {
                move = MoveTo.Move_Left;
            }

            if (move == MoveTo.Move_Right)
            {
                transform.Translate(1.0f * Vector3.right, Space.World);
            }
            else
            {
                transform.Translate(-1.0f * Vector3.right, Space.World);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}


