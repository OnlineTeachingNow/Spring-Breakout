using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
          //  StartCoroutine(DistractEnemies());
        }
    }

    /*
    private IEnumerator DistractEnemies()
    {
        while(Time.deltaTime < enemyattacktime(fromscriptableobject))
    this.GetComponent<SpriteRenderer>().color.a = 0f;
    yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color.a = 1f;
    }

    */


    /*
     * 
     *The following was for trying to come up with a throwing animation thing
 private Vector3 _velocity;


 private void Start()
 {
   //  StartCoroutine(Throw());
 }
 private IEnumerator Throw()
 {
     while (Time.deltaTime < 2.0f)
     {
         UpdateVelocity();
         UpdatePosition();
         yield return new WaitForSeconds(0.1f);
     }
 }
 private void UpdateVelocity()
 {
     _velocity += Physics.gravity * Time.deltaTime;
 }

 private void UpdatePosition()
 {
     transform.position += _velocity * Time.deltaTime;
 }
 */
}
