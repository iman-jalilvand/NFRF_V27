using UnityEngine;

public class TextMeshInterface : Base
{
	public TextMesh ReferencedTextMesh;
    public bool AutoAssignTextMesh = false;

    public string Incoming;

    private void Awake()
    {
        CacheMethod(Incoming, SetText);
        if (AutoAssignTextMesh && ReferencedTextMesh == null)
        {
            ReferencedTextMesh = cachedGameObject.GetComponent<TextMesh>();
        }
    }

    private void SetText(object o)
    {
        if (o == null)
        {
            return;
        }

        ReferencedTextMesh.text = o.ToString();
    }
}
