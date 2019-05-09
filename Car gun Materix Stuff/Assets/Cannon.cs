using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : Gun
{
     Vector3 mousePos;
    [SerializeField]
     GameObject cannon;
    float angle;
    Transform theParent;
    // Start is called before the first frame update
    void Start()
    {
        //Simplifierar koden genom att deklarera vad kanonens parent är
        theParent = this.transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Konverterar muspositionen till kordinater baserat på kameran - Kör endast WorldSpace och inte lokalt så detta beöver ändras senare
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
    }
    public override void Shooting()
    {

            //Konverterar muspositionen till en lokal position för att undvika en redig bugg
            Vector3 targetPos = Camera.main.transform.InverseTransformPoint(mousePos);
            //Shoot da ball, Luke - Prince Dumbeldurr the Grey
            theParent.parent.GetComponent<Rigidbody2D>().AddForce(targetPos * -1 * 150);

        
    }
    public override void Rotating()
    {

        //Hämtar muspositionen igen
        //Konverterar kanonens lokala position till den globala positionen för världen
        Vector3 cannonPos = transform.TransformPoint(cannon.transform.position);
        //Av någon jävla anledning behövs Atan2 för att räkna ut rätt grader. Den tar i beaktning om graderna råkar skapa division med 0
        Vector3 offset = mousePos - cannonPos;
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
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
