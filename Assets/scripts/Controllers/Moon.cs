using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitspeed;
    public float orbitradius;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitradius, orbitspeed, planetTransform);
    }
    public float orbit = 0;
    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        float tempX = mathCos(orbit);
        float tempY = mathSin(orbit);
        Vector3 newpos = new Vector3(tempX, tempY) * radius + target.position;
        transform.position = newpos;

        orbit += speed * Time.deltaTime;
        if (orbit >= 360)
        {
            orbit = 0;
        }
    }
    public float mathCos(float angle)
    {
        float ra = Mathf.Cos(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
    public float mathSin(float angle)
    {
        float ra = Mathf.Sin(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
}
