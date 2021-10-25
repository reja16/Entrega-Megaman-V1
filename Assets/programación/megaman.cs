using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] BoxCollider2D misPies;
    [SerializeField] float fireRate;
    [SerializeField] GameObject Bala;
    [SerializeField] GameObject Bala2;
    [SerializeField] private Transform disparador;

    Animator MyAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    float movH;
    float nextFire = 0;
    int saltosExtras = 1;
    int contandoSaltos = 0;

    public float congelamientoDeDash;
    public float Dash_V;
    float Dash_T= 0;
    int direccionImpulso=1;
    public bool ani;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        MyAnimator.SetBool("isrunning", false);
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        ani = true;
    }

    // Update is called once per frame
    void Update()
    {
        correr();
        saltodoble();
        caer();
        Disparar();
    }

    void Disparar()
    {

        if (Input.GetKeyDown(KeyCode.W) && Time.time >= nextFire)
        {
            
            MyAnimator.SetLayerWeight(1, 1);

            Instantiate(Bala, disparador.transform.position, disparador.rotation);
            nextFire = Time.time + fireRate;
            
        }
        else if(ani == false)
        {
            
            MyAnimator.SetLayerWeight(1, 0);
         
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Invoke("brazo", 2.1f);
            Invoke("brazo2", 2f);
        }

        //ACA DEJE UNA OPCION DE IF PARA QUE CUANDO UNO SOLTARA LA TECLA, EL MUÑECO DEJARA DE DISPARAR




    }

    void brazo()
    {
            ani = true;
    }

    void brazo2()
    {
        ani = false;
    }


    void caer()
    {
        if(myBody.velocity.y<0)
        {
            MyAnimator.SetBool("falling", true);
        }
        else
        {
            MyAnimator.SetBool("falling", false);
        }
    }
    void Dash()
    {
       if(suelo())
        {
            if(Input.GetKey(KeyCode.X) && Time.time >= Dash_T)
            {
                MyAnimator.SetBool("isDashing", true);
                Dash_T = congelamientoDeDash + Time.time;

                if (Input.GetAxis("Horizontal") < 0)
                {
                    myBody.AddForce(new Vector2(-Dash_V, 0), ForceMode2D.Impulse);
                }
                if (Input.GetAxis("Horizontal") > 0)
                {
                    myBody.AddForce(new Vector2(Dash_V, 0), ForceMode2D.Impulse);
                }


                //Esto es para corregir el impulso al principio del juego y en caso tal de un bug
                if (Input.GetAxis("Horizontal") == 0 && direccionImpulso == -1)
                {
                    myBody.AddForce(new Vector2(-Dash_V, 0), ForceMode2D.Impulse);
                }

                if (Input.GetAxis("Horizontal") == 0 && direccionImpulso == 1)
                {
                    myBody.AddForce(new Vector2(Dash_V, 0), ForceMode2D.Impulse);
                }

            }
            else
            {
                MyAnimator.SetBool("isDashing", false);
            }
        }
    }

    bool suelo()
    {
        return misPies.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void saltodoble()
    {


        if (suelo())
        {
            MyAnimator.SetBool("falling", true);
            Dash();

            if (Input.GetKeyDown(KeyCode.K))
            {
                myBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                MyAnimator.SetTrigger("jumping");
                contandoSaltos++;

                if(contandoSaltos > 1)
                {
                    contandoSaltos = 1;
                }
            }
            else
                MyAnimator.SetBool("falling", false);
        }

        if (Input.GetKeyDown(KeyCode.K) && contandoSaltos == saltosExtras && myBody.velocity.y < 0)
        {
            myBody.AddForce(new Vector2(0, jumpSpeed + Mathf.Abs(myBody.velocity.y)), ForceMode2D.Impulse);
            MyAnimator.SetTrigger("jumping");
            contandoSaltos = 0;
            Debug.Log("Salto doble");
        }
    
}

    

    public void correr()
    {
        float direccion = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));

        if (direccion != 0)
        {
            if (direccion < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                direccionImpulso = -1;
            }
            
            if(direccion > 0)
            { 
                transform.localScale = new Vector3(1, 1);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                direccionImpulso = 1;
            }
                
                

            MyAnimator.SetBool("isrunning", true);
        }
        else
            MyAnimator.SetBool("isrunning", false);

        transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));
    }

   
    }

    
   

