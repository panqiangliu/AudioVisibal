//作者：刘攀强
//时间：2020.03.08
//名字：ProgramCreatShape.cs
//作用：将group组成一个圆

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramCreatShape : MonoBehaviour
{
    public GameObject pointPrefab;
    //生成的点的数量
    [Range(10, 100)]
    public int groupNum = 30;
    //外圈的特效linerender
    public LineRenderer line2;
    private LineRenderer line;

    Transform[] points;

    //生成新的group
    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        float step = 10f / groupNum;
        Vector3 scale = Vector3.one * step;

        points = new Transform[groupNum];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab).transform;
            point.name="Point" + i;
            point.localScale = scale;
            point.SetParent(this.transform, false);
            points[i] = point;
        }
    }


//设置每个group的位置
    private void Start()
    {
        int group = 1;
        float t = Time.time;

        float step = 2.0f / groupNum;

        for (int i = 0; i < groupNum; i++)
        {
            float u = (i + 0.5f) * step - 1.0f;
            points[i].localPosition = Cylinder(u);
            points[i].GetComponent<VisableGroup>().groupIndex = group;
            group++;
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < groupNum; i++)
        {
            line.SetPosition(i, points[i].GetComponent<VisableGroup>().link01.position);
        }
        line.SetPosition(groupNum, points[0].GetComponent<VisableGroup>().link01.position);
        for (int i = 0; i < groupNum; i++)
        {
            line2.SetPosition(i, points[i].GetComponent<VisableGroup>().link02.position);
        }
        line2.SetPosition(groupNum, points[0].GetComponent<VisableGroup>().link02.position);
    }

    const float p1 = Mathf.PI;

    static Vector3 Cylinder(float u)
    {
        Vector3 p;
        p.x = Mathf.Sin(p1 * u);
        p.y = Mathf.Cos(p1 * u);
        p.z = 0;
        return p;
    }
}
