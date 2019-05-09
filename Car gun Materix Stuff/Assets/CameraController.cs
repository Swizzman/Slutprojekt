using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    int DistanceAway = 10;

    public GameObject player;
    Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        //Simplifiering av kod för senare bruk
        playerPosition = player.transform.position;

        //Sätter begränsningar på kameran så att den inte går utanför bakgrunden...Funkar inte för tillfället
        if (playerPosition.x < 32 && playerPosition.x > -14.5 && playerPosition.y < 4.5 && playerPosition.y > -9)
        {
            //Hittade denna kod som jag har modifierat lite som gör att kameran rör sig efter spelaren men roterar inte
            Vector3 PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            //Denna kod sätter kamerans position till spelaren men roterar inte efter spelaren
            this.transform.position = new Vector3 (PlayerPos.x, PlayerPos.y, PlayerPos.z - DistanceAway);
        }

    }
}
