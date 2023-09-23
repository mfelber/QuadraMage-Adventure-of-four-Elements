[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int fireRate;
    public int speed;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
       
    }
}