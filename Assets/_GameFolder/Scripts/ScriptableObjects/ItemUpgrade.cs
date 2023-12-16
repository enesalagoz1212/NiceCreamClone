using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiceCreamClone.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Item Upgrade", menuName = "Custom/Item Upgrade")]
    public class ItemUpgrade : ScriptableObject
    {
        public float comletionTimeMultiplier;
        public float priceMultiplier;

    }

}
