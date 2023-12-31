using UnityEngine;

public class VehicleSpawn : MonoBehaviour
{
    public int LayerNumber;

    private bool SettingsApplied;
    private void FixedUpdate()
    {
        if (SettingsApplied)
        {
            gameObject.layer = LayerNumber;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
            SettingsApplied = true;
        }
    }
}