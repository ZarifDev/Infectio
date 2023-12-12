using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5;
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.left,  Player.instance.transform.position - transform.position);
        transform.Translate(Vector3.left * Time.deltaTime*(speed)); 
    }
}
