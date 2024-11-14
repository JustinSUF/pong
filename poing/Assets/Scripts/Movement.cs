using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    void Update()
    {
        float move = 0;
        if (Input.GetKey(upKey)) move = speed;
        else if (Input.GetKey(downKey)) move = -speed;

        transform.Translate(0, move * Time.deltaTime, 0);
    }
}
