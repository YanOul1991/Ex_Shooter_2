using UnityEngine;
using System.Collections;

/* 
    Scripte de gestion de la creation d'ennemis:
        - Creations d'instances avec Instantiate;
        - Creations avec interval selon le type d'ennemi
    
    Par: Yanis Oulmane
    Derniere modification: 20/11/2024
*/
public class GenererEnnemisScript : MonoBehaviour
{
    [SerializeField] GameObject[] ennemisFaibles;
    [SerializeField] GameObject hellephant;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenererEnnemis());
    }

    IEnumerator GenererEnnemis()
    {
        while (true)
        {
            if (index == 2 || index == 4)
            {
                GameObject instEnnemi = Instantiate(ennemisFaibles[Random.Range(0, 2)]);
                instEnnemi.transform.position = transform.position;
                instEnnemi.SetActive(true);
            }

            if (index == 5)
            {
                GameObject instEnnemi = Instantiate(hellephant);
                instEnnemi.transform.position = transform.position;
                instEnnemi.SetActive(true);
            }

            index = index == 5 ? 1 : index + 1;
            yield return new WaitForSeconds(1);
        }
    }
}
