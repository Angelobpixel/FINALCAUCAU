using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button BotónPavimento;
    public Button BotónMadera;
    public Button BotónAcero;
    public Button BotónCuerda;
    public Button BotónCuerdaAcero;
    public Button BotónResorte;
    public BarCreator barCreator;


    public Slider MarcadorDeDinero;
    public Text presupuesto;
    public Gradient myGradient;

    public void Start()
    {
        BotónPavimento.onClick.Invoke();
    }


    public void CambioObjeto(int tipoBarra)
    {
        if (tipoBarra == 0)
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = true;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaPavimento;
        }

        else if (tipoBarra == 1)
        {
            BotónMadera.GetComponent<Outline>().enabled = true;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaMadera;
        }

        else if (tipoBarra == 2)
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = true;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.VigaAcero;
        }

        else if (tipoBarra == 3)
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = true;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.Cuerda;
        }

        else if (tipoBarra == 4)
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = true;
            BotónResorte.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.CuerdaAcero;
        }

        else if (tipoBarra == 5)
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.Resorte;
        }



        else
        {
            BotónMadera.GetComponent<Outline>().enabled = false;
            BotónPavimento.GetComponent<Outline>().enabled = false;
            BotónAcero.GetComponent<Outline>().enabled = false;
            BotónCuerda.GetComponent<Outline>().enabled = false;
            BotónCuerdaAcero.GetComponent<Outline>().enabled = false;
            BotónResorte.GetComponent<Outline>().enabled = false;

        }
    }

    public void actualizarPresupuestoUI(float presupuestoActual, float presupuestoNivel)
    {
        presupuesto.text = Mathf.FloorToInt(presupuestoActual).ToString() + "CLP";
        MarcadorDeDinero.value = presupuestoActual / presupuestoNivel;
        MarcadorDeDinero.fillRect.GetComponent<Image>().color = myGradient.Evaluate(MarcadorDeDinero.value);
    }
}
