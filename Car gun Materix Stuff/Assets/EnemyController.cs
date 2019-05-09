using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject canonEnemy;
    List<GameObject> Enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Enemies.Add(Instantiate(canonEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
