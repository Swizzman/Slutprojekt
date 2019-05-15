using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Characters
{
    
    public GameObject player;
    public GameObject testSpawn;
    //Instansierar kanonen
    [SerializeField]
    Gun testgun;

    [SerializeField]
    Slider ammoSlider;
    [SerializeField]
    LoadSceneMode test;
    
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
            if (ammo <= 0)
            {
                StartCoroutine(AmmoRecharger());
                sliderShouldfill = true;


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
            ChangeLevel();
            Destroy(this.gameObject);
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
    }
    //Denna kod ska recharga skotten
    //Yield gör att koden kan komma ihåg vart någonstans i metoden den var. Om man exempelvis kallar på en IEnumerator med en foreach-loop kan den returnera olika saker med samma metod
    /*
     Exempel:
     foreach (var i in Number)
     {
     Console.WriteLine(i)
     }
     IEnumerable Number()
     {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
     }
     Detta kommer nu returnera olika saker varje gång. Så först returneras 1 och sedan 2 och sedan 3 o.s.v.
         
         
         
         */
    IEnumerator AmmoRecharger()
    {
        yield return new WaitForSeconds(0.5f);
        ammo = 1;

        yield break;
    }
    void ChangeLevel()
    {
         SceneManager.LoadScene(1);
    }

}
