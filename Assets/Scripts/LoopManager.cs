using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoopManager : MonoBehaviour
{
    public static LoopManager instance;
    public List<Activatable> actives;
    public List<SpriteRenderer> pathSigns;
    public List<CinemachinePath> pathlinks;
    public List<CinemachinePath> paths;
    public List<int> swapPoints, startPoints;
    public int currentloop = 0;
    public Sprite openSprite;
    public bool nextLoopOpen = false;
    public AudioClip openSFX;
    public Animator octo;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLoop() {
        if(PathManager.instance.state == PathManager.CartState.Unlinked) {
            SFXController.instance.Refresh();
            foreach (Activatable a in actives) {
                a.Reset();
            }
        }
    }

    public void AddActive(Activatable a) {
        actives.Add(a);
    }

    public void CheckActivations() {
        bool alreadyOpen = nextLoopOpen;
        nextLoopOpen = true;
        foreach (Activatable a in actives) {
            if(a.loop == currentloop && !a.activated) {
                nextLoopOpen = false;
                print(a.name + "wasn't hit.");
            }
        }
        if(nextLoopOpen) {
            if(!alreadyOpen) {
                SFXController.instance.PlaySFX(openSFX, 1, false);
                if (currentloop == 4) {
                    octo.Play("OctoHide");
                }
            }
            pathSigns[currentloop].sprite = openSprite;
            currentloop++;
            print("moving on to loop " + currentloop);
            PathManager.instance.SetNextLoop(pathlinks[currentloop], paths[currentloop], swapPoints[currentloop-1], startPoints[currentloop]);
        }
    }
}
