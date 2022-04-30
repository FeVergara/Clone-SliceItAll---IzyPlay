using UnityEngine;
using UnityEngine.UI;

public class ControlProps : MonoBehaviour
{
    [Header("Variaveis dos Objetos Filhos")]
    public GameObject leftObject;
    public GameObject rightObject;

    [Header("Variaveis do Player")]
    private ControlKnife knife;

    [Header("Variavel do HUD")]
    public Text textPoints;

    void Start()
    {
        knife = FindObjectOfType<ControlKnife>();
        textPoints = Text.FindObjectOfType<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            //Add pontos
            knife.points++;
            textPoints.text = "Pontuação: " + knife.points.ToString();

            //Retira os objetos do parentesco
            leftObject.transform.parent = null;
            rightObject.transform.parent = null;

            //Adiciona movimento ao objeto quando cortado
            leftObject.GetComponent<Rigidbody>().AddForce(0, 0, -1, ForceMode.Impulse);
            leftObject.GetComponent <Rigidbody>().useGravity = true;
            rightObject.GetComponent<Rigidbody>().AddForce(0, 0, 1, ForceMode.Impulse);
            rightObject.GetComponent <Rigidbody>().useGravity = true;
            //print("corta objeto");

            //Deleta os objetos cortados
            this.gameObject.SetActive(false);
            Destroy(leftObject, 3f);
            Destroy(rightObject, 3f);
            Destroy(this.gameObject, 4f);
        }

        if (other.gameObject.CompareTag("Hilt"))
        {
            knife.stunned = true;
            //print("empurra e stuna");
        }
    }
}
