using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        public delegate double MissionDelegate(double x);
        public Dictionary<String, MissionDelegate> dict = new Dictionary<String, MissionDelegate>() ;
  
        public  MissionDelegate this[String s]
        {



            get
            {
                if (dict.Keys.Contains(s))
                    return dict[s];

                else
                {
                    dict.Add(s, val => val * 1);
                    return val => val * 1;

                }
            }
            set => dict[s]=value;
        }

        public List<String> getAllMissions()
        {
            return dict.Keys.ToList();

        }
    }
}
