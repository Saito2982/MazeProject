using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(Time.deltaTime, 0, 0);
    }
}
