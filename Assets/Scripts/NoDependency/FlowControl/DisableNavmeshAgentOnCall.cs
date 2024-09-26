using System.Collections;
using System.Collections.Generic;


public class DisableNavmeshAgentOnCall : Base
{

    public UnityEngine.AI.NavMeshAgent agent;
    public string CallDisable;

    void Start()
    {
        CacheMethod(CallDisable, (o) =>
        {
            agent.enabled = false;
        });
    }
}
