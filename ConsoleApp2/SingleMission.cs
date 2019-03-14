using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private FunctionsContainer.MissionDelegate missionDelegate;
        private string v;

        public SingleMission(FunctionsContainer.MissionDelegate missionDelegate, string v)
        {
            this.missionDelegate = missionDelegate;
            this.v = v;
        }

        public string Name => v;

        public string Type =>"Single";

        public event EventHandler<double> OnCalculate;



        public double Calculate(double value)
        {
            OnCalculate?.Invoke(this, missionDelegate(value));
            return missionDelegate(value);
        }
    }
}
