using UnityEngine;
using TMPro;

/* 
    Class Gamemanager :
        - Gestion et affichage du pointage;

    Par: Yanis Oulmane
    Derniere modifiaction: 20/11/2024
*/
public class Gamemanager : MonoBehaviour
{
    static public int points;
    [SerializeField] TextMeshProUGUI textePoints;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        textePoints.text = points.ToString();
    }

    public void SetPointage(int nombrePts)
    {
        points += nombrePts;
        textePoints.text = points.ToString();

        /* -------------- DEBUG -------------- */

        // Debug.Log("Pointage: " + points);
    }
}
