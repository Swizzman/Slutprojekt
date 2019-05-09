using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Canoneer : Characters
{
    //En delegate är ett sätt att lagra metoder som variabler utefter en mall. I detta fall ska metoder som ska kunna lagras i 'Action' ha en parameter som är ett GameObject
    delegate void Action(GameObject g);
    private bool leaveState = true;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject retreatObject;
    Queue<Action> Objectives = new Queue<Action>();
    Queue<string> ObjectiveNames = new Queue<string>();
    private int hp = 100;

    Action currentAction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Objectives.Enqueue(null);
        /*Action g = Approach;
 
        g(this.gameObject);
        */
        //Denna Coroutine används för att kunna använda WaitForSeconds och göra delays
        StartCoroutine(WaitSetActions());
        if (leaveState)
        {
            StartCoroutine(WaitTriggerAction());
            leaveState = false;
        }

        
        
        /*
        if (currentAction == Retreat)
        {
            currentAction(retreatObject);
        }
        else if (currentAction != null)
        {
            currentAction(player);
        }*/



    }
    //Denna metod ska hantera delays och se till att saker händer
    IEnumerator WaitTriggerAction()
    {
        //Denna sak väntar 3 sekunder och kör sedan saker under kodraden
        yield return new WaitForSeconds(3);
        /*if (currentAction == null)
        {
            currentAction = Objectives.Dequeue();
            print(currentAction);
            print(Objectives.Peek());
        }
        */

        //Action nextAction = Objectives.Dequeue();

        print("3 second wait done");
        yield return new WaitForSeconds(1);


        //nextAction(player);
        leaveState = true;
        yield break;



    }
    //Temporär kod
    IEnumerator WaitSetActions()
    {
        yield return new WaitForSeconds(1);
        if (ObjectiveNames.Peek() == "Approach")
        {
            Objectives.Enqueue(Shoot);
            ObjectiveNames.Enqueue("Shoot");

        }
        else if (hp < 30)
        {
            Objectives.Enqueue(Approach);
            ObjectiveNames.Enqueue("Approach");

        }
        else
        {
            Objectives.Enqueue(Retreat);
            ObjectiveNames.Enqueue("Retreat");
        }
        yield break;

    }
    //Denna metod ska få fienden att röra sig mot spelaren (Det funkar egentligen med vilka mål som helst så kan återanvända den)
    protected override void Approach(GameObject target)
    {
        currentAction = Approach;
        this.transform.position = Vector3.Lerp(transform.position, target.transform.position, 5f * Time.deltaTime);

    }
    //Denna metod skadar spelaren
    protected override void Shoot(GameObject target)
    {
        currentAction = Shoot;
        if (target.tag == "Player")
        {
            target.GetComponent<PlayerController>().Hurt(10);
        }
    }
    //Denna metod ska få fienden att retirera.. inte riktigt färdigt
    protected override void Retreat(GameObject objectPosition)
    {
        currentAction = Retreat;
        this.transform.position = Vector3.Lerp(transform.position, objectPosition.transform.position, 5f * Time.deltaTime);

    }
}
