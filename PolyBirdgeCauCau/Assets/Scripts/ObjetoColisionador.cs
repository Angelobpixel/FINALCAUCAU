using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColisionador : MonoBehaviour
{
    public GameObject objeto;
    public GameObject Panel;
    public int cant_automoviles;
    int cont_automoviles_exito = 0;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider == true)
        {
            cont_automoviles_exito += 1;
            objeto.SetActive(false);
        }
        if (cont_automoviles_exito == cant_automoviles) {
            Panel.SetActive(true);
        }
    }


    
    void Update()
    {
        
    }
}
