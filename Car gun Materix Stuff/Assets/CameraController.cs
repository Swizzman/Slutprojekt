using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    int DistanceAway = 10;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Hittade denna kod som jag har modifierat lite som gör att kameran rör sig efter spelaren men roterar inte efter z-axeln
        Vector3 PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Denna kod sätter kamerans position till spelaren men roterar inte efter spelaren
        this.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z - DistanceAway);
        
    }
}
