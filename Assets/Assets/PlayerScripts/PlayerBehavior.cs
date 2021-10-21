using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlickInput))]
public class PlayerBehavior : MonoBehaviour
{
    //Movement Variables
    private bool m_bIsMoving = false;
    private Vector2 m_vOriginalPos, m_vTargetPos, m_vInitialPos;
    private float m_fTimetoMove;
    private float m_fDistance = 0.7f;

    //On plataform Variables
    private bool isInPlataform = false;
    private Direction plataformDirection;
    private const float waterBoundY_min = 0.2f;
    private const float waterBoundY_max = 3.5f;
    private int counter = 1;

    //imput variables
    private FlickInput flickInput;

    //Player Stats
    public int lives = 5;
    public int score = 0;
    public int coopCount = 0;



    void Start()
    {
        flickInput = GetComponent<FlickInput>();
        m_vInitialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ///Flick Movement
        if (!m_bIsMoving)
        {

            switch (flickInput.GetFlick())
            {
                case FlickInput.FlickConditions.NONE:

                    break;
                case FlickInput.FlickConditions.UP:
                    StartCoroutine(Move(Vector2.up * m_fDistance));
                    addScore(10);
                    break;

                case FlickInput.FlickConditions.DOWN:
                    StartCoroutine(Move(Vector2.down * m_fDistance));
                    break;

                case FlickInput.FlickConditions.LEFT:
                    StartCoroutine(Move(Vector2.left * m_fDistance));
                    break;

                case FlickInput.FlickConditions.RIGHT:
                    StartCoroutine(Move(Vector2.right * m_fDistance));
                    break;
            }

            //Keyboard input Temporary

            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(Move(Vector2.up * m_fDistance));
                addScore(10);
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




        if (isInPlataform)
        {
            if (plataformDirection == Direction.RIGHT)
                this.transform.Translate(Vector2.right * Time.deltaTime * 3.0f);
            else if (plataformDirection == Direction.LEFT)
                this.transform.Translate(Vector2.right * Time.deltaTime * -3.0f);
        }
        else if (this.transform.position.y >= waterBoundY_min && this.transform.position.y < waterBoundY_max)
        {

            if (counter % 10 == 0)
            {
                TakeALive();
                counter = 0;
            }
            counter++;
        }

        checkBounds();
    }

    private IEnumerator Move(Vector2 target)
    {
        SoundManager.GetSoundManagerInstance().PlaySound("jump");

        m_bIsMoving = true;

        float tempTime = 0;
        m_vOriginalPos = transform.position;
        m_vTargetPos = m_vOriginalPos + target;

        while (m_fTimetoMove > tempTime)
        {
            transform.position = Vector3.Lerp(m_vOriginalPos, m_vTargetPos, (tempTime / m_fTimetoMove));
            tempTime += Time.deltaTime;
            yield return null;
        }


        transform.position = m_vTargetPos;

        m_bIsMoving = false;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
            TakeALive();


        if (collision.gameObject.tag == "Coop")
        {
            if (collision.gameObject.GetComponent<CoopBehavior>().isOccupied)
            {
                TakeALive();

            }
            else
            {
                collision.gameObject.GetComponent<CoopBehavior>().isOccupied = true;
                this.transform.position = m_vInitialPos;
                coopCount++;
                addScore(50);
            }
        }
    }

    private void TakeALive()
    {
        lives--;
        GM.getGMInstance().UpdateLivesDisplay(lives);
        SoundManager.GetSoundManagerInstance().PlaySound("damage");
        this.transform.position = m_vInitialPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataform")
        {
            plataformDirection = collision.GetComponent<PlataformsBehavior>().direction;
            isInPlataform = true;
        }

        if (collision.gameObject.tag == "Bonus")
        {
            addScore(200);
            collision.gameObject.SetActive(false);
            SoundManager.GetSoundManagerInstance().PlaySound("bonus");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataform")
        {
            isInPlataform = false;
        }
    }

    public void addScore(int points)
    {
        score += points;
    }

    void checkBounds()
    {
        if (this.gameObject.transform.position.x > 10 || this.gameObject.transform.position.x < -10)
        {
            TakeALive();
        }
        if (this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -5)
        {
            TakeALive();
        }
    }
}
