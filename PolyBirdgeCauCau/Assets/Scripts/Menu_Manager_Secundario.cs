using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager_Secundario : MonoBehaviour
{
    public void BotonRederigirEscena(string escena)
    {
        SceneManager.LoadScene(escena);    // cargo nuevamente la escena actual pasado por parametro
    }
    public void OnEnable() 
    {
        Time.timeScale = 0f;  //cuando el panel este activo el juego queda en pausa(tiempo 0)
    }
    public void OnDisable()
    {
        Time.timeScale = 1f;  // cuando el panel  se desactiva el juego se reaunuda(tiempo 1)
    }
}
