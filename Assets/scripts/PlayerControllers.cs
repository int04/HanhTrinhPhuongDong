using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedJump = 5f;
    private bool _jumpUp = false;
    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D rb;
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
    }


    private void FixedUpdate()
    {
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
        }
        else if (_keys["jump"] && rb.velocity.y <= 0 && _jumpUp == true)
        {
            _jumpUp = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

    }



    private void Update()
    {
        _keys["up"] = Input.GetKey(KeyCode.UpArrow);
        _keys["down"] = Input.GetKey(KeyCode.DownArrow);
        _keys["left"] = Input.GetKey(KeyCode.LeftArrow);
        _keys["right"] = Input.GetKey(KeyCode.RightArrow);
        _keys["jump"] = Input.GetKey(KeyCode.UpArrow);



    }


}