using System.Collections.Generic;
using UnityEngine;

public class zoos : MonoBehaviour
{
    public List<string> animals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("cat");
        animals.Add("dog");
        animals.Add("chicken");
        animals.Add("kitten");
        animals.Add("cow");
        animals.Remove("chicken");
    }

    // Update is called once per frame
    void Update()
    {

        if (animals != null)
        {
            foreach (string animal in animals)
            {
                Debug.Log(animal);
            }
            //animals.RemoveAt(0);
        }
    }
}
