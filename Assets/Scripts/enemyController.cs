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
        gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), GoalDestination, speed * Time.deltaTime);
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
