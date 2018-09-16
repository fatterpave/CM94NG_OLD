using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CM94NG.Models;
using Newtonsoft.Json;

namespace CM94NG
{
    public class DataUtil
    {
        public static List<Division> _DIVISIONS; 
        public DataUtil()
        {
            _DIVISIONS = LoadLeague();
            //DataUtil.SaveAsJson(_DIVISIONS);
        }
        public static List<Division> LoadLeague()
        {
            List<Division> divisions = new List<Division>();

            using (StreamReader r = new StreamReader("..\\..\\GUI\\Data\\piss.cmng"))
            {
                try
                {
                    string json = r.ReadToEnd();
                    divisions = JsonConvert.DeserializeObject<List<Division>>(json,new ColorConverter());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw e;
                }
                
            }

            return divisions;
        }

        public static void SaveAsJson(List<Division> divisions)
        {
            var json = new JavaScriptSerializer().Serialize(divisions);
            File.WriteAllText(@"C:\misc\test.json", json);
        }
    }
}
