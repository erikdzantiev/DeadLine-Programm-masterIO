using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DeadLine_Programm
{
    class SaveDL
    {
        public DateTime Time { get; set; }
        public string Name { get; set; }

        public SaveDL(DateTime time, string name)
        {
            Time = time;
            Name = name;
        }

        public override string ToString()
        {
            return Time + " " + Name;
        }
    }

    class ListMid
    {
        List<SaveDL> listSave = new List<SaveDL>();

        public void Add(SaveDL m)
        {
            listSave.Add(m);
        }

        public void ViewToListBox(ListBox l)
        {
            foreach (var v in listSave)
                l.Items.Add(v);
        }

        public void LoadFromFile()
        {
            using (StreamReader sr = new StreamReader("listmid.json"))
            {
                listSave = JsonConvert.DeserializeObject<List<SaveDL>>(sr.ReadToEnd());
            }
        }

        public void SaveToFile()
        {
            var mdJson = JsonConvert.SerializeObject(listSave);

            using (StreamWriter sw = new StreamWriter("listmid.json"))
                sw.WriteLine(mdJson);
        }
    }
}
