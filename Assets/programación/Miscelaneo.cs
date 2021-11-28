using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscelaneo : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] float fireRate;

    Animator animabala;
    Rigidbody2D balacuerpo;
    BoxCollider2D balacolision;
    public GameObject torreta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }
    void movimiento()
    {
        
        if (torreta.transform.localScale.x == 5) //&& balacuerpo.velocity.x < 0.1f)//isquierda
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            //balacuerpo.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(5, 5);
            //balacuerpo.AddForce(new Vector2(-speed, 0));
        }
        else if (torreta.transform.localScale.x == -5) //&& balacuerpo.velocity.x > -0.1f) //derecha
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            //balacuerpo.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-5, 5);
            //balacuerpo.AddForce(new Vector2 (speed,0));
        }
    }
}
