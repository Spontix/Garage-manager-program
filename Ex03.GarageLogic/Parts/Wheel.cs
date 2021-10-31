using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly int r_WheelNumber;
        private readonly string           r_ManufactureName;
        private float                     m_CurrentAirPressure;
        private readonly eMaxAirPressure  r_MaxAirPressure;

        public Wheel(int i_NumberOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, eMaxAirPressure i_MaxAirPressure)
        {
            r_WheelNumber = i_NumberOfWheels;
            r_ManufactureName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public eMaxAirPressure MaxAirPressure
        {
            get
            {
                return this.r_MaxAirPressure;
            }
        }

        public float CurrAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }
        }

        private bool overfillOccurred (float i_AirToFill)
        {
            bool overFill = false;

            if ((int) (i_AirToFill + this.m_CurrentAirPressure) > (int) r_MaxAirPressure) 
            {
                overFill = true;
            }

            return overFill;
        }

        public override string ToString()
        {
            return string.Format(@"
    Information for wheel :#{0}
    Manufacturer name: {1}
    Current air pressure: {2}
    Max air pressure: {3}", this.r_WheelNumber, this.r_ManufactureName, this.m_CurrentAirPressure, (float)this.r_MaxAirPressure);
        }

        public void fillAir(float i_AirToFill)
        {
            m_CurrentAirPressure = i_AirToFill;
        }
    }
}
