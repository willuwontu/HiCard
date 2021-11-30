using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace HiCard.Cards
{
    class MiniGun : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //SetupCard sets the value on card object which is then added to the player later on in ApplyCardStats. Allowing for modifications of its values.
            cardInfo.allowMultiple = false;
            gun.ammo = 20;
            gun.attackSpeed = .75f;
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //OnAddCard is run directly on the player, preventing any modifications from being made to its values.
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //OnRemoveCard is used to reverse monobehaviors and similar things.
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            //Card title
            return "Mini-Gun";
        }
        protected override string GetDescription()
        {
            //Card Description
            return "Look at me spray";
        }
        protected override GameObject GetCardArt()
        {
            //Card art
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            //Card rarity info .Common .Uncommon .Rare
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                //Card properties to display
                //Simple Amount "notAssigned, aLittleBitOf, Some, aLotOf, aHugeAmountOf, slightlyLower, lower, aLotLower, slightlySmaller, smaller"
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+20",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotOf
                },
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return HiCard.ModInitials;
        }
    }
}