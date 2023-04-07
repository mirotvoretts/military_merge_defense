using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensions 
{
    public static void LookAt2D(this Transform selfTransform, Transform target)
    {
        Vector3 difference = target.position - selfTransform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90;
        selfTransform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
}
