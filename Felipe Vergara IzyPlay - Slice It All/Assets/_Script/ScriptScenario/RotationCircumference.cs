using UnityEngine;

public class RotationCircumference : MonoBehaviour
{
    [Header("Variaveis de Velocidade")]
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward.normalized, speed * Time.fixedDeltaTime);//Rotaciona a circunferencia com Objetos Cortaveis
    }
}
