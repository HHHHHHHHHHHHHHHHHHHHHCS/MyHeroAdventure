using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private static PlayerCtrl _instance;

    public static PlayerCtrl Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    public PlayerTalk PlayerTalk
    {
        get
        {
            return playerTalk;
        }
    }

    [SerializeField]
    private PlayerKeyboard playerKeyCode;
    [SerializeField]
    private PlayerProperty playerProperty;
    [SerializeField]
    private LayerMask layer;


    private Vector2 boxSize;
    private PlayerAnimator playerAnimator;

    private PlayerTalk playerTalk;

    private float moveTimer;



    private void Awake()
    {
        _instance = this;
        boxSize = GetComponent<BoxCollider2D>().size;
        playerAnimator = GetComponent<PlayerAnimator>();
        playerTalk = GetComponent<PlayerTalk>();
    }


    void Update()
    {
        Move();
    }


    void Move()
    {
        if (moveTimer <= 0)
        {
            if (!PlayerTalk.IsTalk)
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

        }
        else
        {
            moveTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(playerKeyCode.Up) || Input.GetKeyUp(playerKeyCode.Down)
            || Input.GetKeyUp(playerKeyCode.Left) || Input.GetKeyUp(playerKeyCode.Right))
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, dir, boxSize.x, layer);
        if (ray.collider != null)
        {
            if (playerAnimator != null)
            {
                playerAnimator.PlayerAnim(dir);
            }
            if (ray.collider.gameObject.CompareTag(Tags.NPC))
            {
                NPC_Base npc = ray.collider.gameObject.GetComponent<NPC_Base>();
                if (npc != null)
                {
                    npc.Talk();
                }
            }
            else
            {
                moveTimer = 0;

            }
        }
        else
        {
            moveTimer = playerProperty.MoveTime;
            transform.localPosition += new Vector3(dir.x * boxSize.x, dir.y * boxSize.y, 0);
            if (playerAnimator != null)
            {
                playerAnimator.PlayerAnim(dir);
            }
        }
    }

}
