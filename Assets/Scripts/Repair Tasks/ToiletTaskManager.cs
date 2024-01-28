using System;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Serialization;

public class ToiletTaskManager : MonoBehaviour
{
    [Header("Step Control")] 
    [SerializeField] private int currentStep = 0;
    
    /*
     * Initial Problems
     * - #0 Fuga de agua
     * - #1 Agua chorreada
     * - #2 Inodoro Tapado
     *
     * Version de Inodoro
     * - MX
     * - EU
     * - JP
     */
    [SerializeField] private int initialProblem = 0;
    [SerializeField] private string toiletVersion = "MX";
    
    [Header("Contadores")]
    [SerializeField] private int pumpsDone = 0;
    [SerializeField] private bool taskDone = false;
    
    private void Start()
    {
        // TODO: AGREGAR VALORES INICIALES AL INICIAR EL JUEGO
    }
    
    /*
     * Actions
     * - #1 Bajar palanca de inodoro regular
     * - #2 Bajar palanca de inodoro espejo
     * - #3 Bombear taza 
     * - #4 Romper la taza de la cisterna
     * - #5 Cerrar llave derecha
     * - #6 Cerrar llave izquierda
     */

    public void PerformStep(int stepId)
    {
        if (taskDone) return;

        switch (stepId)
        {
            case 1:
                PerformAction1();
                break;
            case 2:
                PerformAction2();
                break;
            case 3:
                PerformAction3();
                break;
            case 4:
                PerformAction4();
                break;
            case 5:
                PerformAction5();
                break;
            case 6:
                PerformAction6();
                break;
        }
    }

    private void MarkTaskDone()
    {
        taskDone = true;
        RepairTaskManager.Instance.FinishedTask();
        Debug.Log("TOILET DONE");
    }
    
    // PALANCA NORMAL
    private void PerformAction1()
    {
        if (initialProblem == 2 && currentStep == 2 && toiletVersion is "MX" or "EU")
        {
            MarkTaskDone();
        } 
        else if (initialProblem is 0 or 1 && currentStep == 3 && toiletVersion is "MX" or "EU")
        {
            MarkTaskDone();
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
    
    // PALANCA ESPEJO
    private void PerformAction2()
    {
        if (initialProblem == 2 && currentStep == 2 && toiletVersion == "JP")
        {
            MarkTaskDone();
        }
        else if (initialProblem is 0 or 1 && currentStep == 3 && toiletVersion == "JP")
        {
            MarkTaskDone();
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
    
    // BOMBEAR AGUA
    private void PerformAction3()
    {
        if (initialProblem == 2 && currentStep == 1)
        {
            pumpsDone++;
            
            switch (toiletVersion)
            {
                case "MX":
                    if (pumpsDone == 4) currentStep++;
                    break;
                case "EU":
                    if (pumpsDone == 2) currentStep++;
                    break;
                case "JP":
                    if (pumpsDone == 3) currentStep++;
                    break;
            }
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
    
    // ROMPER LA TAZA
    private void PerformAction4()
    {
        if (currentStep == 1 && initialProblem is 1 or 2)
        {
            currentStep++;
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
    
    // CERRAR LLAVE DERECHA
    private void PerformAction5()
    {
        if (currentStep == 2 && toiletVersion == "MX")
        {
            currentStep++;
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
    
    // CERRAR LLAVE IZQUIERDA
    private void PerformAction6()
    {
        if (currentStep == 2 && toiletVersion is "JP" or "EU")
        {
            currentStep++;
        }
        else
        {
            RepairTaskManager.Instance.MarkMistake();
        }
    }
}
