using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    //private new Rigidbody rigidbody;
    public Transform barquito;
    public float velocidad = 0.0f, x = 0.0f, z = 0.0f, h = 0.1f,y=0.0f;
    private float velx = 0.5f, velz = 0.0f, dt = 0.1f;
    private float tx = 0.0f, tz = 0.0f, acelaz = 0.0f, acelax = 0.0f, angvx = 0.0f, angvz = 0.0f, inercia = 50f, dw = 0.0f, acela = 0.0f, angvelo = 0.0f, dtheta = 0.0f, theta = 0.0f;
    //public GameObject esferita;
    private bool prueba,pruebasopotosientasmil=false;
    
    private Vector3 Fuerza;
    private Vector3 PosicionBarco;
    private Vector3 velocidadBarco;
    private Vector3 PosicionAnclaje;
    private Vector3 aceleracionC;
    private Vector3 lookAtanclaje;
    private Vector3 aceleracionAngu;
    float [] Posiciones = new float[4];
    //public float aumentacelec = 2.0f;
    private float aumento = 0.2f;
    private float aumentotheta = 0.1f;
    private bool prueba3 = true;
    private bool prueba2 = true;
    private bool prueba4 = true;
    private float anclajeX = 0.0f, anclajeZ = 0.0f, anclajeMagnitud = 0.0f,alpha=0.0f;
    private int cont=0;

    // Start is called before the first frame update
    void Start()
    {
        PosicionBarco = new Vector3(x, y, z);
        barquito.transform.position = new Vector3(x, y, z);
    }

    
    // Update is called once per frame
    void Update()
    {
        int acum = 0;
        movolas();
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
        
        barquito.transform.position = new Vector3(x, y, z);
        
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
        PosicionBarco = new Vector3(x, y, z);
        //PosicionAnclaje= new Vector3(-9.0f,0.0f,anclajeZ);
        velocidadBarco = new Vector3(velx, 0.0f, velz);
        aceleracionC = new Vector3(0.0f, 0.0f, 0.0f);
        //lookAtanclaje=lookAtanclaje
        aceleracionC = (PosicionAnclaje - PosicionBarco).normalized;
        Fuerza += aceleracionC/ 2.0f;
    }
    void veclook(bool direccion)
    {
        PosicionBarco = new Vector3(x,y, z);
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
        Vector3 lookAtanclaje = new Vector3(lookAtanclajeX,0f, lookAtanclajeZ).normalized * anclajeMagnitud;
        //print("magnitud lookAt: "+ lookAtanclaje.magnitude);
        PosicionAnclaje = PosicionBarco + lookAtanclaje;
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
    //void curvaparametrica(float [] Pos)
    //{
    //    Matrix4x4 (1, Pos[0], Mathf.Pow(Pos[0], 2), Mathf.Pow(Pos[0], 3), Mathf.Pow(Pos[1], 2), Mathf.Pow(Pos[1], 3), 1, Pos[2], Mathf.Pow(Pos[2], 2), Mathf.Pow(Pos[2], 3), 1, Pos[3], Mathf.Pow(Pos[3], 2), Mathf.Pow(Pos[3], 3));
    //   float[,] arrayx = new float[4, 4] { { 1, Pos[0],  Mathf.Pow(Pos[0],2), Mathf.Pow(Pos[0],3) },
    //                            { 1, Pos[1],  Mathf.Pow(Pos[1],2), Mathf.Pow(Pos[1],3) },{ 1, Pos[2],  Mathf.Pow(Pos[2],2), Mathf.Pow(Pos[2],3) },{ 1, Pos[3],  Mathf.Pow(Pos[3],2), Mathf.Pow(Pos[3],3) } };

    //    float[] arrayy= new float[4] {0.0f,5.0f,-5.0f,0.0f };
    //    float[] arrayinverse = new float[4];
    //}

    void movolas()
    {
        //Movimiento en y
        if (y <= 5 && prueba3 == true)
        {
            y = y + aumento;

        }
        else
        {
            prueba3 = false;
            if (y >= -5)
            {
                y = y - aumento;
            }
            else
            {
                prueba3 = true;
            }

        }
        //Movimiento rotatorio
        if (alpha < 0.5236f && prueba2 == true && prueba4==true)
        {
            alpha = alpha + aumentotheta;

        }
        else if(prueba4==true)
        {
            prueba2 = false;
            if (alpha >= 0.0f && pruebasopotosientasmil == false && prueba4 == true)
            {
              
                alpha = alpha - aumentotheta;
               
               
            }
            else
            {
                alpha = 6.2832f;
                pruebasopotosientasmil = true;
                prueba4 = false;
            }
        }
        if (alpha >= 5.76f && pruebasopotosientasmil == true && prueba4==false)
        {
            print("Otro: " + prueba4);
            print("entreee");
            alpha = alpha - aumentotheta;
        }
        else if(prueba4 == false)
        {
            pruebasopotosientasmil = false;
            if (alpha <= 6.2832f)
            {
                alpha = alpha + aumentotheta;
            }
            else
            {
                alpha = 0.0f;
                prueba2 = true;
                prueba4=true;
            }

        }
        print("Alpha: "+alpha);
        barquito.transform.Rotate(alpha, 0f, 0f);
    }
}
