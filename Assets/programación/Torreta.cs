using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    BoxCollider2D myCollider;
    [SerializeField] float fireRate;
    [SerializeField] private Transform cañon;
    [SerializeField] GameObject BalaCañon;
    [SerializeField] GameObject explosión;
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] GameObject Cuerpo;
    [SerializeField] float vida;

    float nextFire = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("jugador en frente: " + DetectarJugadorDer());
        Debug.Log("jugador atrás: " + DetectarJugadorIzq());
        dispararjugador();

    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            muerte();
        }
    }

    void muerte()
    {
        Instantiate(explosión, puntoA.transform.position, puntoA.rotation);
        Instantiate(Cuerpo, puntoB.transform.position, puntoB.rotation);
        Destroy(this.gameObject);
    }
    bool DetectarJugadorDer()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.right, myCollider.bounds.extents.y + 10f,
                                                                                                    LayerMask.GetMask("personaje"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.right * 10f, Color.red);
        return (raycast_player.collider != null);
    }
    bool DetectarJugadorIzq()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.left, myCollider.bounds.extents.y + 10f,
                                                                                                    LayerMask.GetMask("personaje"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.left * 10f, Color.red);
        return (raycast_player.collider != null);
    }

    void dispararjugador()
    {
        if (DetectarJugadorIzq() && Time.time >= nextFire)
        {
            transform.localScale = new Vector2(5, 5);
            Instantiate(BalaCañon, cañon.transform.position, cañon.rotation);
            nextFire = Time.time + fireRate;
        }
        else if (DetectarJugadorDer() && Time.time >= nextFire)
        {
            transform.localScale = new Vector3(-5, 5);
            Instantiate(BalaCañon, cañon.transform.position, cañon.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
