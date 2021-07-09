using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxLength=1f;// este es la distancia máxima que se estira una barra
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;
    public HingeJoint2D StartJoint;
    public HingeJoint2D EndJoint;

    public float costo = 1;
    public float costoActual;

    
    public void UpdateCreatingBar(Vector2 ToPosition) //SE CREA LA VIGA O CUERDA, SE SACA POSICIÓN, ANGULO, TAMAÑO
    {
        transform.position = (ToPosition + StartPosition) / 2;
        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        float Length = dir.magnitude * 4;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;

        costoActual = Length * costo;
    }
}