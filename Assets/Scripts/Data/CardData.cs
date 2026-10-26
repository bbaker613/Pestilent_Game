using UnityEngine;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject
{
    [field: SerializeField] public string Description {  get; private set; }
    [field: SerializeField] public int Energy { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }


}
