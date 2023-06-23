using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFollowPath : MonoBehaviour
{
    [SerializeField] [Tooltip("The name of the iTweenPath.")]
    private string pathName;
    [SerializeField] [Tooltip("The time it takes to get from the first node till the end of the path.")] 
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        MoveParticles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveParticles()
    {
        iTween.MoveTo(
            gameObject, 
            iTween.Hash(
                "path", iTweenPath.GetPath(pathName)
                //, "easytype", iTween.EaseType.easeInOutSine
                , "easetype", iTween.EaseType.linear
                //, "looptype", iTween.LoopType.pingPong
                , "time", time
                , "oncomplete", "MoveParticles"
            )
        );
    }
}
