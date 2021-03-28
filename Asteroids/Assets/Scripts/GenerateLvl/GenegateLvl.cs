using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenegateLvl : MonoBehaviour
{
    public SkyScriptableObject SkyScriptableObject;
    public ShipScriptableObject ShipScriptableObject;

    private GameObject sky;
    private GameObject ship;

    void Start()
    {
        sky = SkyScriptableObject.sky;
        Instantiate(this.sky);

        ship = ShipScriptableObject.ship;
        Instantiate(this.ship);
    }
}
