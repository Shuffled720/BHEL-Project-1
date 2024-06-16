namespace BHEL_Project_1.Models
{
    public class ComponentTypeMaster
    {
        public int ComponentTypeMasterId { get; set; }
        public string Identity_Number { get; set; }
        public string Make { get; set; }
        public bool Is_Ind { get; set; }
        public string Location { get; set; }
        public string Reference_Doc { get; set; }
        public bool Is_BOI { get; set; }
        public int Applicable_Item_Id { get; set; }
        public int ComponentMasterId { get; set; }
        public ComponentMaster? ComponentMaster { get; set; } // Navigation property
    }
}
