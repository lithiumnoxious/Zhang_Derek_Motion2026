using UnityEngine;

public class dotprodtest : MonoBehaviour
{
    public float redangle;
    public float blueangle;

    public Transform targettransform;
    public bool left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 redvec = new Vector3(Mathf.Cos(redangle * Mathf.Rad2Deg), Mathf.Sin(redangle * Mathf.Rad2Deg)) ;
        Vector3 bluevec = new Vector3(Mathf.Cos(blueangle * Mathf.Rad2Deg), Mathf.Sin(blueangle * Mathf.Rad2Deg));
        //Vector3 bluevec2 = new Vector3(Mathf.Cos(blueangle), Mathf.Sin(blueangle)) * Mathf.Rad2Deg;
        Debug.DrawLine(transform.position, redvec, Color.red);
        Debug.DrawLine(transform.position, bluevec, Color.blue);
        //Debug.Log(VectorDot(redvec, bluevec));



        //Debug.DrawLine(transform.position, transform.position + transform.up, Color.cyan);

        Vector3 directiontotarget = targettransform.position - transform.position;// 
        //Debug.DrawLine(transform.position, directiontotarget - transform.position, Color.pink);

        float yesno = VectorDot(directiontotarget, -transform.right);
        if(yesno > 0)
        {
            left = true;
        }
        else
        {
            left =false;
        }


        if (left)
        {
            transform.eulerAngles += Vector3.forward*Time.deltaTime * 30; 
        }
        else
        {
            transform.eulerAngles -= Vector3.forward*Time.deltaTime * 30;

        }
    }
    public static float VectorDot(Vector3 v1, Vector3 v2)
    {
        float dotProduct = v1.x * v2.x + v1.y * v2.y;

        return dotProduct;
    }


}
