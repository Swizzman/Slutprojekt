using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Characters
{
    //Detta skript ska hantera alla fiender men just nu är det inte så mycket logik
    [SerializeField]
    GameObject enemyObject;
    [SerializeField]
    GameObject spawner;
    protected List<GameObject> Enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
        Enemies.Add(Instantiate(enemyObject, spawner.transform.position, Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
