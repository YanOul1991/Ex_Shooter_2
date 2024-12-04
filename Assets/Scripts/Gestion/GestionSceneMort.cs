using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* 
    Gestion scene de fin:
        -Affichage score et btn recommencer avec touche 'espace'

        Par: Yanis Oulmane
        Derniere modification: 20/11/2024
*/
public class GestionSceneMort : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textePoints;
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI texteCommencer;
    void Start()
    {
        Application.targetFrameRate = 60;
        textePoints.text = "Tu as " + Gamemanager.points.ToString() + " points";
        StartCoroutine(ClignoterText());
    }

    // Update is called once per frame
    void Update()
    {
        // Demmarage de la scene de jeu lorsque le joueur appuit sur la touche 'espace'
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Gamemanager.points = 0;
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator ClignoterText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            texteCommencer.enabled = !texteCommencer.enabled;
        }
    }
}
