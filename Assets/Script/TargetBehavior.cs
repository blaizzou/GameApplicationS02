using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private int score = 0;
    private GameObject target;
    private float size = 1;
    private Vector3 position = new Vector3(0, 0, 0);
    private Transform targetSpawn;
    private Vector3 originPosition = new Vector3(0, 0, 0);

    public Transform targetOrigin;
    public GameObject Target;
    void Start()
    {
        targetSpawn = targetOrigin;
        originPosition = targetOrigin.position;
    }

    public void ReCreateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        Destroy(target);

        size *= 0.9f;
        position.x = Random.Range(-1.5f, 1.5f);
        position.z = Random.Range(-1f, 1f);
        position.y = Random.Range(-1f, 1f);
        targetSpawn.position = originPosition + position;

        GameObject newTarget = Instantiate(Target, targetSpawn.position, targetSpawn.rotation);
        newTarget.transform.localScale *= size;

    }
}
