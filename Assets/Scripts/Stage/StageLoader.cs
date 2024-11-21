using UnityEngine;

public class StageLoader : MonoBehaviour
{
    private GameObject curStage;

    public GameObject LoadStage(GameObject stagePrefab)
    {
        if (curStage != null)
        {
            UnloadStage();
        }

        curStage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
        return curStage;
    }

    public void UnloadStage()
    {
        if ( curStage != null )
        {
            Destroy( curStage );
            curStage = null;
        }
    }

    public GameObject GetCurrentStage()
    {
        return curStage;
    }
}