using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    enum Movements
    {

        left,//Movimiento de la Serpiente a la Izquierda

        right,//Movimiento de la Serpiente a la Derecha

        up,//Movimiento de la Serpiente a Arriba

        down//Movimiento de la Serpiente a Abajo 

    }

   

    Movements _movement;

   
    public float _frameRate = 0.2f;

   
    public float _nextStep = 0.16f;

    public  Vector2 horizontalRange;
    public  Vector2 verticalRange;


   
    Vector3 _lastPos;



    void Start()

    {

        InvokeRepeating("Move", _frameRate, _frameRate);

    }

    void Move()
    {

        _lastPos = transform.position;

        Vector3 nextPos = Vector3.zero;

        if (_movement == Movements.up)
        {

            nextPos = Vector3.up;

        }
        else if (_movement == Movements.down)
        {

            nextPos = Vector3.down;

        }
        else if (_movement == Movements.left)
        {

            nextPos = Vector3.left;

        }
        else if (_movement == Movements.right)
        {

            nextPos = Vector3.right;

        }

        nextPos *= _nextStep;

        transform.position += nextPos;

    }


    void Update()

    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _movement = Movements.up;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _movement = Movements.down;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _movement = Movements.left;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _movement = Movements.right;

        }

    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Borders"))
        {
            print("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else if (col.CompareTag("Apple"))
        {
            print("Has Comido");

            col.transform.position = new Vector2(Random.Range(horizontalRange.x, horizontalRange.y), Random.Range(verticalRange.x, verticalRange.y));
        }
    }

}
