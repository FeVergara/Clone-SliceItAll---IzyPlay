using System.Collections;
using UnityEngine;

public class ControlKnife : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;

    [Header("Variaveis de controle")]
    [HideInInspector]public bool started;

    [Header("Variaveis de HUD")]
    public int points;

    [Header("Variaveis para a movimentação")]
    [HideInInspector]public bool canMove = true;
    [HideInInspector]public bool stunned;
    private bool clickRotationKnife;
    private bool downKnife;

    [Header("Variaveis para o pulo")]
    [SerializeField]private float jumpForce = 3;
    [HideInInspector]public float velocity;
    public float gravity = -4.905f;
    private bool jumping;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t0 = Input.GetTouch(0);

            started = true;
            if (t0.phase == TouchPhase.Began)
            {
                clickRotationKnife = true;
                downKnife = false;
                //print("Touch");

                if (!stunned)
                {
                    gravity = -4.905f;
                    canMove = true;
                    jumping = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        AutomaticRotation();
        ClickRotation();
        Jump();
        Stunned();

        if (transform.position.z != -6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6);
        }

        //print(velocity);
    }

    private void Jump()
    {
        if (started)
        {
            velocity += gravity * Time.fixedDeltaTime; //Controla Gravity

            if (jumping)
            {
                velocity = jumpForce;
                jumping = false;
                //print("Jump");
            }

            rb.MovePosition(transform.position + new Vector3(0, velocity, 0) * Time.fixedDeltaTime);
            //transform.Translate(new Vector3(0, velocity, 0) * Time.fixedDeltaTime, Space.World);
        }
    }//Pulo da faca

    private void ClickRotation()
    {
        if (clickRotationKnife && !downKnife && !stunned && canMove)
        {
            Vector3 velocidadeAngular = new Vector3(0, 450, 0);
            Quaternion rotacaoDelta = Quaternion.Euler(velocidadeAngular * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * rotacaoDelta);

            //transform.RotateAround(transform.position, Vector3.back.normalized, 500 * Time.fixedDeltaTime);
            //print(GetComponent<Transform>().localEulerAngles);

            if (transform.localEulerAngles.x > 0 && transform.localEulerAngles.x < 15 && transform.localEulerAngles.y == 90)
            {
                clickRotationKnife = false;
                downKnife = true;
            }
        }
    }//Rotação manual da faca

    private void AutomaticRotation()
    {
        if (downKnife && !clickRotationKnife && !stunned && canMove)
        {
            if (transform.localEulerAngles.x < 90 && transform.localEulerAngles.x > 0 && transform.localEulerAngles.y == 270 || transform.localEulerAngles.x < 360 && transform.localEulerAngles.x > 270 && transform.localEulerAngles.y == 270)
            {
                Vector3 velocidadeAngular = new Vector3(0, 600, 0);
                Quaternion rotacaoDelta = Quaternion.Euler(velocidadeAngular * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * rotacaoDelta);

                //transform.RotateAround(transform.position, Vector3.back.normalized, 600 * Time.fixedDeltaTime);
                //print(GetComponent<Transform>().localEulerAngles);
            }
            else
            {
                Vector3 velocidadeAngualar = new Vector3(0, 100, 0);
                Quaternion rotacaoDelta = Quaternion.Euler(velocidadeAngualar * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * rotacaoDelta);

                //transform.RotateAround(transform.position, Vector3.back.normalized, 100 * Time.fixedDeltaTime);
                //print(GetComponent<Transform>().localEulerAngles);
            }
        }
    }//Rotação automatica da faca

    private void Stunned()
    {
        if (stunned)
        {
            StartCoroutine(ControlStun());
        }
    }//Stuna faca

    IEnumerator ControlStun()//Controla o Stun
    {
        clickRotationKnife = false;
        gravity = 0f;
        velocity = 0f;
        transform.Translate(new Vector3(transform.position.x + -0.2f, transform.position.y + 0.2f) * Time.fixedDeltaTime, Space.Self);
        yield return new WaitForSeconds(0.3f);
        jumping = true;
        downKnife = true;
        stunned = false;
        gravity = -4.905f;
    }
}