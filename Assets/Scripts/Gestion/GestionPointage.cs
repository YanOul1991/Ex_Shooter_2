using UnityEngine;

public class GestionPointage : MonoBehaviour
{
    /* ================================ VARIABLES ================================ */
    public static string[] lesNoms;
    public static int[] lesScores;

    // public static string[] lesNoms = new string[6] {"", "", "", "", "", ""};
    // public static int[] lesScores = new int[6];

    /* ========================================================================== */

    void Awake()
    {
        // Initialisation lesNoms[];
        lesNoms = new string[6];
        for (int i = 0; i < lesNoms.Length; i++)
        {
            lesNoms[i] = "";
        }

        // // Initialisation lesScores[];
        lesScores = new int[6];
        for (int i = 0; i < lesScores.Length; i++)
        {
            lesScores[i] = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //  Verifier si un enregistrement a deja ete fait :
        //      true -> recupere les donnes;
        //      false -> creer et enregistrer les donnes ; call Sauvegarde();

        if (PlayerPrefs.HasKey("ListeNoms"))
        {
            lesNoms = PlayerPrefsX.GetStringArray("ListeNoms");
            lesScores = PlayerPrefsX.GetIntArray("ListeScores");
        }
        else
        {
            Sauvegarde();
        }
    }

    public static void Sauvegarde()
    {
        // Creer les deux listes de noms et scores;
        // Les deux seront vides;
        bool saveNoms = PlayerPrefsX.SetStringArray("ListeNoms", lesNoms);
        bool saveScores = PlayerPrefsX.SetIntArray("ListeScores", lesScores);
    }

    //  - Methode de verification du score du joueur qui sera appele a chaque fois que le joueur meurt;
    //      - param : aucun;
    //      - return : bool;
    public static bool Verification()
    {   
        //  - Verifier si le pointage est plus grand que le plus petit que le pointage le plus faible 
        //    de la liste de score;
        // 
        //      true -> return true;
        //      defaut -> return false;

        if (Gamemanager.points > lesScores[^1])
        {
            return true;
        }

        return false;
    }
}
