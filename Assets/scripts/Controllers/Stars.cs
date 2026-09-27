
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public int t;
    public Vector3 currentstar;
    public Vector3 nextstar;
    public int StarSet;
    public bool linecomplete;

    public Vector3 currentEnd;
    public float dist;
    // Update is called once per frame
    void Update()
    {
        if (StarSet == 0)
        {
            StartCoroutine(draw());
        }
    }
    IEnumerator draw()
    {
        for (int i = 0; i < starTransforms.Count - 1; i++)
        {
            currentstar = starTransforms[i].transform.position;
            nextstar = starTransforms[i + 1].transform.position;
            //currentEnd = currentstar;

            //linecomplete = false;
            //StartCoroutine(starlerp());
            //new WaitForSecondsRealtime(2f);
            Debug.DrawLine(currentstar, nextstar, Color.red, 2);

            StarSet += 1;
            yield return new WaitForSecondsRealtime(2f);
        }
        StarSet = 0;

        yield return null;
    }
    IEnumerator starlerp()
    {
        float progress = 0f;
        while (progress < 1f)
        {
            progress += 1 * Time.deltaTime;

            currentEnd = Vector3.Lerp(currentEnd, nextstar, progress);
            Debug.DrawLine(currentstar, currentEnd, Color.red, 2);
            
        }
        linecomplete = true;
        yield return new WaitForSecondsRealtime(0.1f);
    }


}


