using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Gun
{
     Vector3 mousePos;
    public GameObject cannon;
    float angle;
    Transform theParent;
    // Start is called before the first frame update
    void Start()
    {
        //Simplifierar koden genom att deklarera vad kanons parent är
        theParent = this.transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
    }
    public override void Shooting()
    {
        //Konverterar muspositionen till kordinater baserat på kameran

        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        //Denna if-sats skjuter iväg spelaren
      

            //mousePos.z = 10;
            Vector3 targetPos = mousePos;
            //Shoot da ball, Luke - Prince Dumbeldurr the grey
            theParent.parent.GetComponent<Rigidbody2D>().AddForce(targetPos * -1 * 60);

        
    }
    public override void Rotating()
    {
       

        //Hämtar muspositionen igen
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        //Konverterar kanonens lokala position till den globala positionen för världen
        Vector3 cannonPos = transform.TransformPoint(cannon.transform.position);
        Vector3 targetPos2 = Camera.main.ScreenToWorldPoint(mousePos);
        print(cannonPos);
        //Vector2 offset = new Vector2(targetPos2.x - theParent.transform.position.x, targetPos2.y - theParent.transform.position.y);
        //Av någon jävla anledning behövs Atan2 för att räkna ut rätt grader. Den tar i beaktning om graderna råker skapa division med 0
        Vector3 offset = mousePos - cannonPos;
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //print(mousePos);
        //Denna if-sats är inte färdig men ska sätta begränsningar
        if (theParent.transform.rotation.z < -90)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, -90);
            theParent.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (theParent.transform.rotation.z > 0)
        {
            //cannon.transform.parent.eulerAngles = new Vector3(0, 0, 0);
            theParent.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            theParent.eulerAngles = new Vector3(0, 0, angle);

        }
        
    }
}
