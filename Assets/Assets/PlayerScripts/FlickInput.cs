using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickInput : MonoBehaviour
{
    [SerializeField]
    Vector2 m_vMinFlick = new Vector2(1f, 1f);

    private Vector2 m_vStartPos;
    private Vector2 m_vEndPos;

    public enum FlickConditions
    {
        NONE,
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    private void Update()
    {
        AssignInput();
    }

    private FlickConditions m_eFlick = FlickConditions.NONE;

    public FlickConditions GetFlick()
    {
        return m_eFlick;
    }

    private void Start()
    {
        ResetFlick();
    }
    private void ResetFlick()
    {
        m_eFlick = FlickConditions.NONE;
    }
    private void HandleFlickInput()
    {
        Vector2 distance = new Vector2((m_vEndPos.x - m_vStartPos.x),
            (m_vEndPos.y - m_vStartPos.y));

        if(Mathf.Abs(distance.x) <= m_vMinFlick.x && Mathf.Abs(distance.x) <= m_vMinFlick.y)
        {
            m_eFlick = FlickConditions.NONE;
        }
        else if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //float x = Mathf.Sign(m_vEndPos.x - m_vStartPos.x);
            if (distance.x < 0)
                m_eFlick = FlickConditions.LEFT;
            else if (distance.x > 0)
                m_eFlick = FlickConditions.RIGHT;
        }
        else
        {
            //float y = Mathf.Sign(m_vEndPos.y - m_vStartPos.y);
            if (distance.y < 0)
                m_eFlick = FlickConditions.DOWN;
            else if (distance.y > 0)
                m_eFlick = FlickConditions.UP;
        }
        
    }

    private void AssignInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                m_vStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                m_vEndPos = touch.position;
                HandleFlickInput();
            }
        }
        else if (m_eFlick != FlickConditions.NONE)
        {
            ResetFlick();
        }
    }
}
