using UnityEngine;

public struct Shape
{

    public Shape(int[] _shapeOfShape, Material _materialOfShape, bool _isGlowing)
    {

        material = _materialOfShape;
        shape = _shapeOfShape;
        isGlowing = _isGlowing;
    }

    public Material material;

    /*EXAMPLE
    Shape code: new int[]{ 0, 2, 2, 0, 0, 0, 2, 0 }
                           N  E  S  W  NE ES SW WN
    Figure:
        0  0  0
        0  X  X
        X  X  0
    */
    public int[] shape;
    public bool isGlowing;
}
