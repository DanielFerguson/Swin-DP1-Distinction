using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 1f;

    private void Update()
    {
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
    }
}
