using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        int a = 5;
        int b = 10;

        a = a + b;
        b = a - b;
        a = a - b;
        Debug.Log($"a = {a} and b = {b}");
    }
    
}
