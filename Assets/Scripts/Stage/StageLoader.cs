using UnityEngine;

public class StageLoader : MonoBehaviour
{
    private GameObject _curStage;

    public GameObject LoadStage(GameObject stagePrefab)
    {
        if (_curStage != null)
        {
            UnloadStage();
        }

        _curStage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
        return _curStage;
    }

    public void UnloadStage()
    {
        if ( _curStage != null )
        {
            Destroy( _curStage );
            _curStage = null;
        }
    }

    public GameObject GetCurrentStage()
    {
        return _curStage;
    }
}