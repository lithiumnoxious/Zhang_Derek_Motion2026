
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

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < starTransforms.Count - 1; i++)
        {
            currentstar = starTransforms[i].transform.position;
            nextstar = starTransforms[i + 1].transform.position;

            
            StartCoroutine(draw());
        }
    }
    IEnumerator draw()
    {
        


        //Debug.DrawLine(currentstar, starmag, Color.red, 10);
        yield return new WaitForEndOfFrame();
    }
}
