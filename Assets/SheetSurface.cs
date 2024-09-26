using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSurface : MonoBehaviour
{
    public static SheetSurface Instance;
    public MeshRenderer[,] CubeMaterials;

    public List<SheetSection> Sections = new List<SheetSection>();

    private void Awake()
    {
        Instance = this;
        CubeMaterials = new MeshRenderer[5, 3];
        foreach(var s in Sections) {
            CubeMaterials[s.X, s.Z] = s.Target.GetComponent<MeshRenderer>();
		}
    }

    [System.Serializable]
    public struct SheetSection
    {
        public int X;
        public int Z;
        public GameObject Target;

		public SheetSection(int x, int z, GameObject cube)
		{
			X = x;
			Z = z;
			Target = cube;
		}
	}
}



