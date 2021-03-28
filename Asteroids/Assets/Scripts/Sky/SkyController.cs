using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public SkyScriptableObject SkyScriptableObject;

    private GameObject sky;
    private void Start()
    {
        sky = SkyScriptableObject.sky;
        Instantiate(this.sky);
    }

}
