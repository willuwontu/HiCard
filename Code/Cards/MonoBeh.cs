using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using Hicard.MonoBehaviors;

namespace HiCard.Cards
{
    class MonoBeh : CustomCard
    {
        protected override string GetTitle()
        {
            return "MonoBeh";
        }
        protected override string GetDescription()
        {
            return "MonoBehavior Test";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //SetupCard sets the value on card object which is then added to the player later on in ApplyCardStats. Allowing for modifications of its values.
            cardInfo.allowMultiple = false;
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //OnAddCard is run directly on the player, preventing any modifications from being made to its values.
            var test = player.gameObject.GetOrAddComponent<Test_Mono>();
            test.rampUp *= 0.7f;
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //OnRemoveCard is used to reverse monobehaviors and similar things.
            UnityEngine.Debug.Log($"[{HiCard.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ramping attack speed",
                    amount = "+5%/s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
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
