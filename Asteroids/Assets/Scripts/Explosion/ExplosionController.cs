using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animation Animation;

    public void KillObject()
    {
        Destroy(this.gameObject);
    }
}
