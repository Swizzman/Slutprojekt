using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Gun
{
    public Vector3 mousePos;
    public GameObject cannon;
    float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public override void shooting()
    {
        //Konverterar muspositionen till kordinater baserat på kameran

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        //Denna if-sats skjuter iväg spelaren
        if (Input.GetMouseButtonDown(0))
        {

            mousePos.z = 10;
            Vector3 targetPos = mousePos;
            //Shoot da ball, Luke - Prince Dumbeldurr the grey
            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(targetPos * -1 * 60);

        }
    }
    public override void rotating()
    {
        Vector3 cannonPos = cannon.transform.parent.transform.position;
        Vector3 targetPos2 = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 offset = new Vector2(targetPos2.x - cannon.transform.parent.transform.position.x, targetPos2.y - cannon.transform.parent.transform.position.y);
        //Av någon jävla anledning behövs Atan2 för att räkna ut rätt grader. Den tar i beaktning om graderna råker skapa division med 0

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        offset = mousePos - cannonPos;
    }
}
