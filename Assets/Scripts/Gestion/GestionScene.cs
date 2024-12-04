using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* 
    Gestion scene de fin:
        -Affichage titre et btn commencer avec touche 'espace'

        Par: Yanis Oulmane
        Derniere modification: 20/11/2024
*/

public class GestionScene : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI texteCommencer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

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
