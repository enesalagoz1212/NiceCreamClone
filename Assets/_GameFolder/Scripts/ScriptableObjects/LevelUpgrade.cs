using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiceCreamClone.ScriptableObjects
{
    [CreateAssetMenu(fileName ="New Level Upgrade",menuName ="Custom/Level Upgrade")]
    public class LevelUpgrade : ScriptableObject
    {
        [System.Serializable]
        public class UpgradeEffect
        {
            public float priceMultiplier = 1f;
            public float productionTimeMultiplier = 1f;
            public float productionProfitMultiplier = 1f;
        }

        public UpgradeEffect[] levelUpgrades;
    }

}
