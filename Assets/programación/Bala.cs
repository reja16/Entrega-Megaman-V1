using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float tiempo;
    [SerializeField] float daño;

    Animator animabala;
    Rigidbody2D balacuerpo;
    BoxCollider2D balacolision;
    public GameObject megaman;
    

    // Start is called before the first frame update
    void Start()
    {
        megaman = GameObject.Find("personaje");
        animabala = GetComponent<Animator>();
        //animabala.SetBool("Choque", false);
        balacuerpo = GetComponent<Rigidbody2D>();
        balacolision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
        
    }

    void movimiento()
    {
        tiempodevida();
        if (megaman.transform.localScale.x < 0 && balacuerpo.velocity.x < 0.1f)//isquierda
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            balacuerpo.velocity = new Vector2(-speed, 0);
            //balacuerpo.AddForce(new Vector2(-speed, 0));
        }
        else if (megaman.transform.localScale.x > 0 && balacuerpo.velocity.x > -0.1f) //derecha
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            balacuerpo.velocity = new Vector2(speed, 0);
            //balacuerpo.AddForce(new Vector2 (speed,0));
        }
    }
    void tiempodevida()
    {
        Destroy(gameObject, tiempo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enenmigo"))
        {
            collision.GetComponent<Torreta>().TomarDaño(daño);
        }
    }

    bool suelo()
    {
        return balacolision.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }


}
