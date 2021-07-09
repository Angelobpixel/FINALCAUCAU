using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColisionador : MonoBehaviour
{
    public GameObject objeto;
    public GameObject Panel;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider == true)
        {
            objeto.SetActive(false);
            Panel.SetActive(true);
        }
    }


    
    void Update()
    {
        
    }
}
