using UnityEngine;
using System.Collections;

public class PulseScaler : MonoBehaviour
{
    public float speed = 2;

    // Update is called once per frame
    void Update ()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * speed, Time.deltaTime * speed);
    }
}
