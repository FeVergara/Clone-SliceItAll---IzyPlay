using UnityEngine;

public class ControlScenario : MonoBehaviour
{
    [Header("Variaveis de Velocidade")]
    [SerializeField] private float speedWord;

    [Header("Variaveis do Player")]
    private ControlKnife knife;

    private void Start()
    {
        knife = FindObjectOfType<ControlKnife>();
    }

    private void FixedUpdate()
    {
        if (knife.started && knife.canMove && !knife.stunned)
        {
            transform.Translate(Vector3.left * Time.fixedDeltaTime * speedWord, Space.World);//Move a fase para a esquerda
        }
    }
}
