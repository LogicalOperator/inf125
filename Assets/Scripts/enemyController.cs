using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    private float directionChangeInterval = 5f;
    private float maxHeadingChange = 5f;
    Vector3 GoalDestination;

    Vector3 targetRotation;
    float heading;

    void Start()
    {
        maxHP = 30f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 0.5f;
        speed = 2f;
        level = PlayerPrefs.GetInt("level", 1);
        GoalDestination = Random.insideUnitCircle * 5;
        StartCoroutine(NewHeading());
    }

    void Update()
    {
        // LookAt 2D
        // get the angle
        Vector3 norTar = (GoalDestination - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
        gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), GoalDestination, speed * Time.deltaTime);
        sendRaycast();
        //if (wander == true)
        //{
        //    Debug.Log("havent found yet");
        //    gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), GoalDestination, speed * Time.deltaTime);
        //}
        //else
        //{
        //    Debug.Log("found");
        //    movement();
        //}

    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            GoalDestination = NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    public Vector3 NewHeadingRoutine()
    {
        return Random.insideUnitCircle * 5;
    }

}
