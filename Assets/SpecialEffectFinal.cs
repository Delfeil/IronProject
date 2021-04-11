using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectFinal : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, 7f * Time.deltaTime), Space.World);
    }
}
