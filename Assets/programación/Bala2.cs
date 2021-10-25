using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fireRate;


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
}
