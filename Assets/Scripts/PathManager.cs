using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PathManager : MonoBehaviour
{
    public static PathManager instance;
    public CinemachinePath nextPathLink, nextPath;
    public Vector3 pathLinkStart, pathLinkEnd;
    public float currentSwitchPoint;
    public enum CartState {Unlinked, Linked, Onlink}
    public CartState state = CartState.Unlinked;

    private CinemachineDollyCart cart;
    private CinemachinePath.Waypoint[] waypoints;
    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }
        CalculatePathLink();
        cart = GetComponent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        float cart_pos = cart.m_Path.ToNativePathUnits(cart.m_Position, CinemachinePathBase.PositionUnits.Distance);
        if(state == CartState.Linked && Mathf.Abs(cart_pos - currentSwitchPoint) < 0.01) {
            cart.m_Path = nextPathLink;
            cart.m_Position = 0;
            currentSwitchPoint = waypoints.Length - 1;
            state = CartState.Onlink;
        }
        else if(state == CartState.Onlink && Mathf.Abs(cart_pos - currentSwitchPoint) < 0.01) {
            cart.m_Path = nextPath;
            state = CartState.Unlinked;
            cart.m_Position = 0;
            currentSwitchPoint = 0;
        }
    }

    public void CalculatePathLink() {
        waypoints = nextPathLink.m_Waypoints;
        pathLinkStart = waypoints[0].position;
        pathLinkEnd = waypoints[waypoints.Length - 1].position;
    }

    public void SetNextLoop(CinemachinePath pathLink, CinemachinePath path, int swap) {
        nextPathLink = pathLink;
        nextPath = path;
        currentSwitchPoint = swap;
        state = CartState.Linked;
    }
}
