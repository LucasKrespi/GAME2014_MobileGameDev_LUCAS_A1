using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlickInput))]
public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private bool m_bIsMoving = false;
    private Vector2 m_vOriginalPos, m_vTargetPos;
    private float m_fTimetoMove;
    private float m_fDistance = 0.7f;

    private FlickInput flickInput;

    
    
    void Start()
    {
        flickInput = GetComponent<FlickInput>();

    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard input Temporary
        //if (m_bIsMoving && flickInput.GetFlick() == FlickInput.FlickConditions.NONE)
        //{
        //    return;
        //}

        //switch (flickInput.GetFlick())
        //{
        //    case FlickInput.FlickConditions.UP:
        //        StartCoroutine(Move(Vector2.up));
        //        break;

        //    case FlickInput.FlickConditions.DOWN:
        //        StartCoroutine(Move(Vector2.down));
        //        break;

        //    case FlickInput.FlickConditions.LEFT:
        //        StartCoroutine(Move(Vector2.left));
        //        break;

        //    case FlickInput.FlickConditions.RIGHT:
        //        StartCoroutine(Move(Vector2.right));
        //        break;
        //}

        //Keyboard input Temporary

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Move(Vector2.up * m_fDistance));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Move(Vector2.down * m_fDistance));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Move(Vector2.right * m_fDistance));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Move(Vector2.left * m_fDistance));
        }


    }
    private IEnumerator Move(Vector2 target)
    {
        SoundManager.GetSoundManagerInstance().PlaySound("jump");

        m_bIsMoving = true;

        float tempTime = 0;
        m_vOriginalPos = transform.position;
        m_vTargetPos = m_vOriginalPos + target;

        while(m_fTimetoMove > tempTime)
        {
            transform.position = Vector3.Lerp(m_vOriginalPos, m_vTargetPos, (tempTime / m_fTimetoMove));
            tempTime += Time.deltaTime;
            yield return null;
        }

        transform.position = m_vTargetPos;

        m_bIsMoving = false;
    }

    public void moveup()
    {
        StartCoroutine(Move(Vector2.up * m_fDistance));
    }

}
