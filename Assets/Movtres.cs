using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movtres : MonoBehaviour
{
    //private new Rigidbody rigidbody;
    public Transform barquito;
    public float velocidad = 0.0f, x = 0.0f, z = 0.0f, h = 0.1f, angle = 45f;
   
    // Start is called before the first frame update
    void Start()
    {
        barquito.transform.position = new Vector3(x, 0f, z);
    }

    float movimientoobj(float posicion, float prueba)
    {
        posicion = posicion + (h * velocidad * prueba);
        return posicion;
    }

    // Update is called once per frame
    void Update()
    {
        if (x > 15f)
        {
            x = -15f;
        }
        x = movimientoobj(x, 1);
        barquito.transform.position = new Vector3(x, 0f, z);

        if (Input.GetKey(KeyCode.A))
        {
            //barquito.transform.Rotate(0, angle,0);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotacion();

            //x = movimientoobj(x, 1);
            //z = movimientoobj(z, 1);
            //barquito.transform.position = new Vector3(x, 0f, z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotacion();
            //x = movimientoobj(x, -1);
            //barquito.transform.position = new Vector3(x, 0f, z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocidad = velocidad + 0.0125f;
            if (velocidad > 5f)
            {
                velocidad = 5f;
            }
            print("velocidad " + velocidad);
            //z = movimientoobj(z,1);
            //barquito.transform.position = new Vector3(x, 0f, z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocidad = velocidad - 0.0125f;
            if (velocidad < 0f)
            {
                velocidad = 0.2f;
            }
        }
    }
  

    void Rotacion()
    {
        //float InHorizontal = Input.GetAxis("Horizontal");
        //float InVertical = Input.GetAxis("Vertical");

        //Vector3 movDireccion = new Vector3(InHorizontal, 0, InVertical);
        //movDireccion.Normalize();
        //transform.Translate(movDireccion * velocidad * Time.deltaTime, Space.World);

        //if (movDireccion != Vector3.zero)
        //{
        //    //transform.forward = movDireccion;
        //    Quaternion toRotation = Quaternion.LookRotation(movDireccion, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotacion * Time.deltaTime);
        //}
    }
}

