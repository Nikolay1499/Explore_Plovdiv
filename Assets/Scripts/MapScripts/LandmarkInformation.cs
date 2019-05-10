using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkInformation : MonoBehaviour
{
    private static List<string> landmarkNames;

    private void InisializeNamesList()
    {
        landmarkNames = new List<string>
        {
            "Architectual and Historical Reserve \"Ancient Plovdiv\"",
            "Archeological Complex \"Nebet tepe\" and Thracian Settlement",
            "Ancient Theatre of Philippopolis",
            "House of Nedkovich",
            "House of Argir Kuyumdjioglu",
            "House of Georgiadi",
            "Balabonov's house",
            "House of Hindliyan",
            "House of Mavridi",
            "House of Hristo G. Danov",
            "Museum House \"Zlatyu Boyadzhiev\"",
            "\"St. st. Konstantin and Elena\" Church",
            "\"St. Nedelya\" Church",
            "\"St. Marina\" Metropolitan Church",
            "Regional Archeological Museum of Plovidv",
            "Historical Museum",
            "Regional Museum of Natural History",
            "City Art Gallery of Plovdiv",
            "Ancient stadium of Philippopolis",
            "Ancient Forum",
            "Ancient Odeon",
            "Monument of the Unification",
            "Clock Tower",
            "Monument of the Soviet Warrior(Alyosha)",
            "The Brotherhood Mound",
            "Djumaya Mosque",
            "TestLandmark"
        };
    }

    public string GetLandmarkName(int id)
    {
        if (landmarkNames == null)
        {
            InisializeNamesList();
        }
        string landmarkName = landmarkNames[id];
        return landmarkName;
    }
}
