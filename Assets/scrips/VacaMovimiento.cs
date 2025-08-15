using UnityEngine;

public class VacaMovimiento : MonoBehaviour
{
    public Transform areaMovimiento;
    public float velocidad = 1.5f;
    public Vector2 destino;
    public SpriteRenderer sr;
    public Vector2 positionInicial;
    
    private Animator anim; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 

        NuevoDestino();
        positionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento
        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);  

        // Dirección
        Vector2 direccion = positionInicial - destino;
        sr.flipX = direccion.x >= 0;

        
        bool estaCaminando = Vector2.Distance(transform.position, destino) > 0.1f;
        anim.SetBool("estaCaminando", estaCaminando); 

        
        if (!estaCaminando)
        {
            NuevoDestino();
            positionInicial = transform.position;
        }
    }

    void NuevoDestino()
    {
        Vector2 centro = areaMovimiento.position;
        Vector2 tamaño = areaMovimiento.localScale;

        float x = Random.Range(centro.x - tamaño.x / 2f, centro.x + tamaño.x / 2f);
        float y = Random.Range(centro.y - tamaño.y / 2f, centro.y + tamaño.y / 2f);

        destino = new Vector2(x, y);
    }   
}