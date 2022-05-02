using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movdos : MonoBehaviour
{
    public float velocidad;
    public float rotacion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float InHorizontal = Input.GetAxis("Horizontal");
        float InVertical = Input.GetAxis("Vertical");

        Vector3 movDireccion = new Vector3(InHorizontal, 0, InVertical);
        movDireccion.Normalize();
        transform.Translate(movDireccion * velocidad * Time.deltaTime, Space.World);

        if (movDireccion != Vector3.zero)
        {
            //transform.forward = movDireccion;
            Quaternion toRotation = Quaternion.LookRotation(movDireccion, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotacion * Time.deltaTime);
        }
    }
}
