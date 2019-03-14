using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private Queue <FunctionsContainer.MissionDelegate>  missionDelegate;
        private string v;

        public ComposedMission(string v)
        {
            missionDelegate = new Queue<FunctionsContainer.MissionDelegate>();
            this.v = v;
        }
       

      /*  public FunctionsContainer.MissionDelegate this [string v]
        {
            get => missionDelegate;
        }*/

        public string Name => v;

        public string Type => "Composed";

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            Queue<FunctionsContainer.MissionDelegate> missionDelegateTmp=new Queue<FunctionsContainer.MissionDelegate>();
            FunctionsContainer.MissionDelegate tmp;
            Double ans = value;
            while (!(missionDelegate.Count == 0))
            {
                tmp = missionDelegate.Dequeue();
                missionDelegateTmp.Enqueue(tmp);
                ans = (Double)tmp((Double)ans);
            }
            OnCalculate?.Invoke(this, ans);
            while (missionDelegateTmp.Count > 0)
                missionDelegate.Enqueue(missionDelegateTmp.Dequeue());
            return ans;
        }

        internal ComposedMission Add(FunctionsContainer.MissionDelegate missionDelegate)
        {
            this.missionDelegate.Enqueue(missionDelegate);
            return this;
        }
    }
}
