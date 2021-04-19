using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    SpriteRenderer _thisSprite;
    [SerializeField] int _objectValue = 100;
    MenuManager _menuManager;
    float _distractionTime;
    List<EnemyMovement> _enemiesInCollision = new List<EnemyMovement>();
    EnemyMovement _enemy;
    private void Start()
    {
        _menuManager = FindObjectOfType<MenuManager>();
        _menuManager.DetractPoints(_objectValue);
        _thisSprite = GetComponent<SpriteRenderer>();
        //Debug.Log(_distractionTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            _enemy = other.GetComponent<EnemyMovement>();
            _enemiesInCollision.Add(_enemy);
            _enemy.SetMoveSpeed(0.0f);
            StartCoroutine(DistractEnemies());
        }
    }
    
    private IEnumerator DistractEnemies()
    {
        float timePassed = 0;
        while (timePassed < _distractionTime)
        {
            var currentTime = Time.time;
            _thisSprite.enabled = false;
            yield return new WaitForSeconds(0.3f);
            _thisSprite.enabled = true;
            yield return new WaitForSeconds(0.3f);
            timePassed += Time.time - currentTime;
            //Debug.Log("Time Passed: " + timePassed);
        }
        foreach(var enemy in _enemiesInCollision)
        {
            enemy.SetMoveSpeed(5.0f);
        }
        Destroy(this.gameObject);
    }

    public void SetDistractionTime(float distractionTime)
    {
        _distractionTime = distractionTime;
    }

    public int GetObjectValue()
    {
        return _objectValue;
    }
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
