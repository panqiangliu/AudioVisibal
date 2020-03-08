using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisableGroup : MonoBehaviour
{
    public Transform link01;
    public Transform link02;

    public int groupIndex;
    private float mult =40 ;

    private void LateUpdate()
    {
        int index = 511 / groupIndex;
        Vector3 link01pos = link01.localPosition;
        Vector3 link02pos = link02.localPosition;
        //Debug.Log(index);
        link01.localPosition = Vector3.Lerp(link01pos, new Vector3(AuidioVisable.Instance.sample[index] * mult, AuidioVisable.Instance.sample[index] * mult, 0), 0.1f);
        link02.localPosition = Vector3.Lerp(link02pos, new Vector3(-(AuidioVisable.Instance.sample[index] * mult), -(AuidioVisable.Instance.sample[index] * mult), 0), 0.1f);

    }

}
