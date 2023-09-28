using UnityEngine;
using System.Collections;
using System.Threading;


public class CannonProjectile : MonoBehaviour
{
    public float speed; 


    public int damagePerSecond = 20; 

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

   

   
}
