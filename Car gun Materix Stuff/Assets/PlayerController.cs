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
    
    [SerializeField]
    Slider ammoSlider;
    int ammo = 1;
    int hp = 100;
    bool sliderShouldfill = false;
    float sliderValue;
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
        sliderValue = 0f;
        //Hämtar RigidBody2D från spelarobjektet.... Av någon anledning
        rb = GetComponent<Rigidbody2D>();
        ammoText.text = "Ammo: "  + ammo;
        hpText.text = hp + " HP";
        if (hp <= 10)
        {
            hpText.color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Denna if-sats skjuter iväg spelaren ifall musen trycks ned
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            testgun.Shooting();
            //Ändrar ammo-räknaren
            ammo--;
            ammoText.text = "Ammo: " + ammo;
            if (ammo < 10)
            {
                ammoText.color = Color.red;
                if (ammo <= 0)
                {
                    StartCoroutine(AmmoRecharger());
                    sliderShouldfill = true;
                   

                }
                

            }

        }
        if (sliderShouldfill)
        {
            ammoSlider.value = sliderValue;
            sliderValue += 0.05f;

        }
        //Denna metod kallas hela tiden för att rotera kannonen
        testgun.Rotating();
        //Förstör spelaren om hälsopoängen blir 0 eller mindre
        if (hp <= 0)
        {
            Destroy (this.gameObject);
        }
        if (ammoSlider.value == 1)
        {
            ammoSlider.value = 0;
            sliderShouldfill = false;
            sliderValue = 0;
        }

    }
    //Denna metod ska kallas om spelaren ska ta skada
    public override void Hurt(int damage)
    {
        //Subtraherar skadan från hälsan
        hp = hp - damage;
        hpText.text = hp + " HP";
    }
    //Denna kod ska recharga skotten
    IEnumerator AmmoRecharger()
    {
        yield return new WaitForSeconds(0.5f);
        ammo = 1;
        
        yield break;
    }

}
