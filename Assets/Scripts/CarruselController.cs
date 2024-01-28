using UnityEngine;
using UnityEngine.UI;

public class CarruselController : MonoBehaviour
{
    public Image imagenCarrusel;
    public Sprite[] imagenes;
    private int indiceActual = 0;

    void Start()
    {
        MostrarImagenActual();
    }

    public void IrALaIzquierda()
    {
        if (imagenes.Length > 0)
        {
            indiceActual = (indiceActual - 1 + imagenes.Length) % imagenes.Length;
            MostrarImagenActual();
        }
    }

    public void IrALaDerecha()
    {
        if (imagenes.Length > 0)
        {
            indiceActual = (indiceActual + 1) % imagenes.Length;
            MostrarImagenActual();
        }
    }

    private void MostrarImagenActual()
    {
        if (imagenes.Length > 0)
        {
            imagenCarrusel.sprite = imagenes[indiceActual];
        }
    }
}
