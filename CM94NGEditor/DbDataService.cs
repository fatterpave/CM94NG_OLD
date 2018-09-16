using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using CM94NG.Models;
using CM94NGEditor.Import;
using Newtonsoft.Json;

namespace CM94NGEditor
{
    public class DbDataService
    {
        public static CMData CmData { get; set; }
        public static string FilePath { get; set; }

        public static void Init()
        {
            CmData = new CMData();
            FilePath = null;
        }
        public static bool Load(string fullpath)
        {
            using (StreamReader r = new StreamReader(fullpath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    CmData = JsonConvert.DeserializeObject<CMData>(json, new ColorConverter());
                    FilePath = fullpath;
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
        }

        public static bool Save()
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(CmData);
                File.WriteAllText(FilePath, json);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }
        public static bool SaveAs(string fullpath)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(CmData);
                File.WriteAllText(fullpath, json);
                FilePath = fullpath;
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return false;
            }

        }

        public static bool Export(string fullpath)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(CmData.LeagueData);
                File.WriteAllText(fullpath, json);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static void Import(string fullpath)
        {
            using (StreamReader r = new StreamReader(fullpath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    CM94Data data = JsonConvert.DeserializeObject<CM94Data>(json);

                    int i = 0;
                    foreach (var club in data.clubs)
                    {
                        Club c = new Club();
                        c.City = club.Trim();
                        c.Name = club.Trim();
                        c.Funds = 10000;
                        c.Id = i++;
                        c.NickName = "";
                        c.PrimaryColor = Color.Red;
                        c.SecondaryColor = Color.White;
                        c.StadiumCapacity = 1000;
                        c.StadiumName = "";
                        CmData.Clubs.Add(c);
                    }

                    int idplayer = 0;
                    foreach (var player in data.players)
                    {
                        if (player.firstName != null && player.surname != "noname")
                        {
                            Player p = new Player();
                            p.Id = idplayer++;
                            p.LastName = player.surname;
                            p.FirstName = player.firstName;
                            p.BirthDate = DateTime.Now.AddYears(-player.age);
                            p.Position = new PlayerPosition()
                            {
                                Goalkeeper = player.position.G,
                                Defender = player.position.D,
                                Midfield = player.position.M,
                                Forward = player.position.A,
                                Center = player.position.C,
                                Right = player.position.R,
                                Left = player.position.L
                            };

                            p.Attributes = new PlayerAttributes();
                            p.Attributes.Passing = player.passing;
                            p.Attributes.Tackling = player.tackling;
                            p.Attributes.Pace = player.pace;
                            p.Attributes.Heading = player.heading;
                            p.Attributes.Development = player.flair;
                            p.Attributes.Dribbling = player.creativity;
                            p.Attributes.Stamina = player.stamina;
                            p.Attributes.Presence = player.influence;
                            p.Attributes.Agility = player.agility;
                            p.Attributes.Strength = player.strength;
                            p.Attributes.Potential = player.potentialSkill;
                            p.Attributes.CurrentPotential = player.currentSkill;
                            p.Attributes.Goalscoring = player.goalscoring;
                            p.Attributes.Persevarance = new Random().Next(0, 20);
                            
                            p.Attributes.Versatility = new Random().Next(0, 20);
                            p.Attributes.Shot = new Random().Next(0, 20);
                            p.Attributes.InjuryProne = new Random().Next(0, 10);
                            p.Attributes.Aggression = new Random().Next(0, 20);
                            p.Attributes.GoalKeeping = p.Position.Goalkeeper ? new Random().Next(15, 20) : new Random().Next(0, 10);

                            Array values = Enum.GetValues(typeof(PlayerPersonality));
                            PlayerPersonality personality = (PlayerPersonality)values.GetValue(new Random().Next(values.Length));
                            p.Personality = personality;

                            PlayerContract contract = new PlayerContract();
                            contract.Salary = new Random().Next(10000, 1000000);
                            contract.Expiry = DateTime.Now.AddYears(new Random().Next(1, 5));
                            contract.StartDate = DateTime.Now.AddYears(-new Random().Next(0, 10));
                            p.Contract = contract;

                            CmData.Players.Add(p);
                        }
                    }
                    
                    foreach (var name in data.playerNames)
                    {
                        if (name.FirstName != null && name.SurName!="noname")
                        {
                            try
                            {
                                CmData.FirstNames.Add(name.FirstName.Trim());
                                CmData.LastNames.Add(name.SurName.Trim());
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }
                    } 
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    
                }
            }
        }
    }
}
