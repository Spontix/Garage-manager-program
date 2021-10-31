
namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private readonly string r_VehicleOwnerName;
        private readonly string r_VehicleOwnerPhoneNumber;

        public VehicleOwner(string i_VehicleOwnerName, string i_VehicleOwnerPhoneNumber)
        {
            r_VehicleOwnerName = i_VehicleOwnerName;
            r_VehicleOwnerPhoneNumber = i_VehicleOwnerPhoneNumber;
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_VehicleOwnerPhoneNumber;
            }
        }

        public string OwnerName
        {
            get 
            {
                return r_VehicleOwnerName;
            }
        }   
    }
}
