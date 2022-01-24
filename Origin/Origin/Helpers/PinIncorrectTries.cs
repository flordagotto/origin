using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Helpers
{
    public class PinIncorrectTries : IPinIncorrectTries
    {
        private PinIncorrectTries instance;

        public PinIncorrectTries GetPinTries()
        {
            if (instance == null)
                return new PinIncorrectTries();
            return instance;
        }

        public int Tries = 0;

        public void AnotherTry()
        {
            Tries++;
        }

        public int GetTries()
        {
            return Tries;
        }
    }

    public interface IPinIncorrectTries
    {
        PinIncorrectTries GetPinTries();
        void AnotherTry();

        int GetTries();
    }
}
