using UnityEngine;
using MathNet.Numerics.Distributions;
using UnityEngine.UIElements.Experimental;

public class NormalDistribution : MonoBehaviour
{
    private Normal waitboxDistribution; // Variable para la distribución normal
    private Normal spawnClientDistribution; // Variable para la distribución normal

    private void Start()
    {
        // Crear la distribución normal con media 10 y desviación estándar 5
        double mean = 10.0;
        double std = 5.0;
        waitboxDistribution = new Normal(mean, std);
        spawnClientDistribution = new Normal(120, 60f);

    }

    public double GenerateRandomValue()
    {
        double value = waitboxDistribution.Sample(); // Obtener un valor aleatorio de la distribución normal
        if (value < 0) // Si el valor es negativo, convertirlo a positivo
        {
            value *= -1;
        }
        return value;
    }

    public double getClientSpawnProbability(float simTime)
    {
        return spawnClientDistribution.Density(simTime) * 150; // Obtener la probabilidad de que un cliente llegue en un tiempo determinado
    }
}
