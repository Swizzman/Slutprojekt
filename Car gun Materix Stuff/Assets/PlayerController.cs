using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public GameObject testSpawn;
    public GameObject cannon;

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

        //Konverterar muspositionen till kordinater baserat på kameran
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            

            mousePos.z = 10;
            Vector3 targetPos = mousePos;
            //GameObject test = Instantiate(testSpawn, targetPos, Quaternion.identity);

            rb.GetComponent<Rigidbody2D>().AddForce(targetPos * -1 * 30);
            
        }

        //mousePos.z = 10;
        //Vector3 targetPos2 = Camera.main.ScreenToWorldPoint(mousePos2);
        //Vector2 offset = new Vector2(targetPos2.x - cannon.transform.parent.transform.position.x, targetPos2.y - cannon.transform.parent.transform.position.y);

        Vector3 cannonPos = cannon.transform.parent.transform.position;
        Vector3 offset = mousePos - cannonPos;


        //Av någon jävla anledning behövs Atan 2 för att räkna ut rätt
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        print(angle);

        if (cannon.transform.parent.transform.rotation.z < -90)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, -90);
            cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (cannon.transform.parent.transform.rotation.z > 0)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, 0);
            cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            cannon.transform.parent.eulerAngles = new Vector3(0, 0, angle);

        }

        //print(cannon.transform.parent.rotation.z);

    }
}
