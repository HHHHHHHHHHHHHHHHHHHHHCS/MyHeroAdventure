using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private PlayerKeyboard playerKeyCode;
    [SerializeField]
    private PlayerProperty playerProperty;


    private Vector2 boxSize;
    private PlayerAnimator playerAnimator;


    private float moveTimer;

    private void Awake()
    {
        boxSize = GetComponent<BoxCollider2D>().size;
        playerAnimator = GetComponent<PlayerAnimator>();
    }


    void Update()
    {
        Move();

    }


    void Move()
    {
        if (moveTimer <= 0)
        {
            if (Input.GetKey(playerKeyCode.Up))
            {
                _Move(Vector2.up);
            }
            else if (Input.GetKey(playerKeyCode.Down))
            {
                _Move(Vector2.down);
            }
            else if (Input.GetKey(playerKeyCode.Left))
            {
                _Move(Vector2.left);
            }
            else if (Input.GetKey(playerKeyCode.Right))
            {
                _Move(Vector2.right);
            }
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(playerKeyCode.Up)|| Input.GetKeyUp(playerKeyCode.Down) 
            ||Input.GetKeyUp(playerKeyCode.Left) ||Input.GetKeyUp(playerKeyCode.Right) )
        {
            _Idle();
        }

    }

    void _Idle()
    {
        if (playerAnimator != null)
        {
            playerAnimator.PlayerAnim(Vector2.zero);
        }
    }

    void _Move(Vector2 dir)
    {
        moveTimer = playerProperty.MoveTime;
        transform.localPosition += new Vector3(dir.x * boxSize.x, dir.y * boxSize.y, 0);
        if(playerAnimator!=null)
        {
            playerAnimator.PlayerAnim(dir);
        }
    }
}
