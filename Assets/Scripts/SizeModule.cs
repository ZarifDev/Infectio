using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModule : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sizeMod")
        {
            this.transform.localScale *= 0.75f;
            Destroy(other.gameObject);
        }

    }

   // Start is called before the first frame update

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}