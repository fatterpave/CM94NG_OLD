using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using CM94NG.Models;
using Newtonsoft.Json;

namespace CM94NGEditor
{
    public class LeagueDataService
    {
        public static List<Division> _DIVISIONS;
        public static string _FILENAMEANDPATH;

        public LeagueDataService()
        {
            _DIVISIONS = new List<Division>();
        }
        public static bool Load(string filenameandpath)
        {
            using (StreamReader r = new StreamReader(filenameandpath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    _DIVISIONS = JsonConvert.DeserializeObject<List<Division>>(json,new  ColorConverter());
                    _FILENAMEANDPATH = filenameandpath;
                    MessageBox.Show("Data loaded.");
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
                var json = new JavaScriptSerializer().Serialize(_DIVISIONS);
                File.WriteAllText(_FILENAMEANDPATH, json);
                MessageBox.Show("Saved.");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
           
        }
        public static bool SaveAs(string filenameandpath)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(_DIVISIONS);
                File.WriteAllText(filenameandpath, json);
                _FILENAMEANDPATH = filenameandpath;
                MessageBox.Show("Saved.");
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return false;
            }
            
        }

        public static string FileNameAndPath {
            get { return _FILENAMEANDPATH; }
        }
    }
}
