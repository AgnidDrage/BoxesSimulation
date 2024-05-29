using UnityEngine;
using MathNet.Numerics.Distributions;
using UnityEngine.UIElements.Experimental;

public class NormalDistribution : MonoBehaviour
{
    private Normal normalDistribution; // Variable para la distribución normal

    private void Start()
    {
        // Crear la distribución normal con media 10 y desviación estándar 5
        double mean = 10.0;
        double std = 5.0;
        normalDistribution = new Normal(mean, std);

    }

    public double GenerateRandomValue()
    {
        double value = normalDistribution.Sample(); // Obtener un valor aleatorio de la distribución normal
        if (value < 0) // Si el valor es negativo, convertirlo a positivo
        {
            value = value * -1;
        }
        return value;
    }
}
