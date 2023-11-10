using System.Collections;
using UnityEngine;

public class TotalTrustCalculator : MonoBehaviour
{
    public int totalPoints;
    private float updateInterval = 5.0f;
    private SuspectListManager suspectListManager; // Reference to the SuspectListManager

    private void Start()
    {
        StartCoroutine(RecalculateTotalTrust());
        // Find the SuspectListManager component
        suspectListManager = FindObjectOfType<SuspectListManager>();
    }
void Awake()
{
    DontDestroyOnLoad(gameObject);
    // The rest of your Awake method code here
}

    private IEnumerator RecalculateTotalTrust()
    {
        while (true)
        {
            totalPoints = CalculateTotalTrustPoints();
            // Call UpdateSuspectList whenever total trust points change
            if (suspectListManager != null)
            {
                suspectListManager.UpdateSuspectList();
            }
            yield return new WaitForSeconds(updateInterval);
        }
    }

    private int CalculateTotalTrustPoints()
    {
        int totalPoints = 0;

        // Find all NPC GameObjects in the scene
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");

        // Loop through each NPC and add their trust points to the total
        foreach (GameObject npcObject in npcObjects)
        {
            NPC npcScript = npcObject.GetComponent<NPC>();
            if (npcScript != null && npcScript.gameObject != this.gameObject)
            {
                totalPoints += npcScript.trust;
            }
        }

        return totalPoints;
    }

    public int GetTotalTrustPoints()
    {
        return totalPoints;
    }
}
