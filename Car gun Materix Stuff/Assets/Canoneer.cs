using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Canoneer : EnemyController
{
    //En delegate är ett sätt att lagra metoder som variabler utefter en mall. I detta fall ska metoder som ska kunna lagras i 'Action' ha en parameter som är ett GameObject.
    delegate void Action(GameObject g);
    private bool leaveState = true;
    private bool shouldShoot;
    private bool shouldRetreat;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject retreatObject;
    Queue<Action> Objectives = new Queue<Action>();
    private int hp = 100;
    private Vector3 currentPlayerPosition;
    private Action currentAction;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Denna loop skall köras hela tiden så länge som fienden har hp
        print(hp);
        //Denna if-sats startas ifall leavestate är sann vilket gör så att Coroutinenen inte körs hela tiden.
        if (leaveState)
        {
            StartCoroutine(WaitTriggerAction());
            leaveState = false;

        }

        //Dessa if-satser kallas och kallar på Moving men ändrar vad som skickas beroende på vad CurrentAction är
        if (currentAction == Approach)
        {
            Moving(currentPlayerPosition);
        }
        else if (currentAction == Retreat)
        {
            Moving(retreatObject.transform.position);
            shouldRetreat = false;
        }

        if (hp <= 0)
        {
            for (int i = 0; i < Objectives.Count; )
            {
                Objectives.Dequeue();
            }
            Destroy(this);

        }

    }
    //Denna metod ska hantera delays och se till att saker händer
    IEnumerator WaitTriggerAction()
    {
        //Denna sak väntar 3 sekunder och kör sedan saker under kodraden
        yield return new WaitForSeconds(3);
        if (hp > 50)
        {
            if (shouldShoot)
            {
                Objectives.Enqueue(Shoot);
                shouldShoot = false;

            }
            else
            {
                Objectives.Enqueue(Approach);
                shouldShoot = true;
            }

        }
        else
        {
            //Denna for-loop ska agera som en en liten bomb som sprängs och skadar alla fiender. I nuläget finns det bara en fiende men hoppas du ser att jag har lagt en loop i en if-sats
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].GetComponent<Canoneer>().Hurt(20);
            }
            Objectives.Clear();
            Objectives.Enqueue(Retreat);
            while (hp < 50)
            {
                Heal(40);
            }
            shouldShoot = false;

        }

        Action nextAction = Objectives.Dequeue();
        try
        {
            print("3 second wait done");
            if (nextAction == Approach)
            {

                currentAction = Approach;
                nextAction(player);
                currentPlayerPosition = player.transform.position;
                Objectives.Enqueue(Shoot);

            }
            else if (nextAction == Shoot)
            {
                currentAction = Shoot;
                nextAction(player);

            }
            else
            {
                nextAction(retreatObject);
                shouldRetreat = true;
            }
        }
       catch
        {

            throw new System.Exception("Something went wrong");
        }
        


        leaveState = true;
        yield break;



    }

    //Denna metod ska få fienden att röra sig mot spelaren (Det funkar egentligen med vilka mål som helst så kan återanvända den)
    protected override void Approach(GameObject target)
    {

        this.transform.position = Vector3.Lerp(transform.position, target.transform.position, 5f * Time.deltaTime);

    }
    //Denna metod skadar spelaren
    protected override void Shoot(GameObject target)
    {
        if (target.tag == "Player")
        {
            //Genom att hämta sin egna komponent kan jag skada spelaren
            target.GetComponent<PlayerController>().Hurt(10);
        }
    }
    //Denna metod ska få fienden att retirera till en specifik punkt
    //Metoderna "Approach" och "Retreat" är i nuläget inte aktiva utan "Moving" används istället. Har kvar de gamla ifall jag vill använda de samt kunna visa att jag förstår delegates.

    protected override void Retreat(GameObject objectPosition)
    {

        this.transform.position = Vector3.Lerp(transform.position, objectPosition.transform.position, 5f * Time.deltaTime);

    }
    //Denna metod ska användas för att flytta fienden till en punkt. Det kan antingen vara spelaren eller reträttpunkten
    private void Moving(Vector3 Position)
    {

        transform.position = Vector3.Lerp(transform.position, Position, 1f * Time.deltaTime);


    }
    public override void Hurt(int damage)
    {
        hp = hp - damage;
        //Ska byta färg på objektet 
        if (hp < 80)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (hp < 70)
        {
            this.GetComponent<Renderer>().material.color = Color.yellow;

        }
        //När fienden tar skada kommer den omedelbart försöka fly
    }
    private void Heal(int amount)
    {
        hp = hp + amount;
    }

}
