using UnityEngine;

public class ControlBase : MonoBehaviour
{
    [Header("Variaveis do Player")]
    public ControlKnife knife;

    void Start()
    {
        knife = FindObjectOfType<ControlKnife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))// quando a lamina colidir com a base, para
        {
            knife.gravity = 0;
            knife.velocity = 0;
            knife.canMove = false;
            //print("trava a faca");
        }

        if (other.gameObject.CompareTag("Hilt"))// quando o punhao colidir com a base, stuna
        {
            knife.stunned = true;
            //print("empurra e stuna");
        }
    }
}