using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float PlayerSpeed = 5f;
    public float RotSpeed = 90f;

    float PlayerRadius = 0.5f;


    void Start () {
        
    }

    void Update ()  {

        // ROTA��O

        // MOVIMENTA��O
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * PlayerSpeed * Time.deltaTime;


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
