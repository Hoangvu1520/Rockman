using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float timeOffset;
    [SerializeField] Vector3 offset;

    [SerializeField] Vector3 boundariesMin;
    [SerializeField] Vector3 boundariesMax;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (player != null) 
        {
            Vector3 startPos = transform.position;
            Vector3 targetPos = player.position;

            targetPos.x += offset.x;
            targetPos.y += offset.y;
            targetPos.z += transform.position.z;

            targetPos.x = Mathf.Clamp(targetPos.x, boundariesMin.x, boundariesMax.x);
            targetPos.y = Mathf.Clamp(targetPos.y, boundariesMin.y, boundariesMax.y);

            float t = 1f - Mathf.Pow(1f - timeOffset, Time.deltaTime * 30);
            transform.position = Vector3.Lerp(startPos, targetPos, t);
        }
    }
}
