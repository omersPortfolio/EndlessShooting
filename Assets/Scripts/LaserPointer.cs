using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private LineRenderer lr;

    public float laserLength;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 endPosition = transform.position + (transform.right * laserLength);
        endPosition.y = endPosition.y - .5f;
        lr.SetPositions(new Vector3[] { transform.position, endPosition });

        //RaycastHit2D hit = Physics2D.Raycast(this.transform.position, endPosition, laserLength);

        ////if (hit.collider != null)
        ////{
        ////    if (hit.collider.tag == "Enemy")
        ////        lr.SetPositions(new Vector3[] { transform.position, hit.point });
        ////}
    }
}
