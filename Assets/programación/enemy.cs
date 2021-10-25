using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector2.Distance(transform.position, player.transform.position));

        if(Physics2D.OverlapCircle(transform.position, 7, LayerMask.GetMask("personaje")) != null)
        {
            Debug.Log("Esta chocando");
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(transform.position, 7);

    }
}
