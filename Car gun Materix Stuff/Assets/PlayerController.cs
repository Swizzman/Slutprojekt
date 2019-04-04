        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public GameObject testSpawn;
    Vector2 finalPos;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            //Konverterar muspositionen till kordinater baserat på kameran
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

            //GameObject test = Instantiate(testSpawn, targetPos, Quaternion.identity);

            rb.GetComponent<Rigidbody2D>().AddForce(targetPos * -1 * 30);
            
        }

        
        
    }
}
