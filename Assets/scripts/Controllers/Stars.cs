
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public int t;
    Vector3 currentstar;
    Vector3 nextstar;
    public int StarSet;

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
            Debug.DrawLine(currentstar, nextstar, Color.red,2);
            StarSet += 1;
            yield return new WaitForSecondsRealtime(1.5f);
        }
        StarSet = 0;

        yield return null;
    }
}
