using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    //
    public GameManager myGameManager;

    //esto dps se usa en UIManager para ver el tema de los botones de elección materiales
    public GameObject VigaPavimento;
    public GameObject VigaMadera;
    public GameObject VigaAcero;
    public GameObject Cuerda;
    public GameObject CuerdaAcero;
    public GameObject Resorte;
    //--------------------------------------------------
    bool BarCreationStarted = false;
    public Bar CurrentBar;
    public GameObject BarToInstantiate;
    public Transform barParent;
    public Point CurrentStartPoint;
    public Point CurrentEndPoint;
    public GameObject PointToInstateLate;
    public Transform PointParent;
    public void OnPointerDown(PointerEventData eventData) 
    {
        if (BarCreationStarted == false) //Se construye
        {
            BarCreationStarted = true;
            StartBarCreation(Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(eventData.position)));
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left) //se termina la construcción
            {
                if (myGameManager.colocarMaterial(CurrentBar.costoActual) == true) 
                {  
                    FinishBarCreation();
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right) //Se cancela la cronstrucción
            {
                BarCreationStarted = false;
                DeleteCurrentBar();
            }
        }
    }

    void StartBarCreation(Vector2 StartPosition)
    {
        CurrentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>(); //SE CREA LA NUEVA VIGA O CUERDA
        CurrentBar.StartPosition = StartPosition;

        
        if (GameManager.AllPoints.ContainsKey(StartPosition)) //YA SE HA CREADO ANTES 
        {
            CurrentStartPoint = GameManager.AllPoints[StartPosition];
        }
        else { //NO SE HA CREADO ANTES
            CurrentStartPoint = Instantiate(PointToInstateLate, StartPosition, Quaternion.identity, PointParent).GetComponent<Point>();
            GameManager.AllPoints.Add(StartPosition, CurrentStartPoint);
        }
        


        
        CurrentEndPoint = Instantiate(PointToInstateLate, StartPosition, Quaternion.identity, PointParent).GetComponent<Point>();
    }

    void FinishBarCreation()
    {
        
        if (GameManager.AllPoints.ContainsKey(CurrentEndPoint.transform.position))
        {
            Destroy(CurrentEndPoint.gameObject); //SI YA EXISTE SE DESTRUYE
            CurrentEndPoint = GameManager.AllPoints[CurrentEndPoint.transform.position];
        }
        else { 
            GameManager.AllPoints.Add(CurrentEndPoint.transform.position,CurrentEndPoint);
        }
        
        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);


        CurrentBar.StartJoint.connectedBody = CurrentStartPoint.rbd;
        CurrentBar.StartJoint.anchor = CurrentBar.transform.InverseTransformPoint(CurrentBar.StartPosition);

        CurrentBar.EndJoint.connectedBody = CurrentEndPoint.rbd;
        CurrentBar.EndJoint.anchor = CurrentBar.transform.InverseTransformPoint(CurrentEndPoint.transform.position);

        myGameManager.actualizarPresupuesto(CurrentBar.costoActual);

        StartBarCreation(CurrentEndPoint.transform.position);
    }

    void DeleteCurrentBar()
    {
        Destroy(CurrentBar.gameObject);
        if (CurrentStartPoint.ConnectedBars.Count == 0 && CurrentStartPoint.Runtime == true) Destroy(CurrentStartPoint.gameObject);
        if (CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime == true) Destroy(CurrentEndPoint.gameObject);
    }


    private void Update()
    {
        if (BarCreationStarted == true)
        {
            //SE CALCULA LA POSICION DE LA VIGA O CUERDA, TOMANDO EN CUENTA EL MAXIMO 
            Vector2 EndPosition = (Vector2)Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector2 Dir = EndPosition - CurrentBar.StartPosition; 
            Vector2 ClampedPosition =CurrentBar.StartPosition + Vector2.ClampMagnitude(Dir, CurrentBar.maxLength);
            
            CurrentEndPoint.transform.position = (Vector2)Vector2Int.FloorToInt(ClampedPosition);
            CurrentEndPoint.PointID = CurrentEndPoint.transform.position;
            CurrentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);
        }
    }


}

