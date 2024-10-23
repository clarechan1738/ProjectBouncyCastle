using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float moveDuration = 1;
    public Vector3 target = new Vector3(0, -10.01f, 22.5f);

    public float countdown = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime * 1f;
        }
        else
        {
            StartCoroutine(MoveBlackHole(target));
        }
    }

    IEnumerator MoveBlackHole(Vector3 targetPosition)
    {
        Vector3 startPosition = this.gameObject.transform.position;
        float timeElapsed = 0;

        while (timeElapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

    }
}
