using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDeCanon2 : MonoBehaviour
{
    [SerializeField] float speed;

    BoxCollider2D impacto;
    // Start is called before the first frame update
    void Start()
    {
        impacto = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, 1) * speed * Time.deltaTime);
        Destroy(this.gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //Recomiendo que tengas las colisiones entre los enemigos desactivadas para que no se borre al instante.
    }
}
