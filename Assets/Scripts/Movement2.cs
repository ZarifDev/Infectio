using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    public float PlayerSpeed = 5f;
    public float RotSpeed = 90f;
    public float PlayerRadius = 0.5f;
    public float speedMultiplier = 1f; 

    void Start()
    {

    }

    void Update()
    {

        // MOVIMENTAÇÃO
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * PlayerSpeed * speedMultiplier * Time.deltaTime;
        pos += velocity;

        //LIMITE PLAYER A CAMERA

        if (pos.y + PlayerRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - PlayerRadius;
        }
        if (pos.y - PlayerRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + PlayerRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + PlayerRadius > widthOrtho)
        {
            pos.x = widthOrtho - PlayerRadius;
        }
        if (pos.x - PlayerRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + PlayerRadius;
        }

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("speedMod"))
        {
            speedMultiplier = 5f; // Multiplicador de velocidade. Coloquei "5" como exemplo. Podemos ajustar depois.
            Destroy(other.gameObject);
        }
    }
}