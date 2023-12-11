using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]
    private float offset = 10f;

    [SerializeField]
    private float smoothTime = 1f;

    [SerializeField]
    private Player player;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 newVector = player.transform.position + new Vector3(0,offset,0);

        transform.position = Vector3.SmoothDamp(transform.position, newVector, ref velocity, smoothTime);
    }


}
