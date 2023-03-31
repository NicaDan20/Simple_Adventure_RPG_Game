using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
     
    public class SaveGame
    {
        public static string ToXMLString(Player _player, Monster _monster = null)
        {
            XmlDocument playerData = new XmlDocument();
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(_player.CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(_player.MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(_player.Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experience = playerData.CreateElement("ExperiencePoints");
            experience.AppendChild(playerData.CreateTextNode(_player.ExperiencePoints.ToString()));
            stats.AppendChild(experience);

            XmlNode level = playerData.CreateElement("Level");
            level.AppendChild(playerData.CreateTextNode(_player.Level.ToString()));
            stats.AppendChild(level);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(_player.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            XmlNode inventory = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventory);
            _player.Inventory.ForEach(item =>
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);
                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);
                inventory.AppendChild(inventoryItem);
            });

            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);
            _player.Quests.ForEach(q =>
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = q.Details.ID.ToString();
                playerQuest.AppendChild(idAttribute);
                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = q.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);
                playerQuests.AppendChild(playerQuest);
            });

            XmlNode playerCombatState = playerData.CreateElement("PlayerCombatState");
            playerCombatState.AppendChild(playerData.CreateTextNode(_player._curState.ToString()));
            player.AppendChild(playerCombatState);
            
            if (_monster != null)
            {
                XmlNode monster = playerData.CreateElement("Monster");

                XmlAttribute monsterIdAttribute = playerData.CreateAttribute("ID");
                monsterIdAttribute.Value = _monster.ID.ToString();
                monster.Attributes.Append(monsterIdAttribute);

                XmlAttribute monsterCurrentHitPoints = playerData.CreateAttribute("CurrentHitPoints");
                monsterCurrentHitPoints.Value = _monster.CurrentHitPoints.ToString();
                monster.Attributes.Append(monsterCurrentHitPoints);

                XmlAttribute monsterMaximumHitPoints = playerData.CreateAttribute("MaximumHitPoints");
                monsterMaximumHitPoints.Value = _monster.MaximumHitPoints.ToString();
                monster.Attributes.Append(monsterMaximumHitPoints);

                player.AppendChild(monster);
            }

            return playerData.InnerXml;
        }

    }
}
