﻿using System.Collections;
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
    Vector3 currentPlayerPosition;
    Action currentAction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leaveState)
        {
            StartCoroutine(WaitTriggerAction());
            leaveState = false;

        }

        if (currentAction == Approach)
        {
            Moving(currentPlayerPosition);
        }
        else if (currentAction == Retreat)
        {
            Moving(retreatObject.transform.position);
        }



    }
    //Denna metod ska hantera delays och se till att saker händer
    IEnumerator WaitTriggerAction()
    {
        //Denna sak väntar 3 sekunder och kör sedan saker under kodraden
        yield return new WaitForSeconds(3);
        if (currentAction == null)
        {
            //currentAction = Objectives.Dequeue();
            //print(Objectives.Peek().ToString());
        }
        if (Random.Range(0, 3) == 1)
        {
            Objectives.Enqueue(Approach);

        }
        else if (Random.Range(0, 3) == 2)
        {
            Objectives.Enqueue(Retreat);
        }
        else
        {
            Objectives.Enqueue(Approach);
        }
        Action nextAction = Objectives.Dequeue();

        print("3 second wait done");

        if (nextAction == Approach && currentAction != Shoot)
        {

            currentAction = Approach;
            nextAction(player);
            currentPlayerPosition = player.transform.position;
            Objectives.Enqueue(Shoot);

        }
        else if (nextAction == Retreat)
        {
            currentAction = Retreat;
            nextAction(retreatObject);
        }
        else if (nextAction == Shoot)
        {
            currentAction = Shoot;
            nextAction(player);

        }
        leaveState = true;
        yield break;



    }
    //Temporär kod

    //Denna metod ska få fienden att röra sig mot spelaren (Det funkar egentligen med vilka mål som helst så kan återanvända den)
    protected override void Approach(GameObject target)
    {

        this.transform.position = Vector3.Lerp(transform.position, target.transform.position, 5f);

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

    protected override void Retreat(GameObject objectPosition)
    {

        this.transform.position = Vector3.Lerp(transform.position, objectPosition.transform.position, 5f);

    }
    private void Moving(Vector3 Position)
    {

        transform.position = Vector3.Lerp(transform.position, Position, 2 * Time.deltaTime);


    }
}
