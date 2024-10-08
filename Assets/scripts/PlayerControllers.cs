﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedJump = 5f;
    private bool _jumpUp = false;
    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI namePlayer;
    [SerializeField] private string setNamePlayer = "";
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        if (setNamePlayer.Length >= 1)
        {
            namePlayer.text = setNamePlayer;
        }
    }

    public void SetNamePlayer(string namec)
    {
        namePlayer.text = namec;
    }
    public void SetDefaultXY()
    {
        gameObject.transform.position = new Vector3(-13, 6, 0);
    }

    Dictionary<string, bool> _keys = new Dictionary<string, bool>()
    {
        {"up", false},
        {"down", false},
        {"left", false},
        {"right", false},
        {"jump", false}
    };

    private void UpdateMove(bool right = true)
    {
        var k = gameObject.transform.localScale;
        if (right && k.x < 0)
        {
            k.x *= -1;
        }
        else if (right == false && k.x > 0)
        {
            k.x *= -1;
        }
        gameObject.transform.localScale = k;

        var m = canvas.transform.localScale;
        if (right && m.x < 0)
        {
            m.x *= -1;
        }
        else if (right == false && m.x > 0)
        {
            m.x *= -1;
        }
        canvas.transform.localScale = m;
    }


    private void FixedUpdate()
    {
        if (GameObject.Find("Question") || GameObject.Find("Win"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("move",0);
            return;
        }
        if (_keys["left"])
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.SetInteger("move",1);
            UpdateMove(false);
        }
        else if (_keys["right"])
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetInteger("move",1);
            UpdateMove();
        }
        else if (_keys["left"] == false && _keys["right"] == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("move",0);
        }

        if (_keys["jump"] && _jumpUp == false)
        {
            _jumpUp = true;
            rb.velocity = new Vector2(rb.velocity.x, speedJump);
            _keys["jump"] = false;
        }
        else if (_keys["jump"] && rb.velocity.y <= 0 && _jumpUp == true)
        {
            _jumpUp = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            _keys["jump"] = false;
        }

    }


    [SerializeField]private bl_Joystick Joystick;//Joystick reference for assign in inspector

    bool isPc()
    {
        return Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer;
    }

    private void Update()
    {
        bool z = isPc();

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _keys["right"] = true;
            return;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _keys["right"] = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _keys["left"] = true;
            return;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _keys["left"] = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _keys["jump"] = true;
            return;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _keys["jump"] = false;
            return;
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            return;
        }


        if (Joystick.gameObject.activeSelf == false) return;

        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick
        if (v > 0)
        {
            _keys["jump"] = true;
        }
        else if (v < 0)
        {
            _keys["jump"] = false;
        }
        if (h > 0)
        {
            _keys["right"] = true;
            _keys["left"] = false;
        }
        else if (h < 0)
        {
            _keys["left"] = true;
            _keys["right"] = false;
        }
        else if(h == 0)
        {
            _keys["left"] = false;
            _keys["right"] = false;
        }

    }


}