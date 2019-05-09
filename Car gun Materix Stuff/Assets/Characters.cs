using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Approach(GameObject target)
    {

    }

    protected virtual void Retreat(GameObject position)
    {

    }
    protected virtual void Shoot(GameObject target)
    {

    }
    public virtual void Hurt(int damage)
    {

    }
}
