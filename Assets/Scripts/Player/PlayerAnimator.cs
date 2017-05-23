using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private struct AnimatorValue
    {
        public const float up = 1f;
        public const float upIdle = 1.5f;
        public const float down = 2f;
        public const float downIdle = 2.5f;
        public const float left = 3f;
        public const float leftIdle = 3.5f;
        public const float right = 4f;
        public const float rightIdle = 4.5f;
    }


    private Animator anim;

    private bool isIdle;

    private const string state = "State";
    public float StateValue
    {
        get
        {
            return anim.GetFloat(state);
        }

        private set
        {
            anim.SetFloat(state, value);
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isIdle = StateValue * 2 % 2 == 1 ? true : false;
    }

    public void PlayerAnim(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            if (!isIdle)
            {
                isIdle = true;
                StateValue += 0.5f;
            }
        }
        else
        {
            if (isIdle)
            {
                isIdle = false;
            }
            if (dir == Vector2.up && StateValue != AnimatorValue.up)
            {
                StateValue = AnimatorValue.up;
            }
            else if (dir == Vector2.down && StateValue != AnimatorValue.down)
            {
                StateValue = AnimatorValue.down;
            }
            else if (dir == Vector2.left && StateValue != AnimatorValue.left)
            {
                StateValue = AnimatorValue.left;
            }
            else if (dir == Vector2.right && StateValue != AnimatorValue.right)
            {
                StateValue = AnimatorValue.right;
            }
        }

    }

}
