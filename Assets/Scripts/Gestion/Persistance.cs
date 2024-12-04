using UnityEngine;

/* 
    Class Persistence :
        - Verifie si le GameObject dans laquelle elle se trouve est un singleton;
        - Ne detruit l'instance du GameObject dans laquelle elle se trouve;
        - Class sera donne a tout les GameObject qui seront unique et qui se deplaceront d'une scene a l'autre;

    Par : Yanis Oulmane
    Derniere modification : 20/11/1024
*/
public class Persistance : MonoBehaviour
{
    static public Persistance instance;

    void Awake()
    {
        // 
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

}
