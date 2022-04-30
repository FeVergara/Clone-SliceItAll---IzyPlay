using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    [Header("Variaveis de posição")]
    [SerializeField] private Vector3 camPosition;
    public Transform player;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + camPosition, 1);//movimenta a camera seguindo o jogador
    }
}
