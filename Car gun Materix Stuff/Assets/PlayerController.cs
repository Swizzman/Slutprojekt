using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public GameObject testSpawn;
    //Instansierar kanonen

    [SerializeField]
    Gun testgun;

    public Gun Testgun
    {
        get
        {
            return testgun;
        }
        private set { testgun = value; }
    }

    Vector2 finalPos;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Hämtar RigidBody2D från spelarobjektet
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Denna if-sats skjuter iväg spelaren ifall musen trycks ned
        if (Input.GetMouseButtonDown(0))
        {
            testgun.Shooting();
        }
        //Denna metod kallas hela tiden för att 
        testgun.Rotating();

        
        



        

        //print(angle);

       

        //print(cannon.transform.parent.rotation.z);

    }
}
