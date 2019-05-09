using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Characters
{
    public Text ammoText;
    public Text hpText;
    public GameObject player;
    public GameObject testSpawn;
    //Instansierar kanonen
    [SerializeField]
    Gun testgun;
    int ammo = 10;
    int hp = 100;

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
        //Hämtar RigidBody2D från spelarobjektet.... Av någon anledning
        rb = GetComponent<Rigidbody2D>();
        ammoText.text = "Ammo: "  + ammo;
        hpText.text = hp + " HP";

    }

    // Update is called once per frame
    void Update()
    {
        //Denna if-sats skjuter iväg spelaren ifall musen trycks ned
        if (Input.GetMouseButtonDown(0))
        {
            testgun.Shooting();
            //Ändrar ammo-räknaren
            ammo--;
            ammoText.text = "Ammo: " + ammo;

        }
        //Denna metod kallas hela tiden för att rotera kannonen
        testgun.Rotating();
        //Förstör spelaren om hälsopoängen blir 0 eller mindre
        if (hp <= 0)
        {
            Destroy (this.gameObject);
        }

    }
    //Denna metod ska kallas om spelaren ska ta skada
   /* public override void Hurt(int damage)
    {
        //Subtraherar skadan från hälsan
        hp = hp - damage;

    }*/
}
