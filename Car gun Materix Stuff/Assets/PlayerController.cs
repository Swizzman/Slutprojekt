using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Characters
{
    //Denna Serialiseringen skulle vara väldigt ologisk i ett färdigt spel. Då skulle istället det finnas en publik lista av fiender som kan hämtas(Jag har en sådan lista men använder den inte då den inte är riktigt byggd)
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Gun testgun;

    [SerializeField]
    Slider ammoSlider;
    [SerializeField]
    Image hpImage;

    //De olika stadierna av hjärtbilderna Serializas här
    [SerializeField]
    Sprite heartStage2;
    [SerializeField]
    Sprite heartStage3;

    private int ammo = 1;
    private int hp = 100;
    private bool sliderShouldfill = false;
    private float sliderValue;
    //Instansierar kanonen
    public Gun Testgun
    {
        get
        {
            return testgun;
        }
        private set { testgun = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Använder denna kallelse för testsyfte
        sliderValue = 0f;



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
            ChangeLevel(1);
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
        if (hp <= 80)
        {
            hpImage.sprite = heartStage2;
        }
        else if (hp <= 30)
        {
            hpImage.sprite = heartStage3;
        }
        else if (hp <= 0)
        {
            hpImage.sprite = null;
        }
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
    //Denna metod ska byta mellan olika nivåer. I en optimal värld bör denna metod vara någon annanstans och kunna kallas av olika delar av spelet. Den bör då vara public 
    void ChangeLevel(int levelIndex)
    {
        try
        {
            SceneManager.LoadScene(levelIndex);

        }
        catch (System.IndexOutOfRangeException)
        {

            throw new System.Exception("That level doesn't exist");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
