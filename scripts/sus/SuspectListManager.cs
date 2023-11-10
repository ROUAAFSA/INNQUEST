using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuspectListManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI suspectsText;

    [System.Serializable]
    public struct Suspect
    {
        public string name;
        public int trust;
    }

    public List<Suspect> suspects = new List<Suspect>();

    private TotalTrustCalculator totalTrustCalculator; // Reference to TotalTrustCalculator

    private void Start()
    {
        totalTrustCalculator = FindObjectOfType<TotalTrustCalculator>();

        if (totalTrustCalculator != null)
        {
            Suspect player = new Suspect { name = "Player", trust = totalTrustCalculator.GetTotalTrustPoints() };
            suspects.Add(player);
        }
        else
        {
            Debug.LogError("TotalTrustCalculator component not found in the scene.");
        }

        // Add random suspects
        suspects.Add(new Suspect { name = "nobleman", trust = 20 });
        suspects.Add(new Suspect { name = "commoner", trust = 30 });
        

        // Sort the list based on trust values
       suspects.Sort((a, b) => a.trust.CompareTo(b.trust));


        // Call UpdateSuspectList to display the sorted list
        UpdateSuspectList(); // Call it here to update the list initially
    }

    public void UpdateSuspectList()
    {
        if (suspectsText != null)
        {
            suspectsText.text = "";
            for (int i = 0; i < suspects.Count; i++)
            {
                suspectsText.text += (i + 1) + ". " + suspects[i].name + suspects[i].trust+"\n";
            }
        }
        else
        {
            Debug.LogError("Text component not found on the GameObject: " + gameObject.name);
        }
    }
     public bool IsPlayerFirst()
    {
        // Check if "Player" is the first entry in the suspect list
        if (suspects.Count > 0)
        {
            return suspects[0].name == "Player";
        }

        return false; // Return false if the list is empty
    }
}
