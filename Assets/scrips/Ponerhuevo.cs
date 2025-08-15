using UnityEngine;

public class PonerHuevo : MonoBehaviour
{
    public GameObject huevo;
    public float intervalo = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(PonerunHuevo), intervalo, intervalo);
    }

    void PonerunHuevo()
    {
        //Debug.Log("PonerHuevo");
        Instantiate(huevo, transform.position, Quaternion.identity);
   }
   
}