using UnityEngine;

public class WaterDashPointInstancing : MonoBehaviour {
    private WaterDashPoint dashPointInstance;
    public WaterDashPoint DashPointInstance {
        set { dashPointInstance = value; }
    }

    public bool TryToDash(Rigidbody2D playerRb) {
        if (dashPointInstance) {
            dashPointInstance.DashingPlayer(playerRb);
            return true;
        }
        else {
            return false;
        }
    }
}
