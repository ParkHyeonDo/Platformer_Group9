using UnityEngine;

public class StageLoader : MonoBehaviour
{
    private GameObject _curStage;

    public void LoadStage(GameObject stagePrefab)
    {
        if (_curStage != null)
        {
            UnloadStage();
        }

        _curStage = GameObject.Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
    }

    public void UnloadStage()
    {
        if ( _curStage != null )
        {
            GameObject.Destroy( _curStage );
            _curStage = null;
        }
    }
}