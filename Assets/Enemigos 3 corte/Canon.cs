using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject balaizq;
    [SerializeField] GameObject balader;
    public Transform ubicaciondecanon;
    [SerializeField] GameObject destructordelobjeto;

    //en public Transform ubicaciondecanon se tiene que poner el sprite del cañon PUESTO EN LA ESCENA, el cual definira la salida de la bala

    private float fireRate = 2;
    private float nextFire = 0;

    Animator m_animator;
    BoxCollider2D m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
    }
    bool Disparar()
    {

        RaycastHit2D hitcanon = Physics2D.Raycast(m_collider.bounds.center, Vector2.right, m_collider.bounds.extents.y + 4f, LayerMask.GetMask("personaje"));
        RaycastHit2D hitcanon2 = Physics2D.Raycast(m_collider.bounds.center, Vector2.left , m_collider.bounds.extents.y + 4f, LayerMask.GetMask("personaje"));
        Debug.DrawRay(m_collider.bounds.center, Vector2.right * (m_collider.bounds.extents.y + 4f), Color.red);
        Debug.DrawRay(m_collider.bounds.center, Vector2.left * (m_collider.bounds.extents.y + 4f), Color.blue);

        if (hitcanon.collider != null || hitcanon2.collider != null)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                m_animator.SetBool("IsDetected", true);
                m_animator.SetTrigger("IsDetecting");
                Instantiate(balaizq, ubicaciondecanon.position, ubicaciondecanon.rotation);
                Instantiate(balader, ubicaciondecanon.position, ubicaciondecanon.rotation);
            }
        }
        else
        m_animator.SetBool("IsDetected", false);



        return hitcanon.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string bala = objeto.tag;

        if (objeto.tag == "bala")

        {
        m_animator.SetTrigger("Destroy");
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 1f);
        }

    }
}
