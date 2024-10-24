using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTopLerp : MonoBehaviour
{
    public float time = 0;
    const int SPEED = 50;
    public Transform target2;
    public Transform target1;
    public float Delay;
    public Vector3 target = new Vector3(-62.9f, -21.3f, -2.5f);
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpikeLerp(target));
    }

    // Update is called once per frame
    IEnumerator SpikeLerp(Vector3 targetPosition)
    {
        //transform.Translate(new Vector3(-62.9f, 18.5f, 33f));
        float timeElapsed = 0;
        Delay = 0;
        transform.position = target1.position;
        while (Delay < 10)
        {
            Delay += Time.deltaTime;
        }

        while (timeElapsed < 100)
        {
            transform.position = Vector3.MoveTowards(target1.position, target2.position, timeElapsed);
            timeElapsed += Time.deltaTime * SPEED;
            yield return null;
        }
        StartCoroutine(SpikeLerp(target));
    }
}