using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [Header("Game Properties")]
    [SerializeField]
    int timeLimit;

    [Header("Common Scripts")]
    [SerializeField]
    List<string> onMissionStartScripts;
    [SerializeField]
    List<string> onMissionAccomplishedScripts;
    [SerializeField]
    List<string> onMissionFailedScripts;
    [SerializeField]
    List<string> onDeadScripts;
    
    public void InvokeMethod(string methodName, float delay)
    {
        Invoke(methodName, delay);
    }

    public virtual void OnGameOver(bool isDead)
    {
        if(isDead == true)
        {
            int index = UnityEngine.Random.Range(0, onDeadScripts.Count);
            GameManager.ScriptManager.AddScript(onDeadScripts[index]);
        }
        else
        {
            GameManager.ScriptManager.AddScript(onMissionFailedScripts);
        }
    }

    void Start()
    {
        GameManager.UIController.SetRemainTime(timeLimit);
        GameManager.ScriptManager.AddScript(onMissionStartScripts);
    }
}
