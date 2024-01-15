namespace Core.Machine
{
    public static class Epsilon
    {
        private static double? _epsilon = null;
        public static double EPSILON
        {
            get
            {
                if (_epsilon == null)
                {
                    _epsilon = MachineEpsilon();
                }
                return _epsilon.Value;
            }
            set { }

        }

        private static double MachineEpsilon()
        {
            double machEps = 1.0d;

            do
            {
                machEps /= 2.0d;
            }
            while ((double)(1.0 + machEps) != 1.0);

            return machEps;
        }
    }
}
