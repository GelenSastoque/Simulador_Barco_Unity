using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    //private new Rigidbody rigidbody;
    public Transform barquito;
    public float velocidad = 0.0f, x = 0.0f, z = 0.0f, h = 0.1f;
    private float velx = 0.5f, velz = 0.0f, dt = 0.1f;
    private float tx = 0.0f, tz = 0.0f, acelaz = 0.0f, acelax = 0.0f, angvx = 0.0f, angvz = 0.0f, inercia = 50f, dw = 0.0f, acela = 0.0f, angvelo = 0.0f, dtheta = 0.0f, theta = 0.0f;
    //public GameObject esferita;
    private bool prueba;
    private Vector3 Fuerza;
    private Vector3 PosicionBarco;
    private Vector3 velocidadBarco;
    private Vector3 PosicionAnclaje;
    private Vector3 aceleracionC;
    private Vector3 lookAtanclaje;
    private Vector3 aceleracionAngu;
    //public float aumentacelec = 2.0f;
    private float anclajeX = 0.0f, anclajeZ = 0.0f, anclajeMagnitud = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        PosicionBarco = new Vector3(x, 0.0f, z);
        barquito.transform.position = new Vector3(x, 0f, z);
    }

    float movimientoobj(float posicion, float prueba, float vel)
    {
        posicion = posicion + (h * vel * prueba);
        return posicion;
    }
    float velocidadobj(float fuerza, float velo)
    {

        velo += fuerza * h;
        return velo;
    }

    // Update is called once per frame
    void Update()
    {
        //if (x > 33f)
        //{
        //    x = -33f;
        //}
        //if (x < -33f)
        //{
        //    x = 33f;
        //}
        //if (z < -58f)
        //{
        //    z = 14f;
        //}
        //if (z > 14f)
        //{
        //    z = -58f;
        //}
        //calculos(true);
        //if (velx<0.0f)
        //{
        //    velx = 0.2f;
        //}
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //aumentacelec -= 0.5f;
            if (prueba == false)
            {
                velx += 0.5f;
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //aumentacelec -= 0.5f;
            if (prueba == false)
            {
                velx -= 0.5f;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            prueba = true;
            veclook(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            prueba = true;
            veclook(true);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            actualizarEuler();
            calculos();
            //esferita.transform.position = PosicionAnclaje;
            //barquito.transform.position = new Vector3(x, 0f, z);
        }
        else
        {
            moverderecho();
        }
        barquito.transform.position = new Vector3(x, 0f, z);
        barquito.transform.LookAt(PosicionBarco - velocidadBarco);

    }
    void actualizarEuler()
    {
        x = movimientoobj(x, 1, velx);
        z = movimientoobj(z, 1, velz);
        velx = velocidadobj(Fuerza.x, velx);
        velz = velocidadobj(Fuerza.z, velz);
    }
    void moverderecho()
    {
        x = movimientoobj(x, 1, velx / 2.0f);
        z = movimientoobj(z, 1, velz / 2.0f);
    }
    void calculos()
    {
        Fuerza = new Vector3(0.0f, 0.0f, 0.0f);
        PosicionBarco = new Vector3(x, 0.0f, z);
        //PosicionAnclaje= new Vector3(-9.0f,0.0f,anclajeZ);
        velocidadBarco = new Vector3(velx, 0.0f, velz);
        aceleracionC = new Vector3(0.0f, 0.0f, 0.0f);
        //lookAtanclaje=lookAtanclaje
        aceleracionC = (PosicionAnclaje - PosicionBarco).normalized;
        Fuerza += aceleracionC/ 2.0f;
    }
    void veclook(bool direccion)
    {
        PosicionBarco = new Vector3(x, 0.0f, z);
        anclajeMagnitud = -10.0f;
        float lookAtanclajeX, lookAtanclajeZ;
        if (direccion == true)
        {
            lookAtanclajeX = -velocidadBarco.z;
            lookAtanclajeZ = velocidadBarco.x;
        }
        else
        {
            lookAtanclajeX = velocidadBarco.z;
            lookAtanclajeZ = -velocidadBarco.x;
        }
        Vector3 lookAtanclaje = new Vector3(lookAtanclajeX, 0.0f, lookAtanclajeZ).normalized * anclajeMagnitud;
        //print("magnitud lookAt: "+ lookAtanclaje.magnitude);
        PosicionAnclaje = PosicionBarco + lookAtanclaje;
    }
}
