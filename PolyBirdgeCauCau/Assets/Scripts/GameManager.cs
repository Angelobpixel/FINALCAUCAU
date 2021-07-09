using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Dictionary<Vector2, Point> AllPoints = new Dictionary<Vector2, Point>();

    public float presupuestoNivel = 1000;
    public float presupuestoActual = 0;
    public UIManager myUIManager;
    
    private void Awake()
    {
        AllPoints.Clear();
        Time.timeScale = 0;
        presupuestoActual = presupuestoNivel;
        myUIManager.actualizarPresupuestoUI(presupuestoActual, presupuestoNivel);
    }
    [ContextMenu("Acción")] //se añade a GameManager la opción de Acción, daría lugar a aplicar las físicas.
    
    public void Play() {
        Time.timeScale = 1;
    }

    public bool colocarMaterial(float valorMaterial)
    {
        if(presupuestoActual < valorMaterial)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    
    public void actualizarPresupuesto(float valorMaterial)
    {
        presupuestoActual -= valorMaterial;
        myUIManager.actualizarPresupuestoUI(presupuestoActual, presupuestoNivel);
    }

}
