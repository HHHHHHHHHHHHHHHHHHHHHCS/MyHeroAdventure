using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Vector2 offestBoxNumber = new Vector2(3, 2);
    [SerializeField]
    private Vector2 minPos = Vector2.zero;
    [SerializeField]
    private Vector2 maxPos = new Vector2(24.854f, 28f);


    private Transform mainCamera;

    private Vector3 offest;

    private Vector3 endPos;

    private Vector2 boxSize;

    private void Awake()
    {
        boxSize = GetComponent<BoxCollider2D>().size;
        mainCamera = Camera.main.transform;
        offest = mainCamera.position - transform.position;
        endPos = mainCamera.position;
    }

    private void Update()
    {
        mainCamera.position = CalculatePos();
    }

    private Vector3 CalculatePos()
    {
        /*if(transform.position.x-(endPos.x-offest.x)>0)
        {
            Debug.Log(transform.position.x - minPos.x- boxSize.x * offestBoxNumber.x);

            if (transform.position.x - minPos.x >= boxSize.x * offestBoxNumber.x)
            {
                endPos.x = transform.position.x + offest.x;
            }
        }
        else
        {
            endPos.x = transform.position.x + offest.x;
        }

        if (transform.position.y - (endPos.y - offest.y) > 0)
        {
            if (transform.position.y - minPos.y >= boxSize.y * offestBoxNumber.y)
            {
                endPos.y = transform.position.y + offest.y;
            }
        }
        else
        {
            endPos.y = transform.position.y + offest.y;
        }*/
        endPos.x = transform.position.x + offest.x;
        endPos.y = transform.position.y + offest.y;
        endPos.x = Mathf.Clamp(endPos.x, minPos.x, maxPos.x);
        endPos.y = Mathf.Clamp(endPos.y, minPos.y, maxPos.y);

        return endPos;
    }
}
