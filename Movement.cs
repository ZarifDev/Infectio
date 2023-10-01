using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float MaxSpeed = 5f;
    public float RotSpeed = 90f;

    float PlayerRadius = 0.5f;


    void Start () {
        
    }

    void Update ()  {

        // ROTAÇÂO

        Quaternion rot = transform.rotation;

        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;

        rot = Quaternion.Euler( 0, 0, z );

        transform.rotation = rot;


        // MOVIMENTAÇÂO
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        //LIMITE PLAYER A CAMERA

        if(pos.y+PlayerRadius > Camera.main.orthographicSize) {
            pos.y = Camera.main.orthographicSize - PlayerRadius;
         
        }
        if(pos.y-PlayerRadius < -Camera.main.orthographicSize) {
            pos.y = -Camera.main.orthographicSize + PlayerRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + PlayerRadius > widthOrtho)
        {
            pos.x = widthOrtho - PlayerRadius;

        }
        if (pos.x - PlayerRadius < -widthOrtho)  {
            pos.x = -widthOrtho + PlayerRadius;
        }

        transform.position = pos;



    }
}
