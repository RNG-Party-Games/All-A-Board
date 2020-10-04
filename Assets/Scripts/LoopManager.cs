using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoopManager : MonoBehaviour
{
    public static LoopManager instance;
    public List<Activatable> actives;
    public List<LoopStart> loopstarts;
    public List<CinemachinePath> pathlinks;
    public List<CinemachinePath> paths;
    public List<int> swapPoints;
    public int currentloop = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLoop() {
        foreach(Activatable a in actives) {
            a.Reset();
        }
    }

    public void CheckActivations() {
        bool nextLoopOpen = true;
        foreach (Activatable a in actives) {
            if(a.loop == currentloop && !a.activated) {
                nextLoopOpen = false;
            }
        }
        print(nextLoopOpen);
        if(nextLoopOpen) {
            currentloop++;
            PathManager.instance.SetNextLoop(pathlinks[currentloop-1], paths[currentloop], swapPoints[currentloop-1]);
        }
    }
}
