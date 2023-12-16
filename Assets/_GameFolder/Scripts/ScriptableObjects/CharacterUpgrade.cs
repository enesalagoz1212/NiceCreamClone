using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiceCreamClone.ScriptableObjects
{
    [CreateAssetMenu(fileName ="New Character Upgrade",menuName ="Custom/Character Upgrade")]
    public class CharacterUpgrade : ScriptableObject
    {
        public float completionTimeMultiplier;
        public float priceMultiplier;
    }
}

