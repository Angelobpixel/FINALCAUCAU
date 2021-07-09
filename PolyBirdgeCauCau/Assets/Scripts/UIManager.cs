using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button Bot�nPavimento;
    public Button Bot�nMadera;
    public Button Bot�nAcero;
    public Button Bot�nCuerda;
    public Button Bot�nCuerdaAcero;
    public Button Bot�nResorte;
    public BarCreator barCreator;


    public Slider MarcadorDeDinero;
    public Text presupuesto;
    public Gradient myGradient;

    public void Start()
    {
        Bot�nPavimento.onClick.Invoke();
    }


    public void CambioObjeto(int tipoBarra)
    {
        if (tipoBarra == 0)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = true;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaPavimento;
        }

        else if (tipoBarra == 1)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = true;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaMadera;
        }

        else if (tipoBarra == 2)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = true;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaAcero;
        }

        else if (tipoBarra == 3)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = true;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.Cuerda;
        }

        else if (tipoBarra == 4)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = true;
            Bot�nResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.CuerdaAcero;
        }

        else if (tipoBarra == 5)
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.Resorte;
        }



        else
        {
            Bot�nMadera.GetComponent<Outline>().enabled = false;
            Bot�nPavimento.GetComponent<Outline>().enabled = false;
            Bot�nAcero.GetComponent<Outline>().enabled = false;
            Bot�nCuerda.GetComponent<Outline>().enabled = false;
            Bot�nCuerdaAcero.GetComponent<Outline>().enabled = false;
            Bot�nResorte.GetComponent<Outline>().enabled = false;

        }
    }

    public void actualizarPresupuestoUI(float presupuestoActual, float presupuestoNivel)
    {
        presupuesto.text = Mathf.FloorToInt(presupuestoActual).ToString() + "CLP";
        MarcadorDeDinero.value = presupuestoActual / presupuestoNivel;
        MarcadorDeDinero.fillRect.GetComponent<Image>().color = myGradient.Evaluate(MarcadorDeDinero.value);
    }
}
