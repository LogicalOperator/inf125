using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    private float directionChangeInterval = 1f;
    private float maxHeadingChange = 30f;

    Vector3 targetRotation;
    float heading;

    void Start()
    {
        maxHP = 30f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 0.5f;
        speed = 2f;
        level = PlayerPrefs.GetInt("level", 1);
        heading = Random.Range(0, 360);
        //transform.eulerAngles = new Vector3(0, heading, 0);
        //StartCoroutine(NewHeading());
    }

    void Update()
    {
        // movement(); //use default enemy movement
        //transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
        //var forward = transform.TransformDirection(Vector3.forward);
        //gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), forward, speed * Time.deltaTime);
        //float randomX = (Random.Range(0,1) - 0.5f) * speed;
        //float randomZ = (Random.Range(0,1) - 0.5f) * speed;
        //Vector3 cool = new Vector3(randomX, 0, randomZ);
        //Vector2 testCool = new Vector2(randomX, randomZ);
        float headOne = Random.Range(0, 360);
        float headTwo = Random.Range(0, 360);
        Vector2 direction = new Vector2((float)Mathf.Cos(headOne), (float)Mathf.Sin(headTwo));
        gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), direction, speed * Time.deltaTime);
        //gameObject.transform.position = Vector3.Lerp(transform.position, transform.position + cool, Time.time);
    }

    IEnumerator NewHeading()
    {
        while(true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }
}
