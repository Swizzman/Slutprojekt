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

        testgun.shooting();


        //GameObject theParent = Testgun.gameObject.transform.parent;
        //mousePos.z = 10;
        
        



        

        //print(angle);

        if (testgun.cannon.transform.parent.transform.rotation.z < -90)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, -90);
            testgun.cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (testgun.cannon.transform.parent.transform.rotation.z > 0)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, 0);
            testgun.cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            testgun.cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);

        }

        //print(cannon.transform.parent.rotation.z);

    }
}
