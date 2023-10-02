using System.Collections.ObjectModel;
using System;
using System.ComponentModel;

namespace battleship
{
    class Panel
    {
        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set; }
        public Panel(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.EMPTY; 
        }

        public string Status
        {
            get
            {
                return GetEnumDescription(OccupationType);
            }
            set {}
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.BATTLESHIP ||
                    OccupationType == OccupationType.CRUISER ||
                    OccupationType == OccupationType.DESTROYER ||
                    OccupationType == OccupationType.SUBMARINE;
            }
        }

        private string GetEnumDescription(Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }
    }
}