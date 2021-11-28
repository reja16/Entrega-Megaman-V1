using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] public float daño;
    [SerializeField] public float tiempo;


    Animator animabala;
    Rigidbody2D balacuerpo;
    BoxCollider2D balacolision;
    // Start is called before the first frame update
    void Start()
    {
        animabala = GetComponent<Animator>();
        animabala.SetBool("Choque", false);
        balacuerpo = GetComponent<Rigidbody2D>();
        balacolision = GetComponent<BoxCollider2D>();
    }

    void tiempodevida()
    {
        Destroy(gameObject, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<megaman>().TomarDaño(daño);
        }
    }
}
