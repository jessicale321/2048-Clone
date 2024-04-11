using UnityEngine;

///-//////////////////////////////////////////
/// stationary and doesn't move
///
public class TileCell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Tile tile { get; set; }

    public bool empty => tile == null;
    public bool occupied => tile != null; // i don't think this is necessary
}
