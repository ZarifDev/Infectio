using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contadordemunicao : MonoBehaviour
{

    int Contador;
    int Current Ammo = 0;
    int maxAmmo = 10;
    // Start is called before the first frame update
    void Start()
    {
        Current Ammo = Current Ammo + 1;
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Tiros" );
       Contador = Current Ammo/Max Ammo;
    }
}
