using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_CurrentValue, float i_MaxValue, float i_MinValue)
            : base(string.Format(@"
A value that entered is causing an overload.
The max amount in this type of vehicle is {0}.
You currently have {1} in this vehicle. 
Please enter amount between {2} to {3}
",
                i_MaxValue, i_CurrentValue, i_MinValue, (i_MaxValue - i_CurrentValue)))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_expectedAmount, float i_MaxValue, string i_Item)
    : base(string.Format(@"
Problem detected when trying to insert {0}
Value entered is causing an overload.
The max amount allowed by the manufacturer for this vehicle is {1}.
You currently trying to fill {2}. Please try again. 
", i_Item, i_MaxValue, i_expectedAmount))
        {
            m_MaxValue = i_MaxValue;
        }
    }
}
