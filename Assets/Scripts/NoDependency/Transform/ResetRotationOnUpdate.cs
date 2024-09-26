using UnityEngine;

public class ResetRotationOnUpdate : Base {

    public bool X = true;
	public bool Y = true;
	public bool Z = true;

    void Update()
    {
        Vector3 rot = cachedTransform.rotation.eulerAngles;
        if (X)
        {
            rot.x = 0;
        }
        if (Y)
        {
            rot.y = 0;
        }
        if(Z)
        {
            rot.z = 0;
        }
        cachedTransform.rotation = Quaternion.Euler(rot);
    }
}
