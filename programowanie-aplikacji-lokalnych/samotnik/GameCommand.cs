using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samotnik
{
    public class GameCommand
    {
        private List<ButtonState> states;
        public GameCommand(List<ButtonState> states)
        {
            this.states = states;
        }

        public void Reverse()
        {
            this.states.ForEach((state) =>
            {
                state.button.SetIsPawn(state.isPawnAtStateCapture);
            });
        }
    }
}
