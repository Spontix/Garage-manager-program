using System;
namespace Ex03.GarageLogic.Enums
{
    public class LicenseType
    {
        private eLicenseType m_LicenseChosen;

        public static LicenseType Parse(string i_InputValue)
        {
            LicenseType licenseChosen = new LicenseType();

            switch (i_InputValue)
            {
                // $G$ CSS-999 (-5) You should use the value of the enum.
                case "1":
                    {
                        licenseChosen.m_LicenseChosen = eLicenseType.A;
                        break;
                    }
                case "2":
                    {
                        licenseChosen.m_LicenseChosen = eLicenseType.B1;
                        break;
                    }
                case "3":
                    {
                        licenseChosen.m_LicenseChosen = eLicenseType.AA;
                        break;
                    }
                case "4":
                    {
                        licenseChosen.m_LicenseChosen = eLicenseType.BB;
                        break;
                    }
                default:
                    {
                        throw new FormatException("Wrong input. Please enter numbers according to right values.");
                    }
            }

            return licenseChosen;
        }

        public override string ToString()
        {
            return string.Format(@"{0}", this.m_LicenseChosen);
        }

        public eLicenseType LicenseChosen
        {
            get
            {
                return this.m_LicenseChosen;
            }
            set
            {
                this.m_LicenseChosen = value;
            }
        }
    }
}
