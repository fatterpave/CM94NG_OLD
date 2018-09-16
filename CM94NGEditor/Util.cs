using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CM94NG.Models;

namespace CM94NGEditor
{
    public class Util
    {
        public static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        public static string GetPositionString(PlayerPosition pos)
        {
            string position = "";
            if (pos.Goalkeeper) return "GK";

            position += pos.Defender ? "D" : "";
            position += pos.Midfield ? "M" : "";
            position += pos.Forward ? "A" : "";
            position += pos.Left ? "L" : "";
            position += pos.Right ? "R" : "";
            position += pos.Center ? "C" : "";

            return position;
        }

        public static bool HasDivision(TreeNode node,Division division)
        {
            foreach (TreeNode currentNode in node.Nodes)
            {
                if (((Division) currentNode.Tag).Level == division.Level) return true;
            }
            return false;
        }

        public static bool HasClub(TreeNode node, Club club)
        {
            foreach (TreeNode divNode in node.Nodes)
            {
                foreach (TreeNode clubNode in divNode.Nodes)
                {
                    if (((Club)clubNode.Tag).Id == club.Id) return true;
                }               
            }
            return false;
        }

        public static bool HasPlayer(TreeNode node, Player player)
        {
            foreach (TreeNode divNode in node.Nodes)
            {
                foreach (TreeNode clubNode in divNode.Nodes)
                {
                    foreach (TreeNode playerNode in clubNode.Nodes)
                    {
                        if (playerNode.Tag.GetType() == typeof (Player))
                        {
                            if(((Player)playerNode.Tag).Id == player.Id) return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool HasManager(TreeNode node, Manager manager)
        {
            foreach (TreeNode divNode in node.Nodes)
            {
                foreach (TreeNode clubNode in divNode.Nodes)
                {
                    Club c = (Club) clubNode.Tag;
                    if (c.Manager != null && c.Manager.Id == manager.Id) return true;
                }
            }
            return false;
        }

        public static TreeNode FindNode(TreeNode rootNode,TreeNode node)
        {
            if (rootNode.Nodes != null && rootNode.Nodes.Count > 0)
            {
                foreach (TreeNode n in rootNode.Nodes)
                {
                    if (n != null && n.Tag != null && n.Tag == node.Tag)
                    {
                        return n;
                    }
                    FindNode(n, node);               
                }
            }
            return null;
        }
    }
}
