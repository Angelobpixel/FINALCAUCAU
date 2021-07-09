using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadricula : MonoBehaviour
{

    public void activarCuadricula()
    {
        gameObject.SetActive(false);
        /*
        if (Input.GetMouseButtonDown(0)){
            if (cuadricula == false)
            {
                gameObject.SetActive(true);
                cuadricula = true;
            }
            else
            {
                gameObject.SetActive(false);
                cuadricula = false;             
            }
        }*/
    }
}