using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamara : MonoBehaviour
{
    public Transform Target;

    private void LateUpdate()
    {
        transform.position = new Vector3(Target.transform.position.x, Target.position.y, transform.position.z);
    }

}
