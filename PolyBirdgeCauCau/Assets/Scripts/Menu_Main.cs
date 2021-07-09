using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //cargo el metodo gestor de escenas 

public class Menu_Main : MonoBehaviour
{
    
    public void BotonInicio() //accede a cargar la  primera escena. El "Boton de inicio" se mostrara en el inspector para colocar el objeto ButtonInicio de la pantalla 
    {
        SceneManager.LoadScene("Fondo1");  //metodo para cargar escena 
    }
    public void BotonSalir()
    {
        Application.Quit();  //metodo para cerrar aplicacion se vera luego en el ejecutable 
    }
    
}
