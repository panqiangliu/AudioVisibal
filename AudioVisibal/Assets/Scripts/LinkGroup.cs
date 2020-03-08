using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGroup : MonoBehaviour
{
    public Transform link01;
    public Transform link02;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    //设置转向，可视化指向圆心
    private void Start()
    {
        if (transform.position.x > 0)
        {
            Debug.Log("transform.position.y" + transform.position.y);
            Debug.Log("transform.position.x" + transform.position.x);

            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Asin(transform.position.y / Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) )* Mathf.Rad2Deg - 45);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Asin(-transform.position.y / Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) )* Mathf.Rad2Deg + 135);
        }
    }

    public void Update()
    {
        lineRenderer.SetPosition(0, link01.position);
        lineRenderer.SetPosition(1, link02.position);
    }

}
