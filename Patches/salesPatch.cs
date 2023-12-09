using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace LethalCompanyPluginTemplate.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class salesPatch
    {
        [HarmonyPatch(nameof(Terminal.SetItemSales))]
        [HarmonyPostfix()]

        static void StorePrices(ref Item[] ___buyableItemsList)
        {
            ___buyableItemsList[0].creditsWorth = Plugin.WalkieTalkie.Value;
            ___buyableItemsList[1].creditsWorth = Plugin.Flashlight.Value;
            ___buyableItemsList[2].creditsWorth = Plugin.Shovel.Value;
            ___buyableItemsList[3].creditsWorth = Plugin.Lockpicker.Value;
            ___buyableItemsList[4].creditsWorth = Plugin.ProFlashlight.Value;
            ___buyableItemsList[5].creditsWorth = Plugin.Stun_granade.Value;
            ___buyableItemsList[6].creditsWorth = Plugin.Boombox.Value;
            ___buyableItemsList[7].creditsWorth = Plugin.TZP.Value;
            ___buyableItemsList[8].creditsWorth = Plugin.Zap_gun.Value;
            ___buyableItemsList[9].creditsWorth = Plugin.Jetpack.Value;
            ___buyableItemsList[10].creditsWorth = Plugin.Extension_ladder.Value;
            ___buyableItemsList[11].creditsWorth = Plugin.Radar_booster.Value;
            //___buyableItemsList[12].creditsWorth = Plugin.Loud_horn.Value;
            //___buyableItemsList[13].creditsWorth = Plugin.Teleporter.Value;
            //___buyableItemsList[14].creditsWorth = Plugin.Inverse_Teleporter.Value;
        }
    }

    public class Item : ScriptableObject
    {
        public int itemId;

        public string itemName;

        [Space(3f)]
        public List<ItemGroup> spawnPositionTypes = new List<ItemGroup>();

        [Space(3f)]
        public bool twoHanded;

        public bool twoHandedAnimation;

        public bool canBeGrabbedBeforeGameStart;

        [Space(3f)]
        public float weight = 1f;

        public bool itemIsTrigger;

        public bool holdButtonUse;

        public bool itemSpawnsOnGround = true;

        [Space(5f)]
        public bool isConductiveMetal;

        [Header("Scrap-collection")]
        public bool isScrap;

        public int creditsWorth;

        public bool lockedInDemo;

        public int highestSalePercentage = 80;

        [Space(3f)]
        public int maxValue;

        public int minValue;

        public GameObject spawnPrefab;

        [Space(3f)]
        [Header("Battery")]
        public bool requiresBattery = true;

        public float batteryUsage = 15f;

        public bool automaticallySetUsingPower = true;

        [Space(5f)]
        public Sprite itemIcon;

        [Space(5f)]
        [Header("Player animations")]
        public string grabAnim;

        public string useAnim;

        public string pocketAnim;

        public string throwAnim;

        [Space(5f)]
        public float grabAnimationTime;

        [Header("Player SFX")]
        public AudioClip grabSFX;

        public AudioClip dropSFX;

        public AudioClip pocketSFX;

        public AudioClip throwSFX;

        [Header("Netcode")]
        public bool syncGrabFunction = true;

        public bool syncUseFunction = true;

        public bool syncDiscardFunction = true;

        public bool syncInteractLRFunction = true;

        [Header("Save data")]
        public bool saveItemVariable;

        [Header("MISC")]
        public bool isDefensiveWeapon;

        [Space(3f)]
        public string[] toolTips;

        public float verticalOffset;

        public int floorYOffset;

        public bool allowDroppingAheadOfPlayer = true;

        public Vector3 restingRotation = new Vector3(0f, 0f, 90f);

        public Vector3 rotationOffset = Vector3.zero;

        public Vector3 positionOffset = Vector3.zero;

        public bool meshOffset = true;

        public Mesh[] meshVariants;

        public Material[] materialVariants;

        public bool usableInSpecialAnimations;

        public bool canBeInspected = true;
    }
}