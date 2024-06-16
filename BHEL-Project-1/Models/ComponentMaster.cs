namespace BHEL_Project_1.Models
{
    public class ComponentMaster
    {
        public int ComponentMasterId { get; set; }
        public int Item_Type_Id { get; set; }
        public string Component_Name { get; set; }
        public string Component_Ref_Name { get; set; }
        public string Updated_By { get; set; }
        public DateOnly? Updated_On { get; set; }
        public ICollection<ComponentTypeMaster>? ComponentTypeMasters { get; set; } // Navigation property

        public ComponentMaster()
        {
            ComponentMasterId = 0;
            Item_Type_Id = 0;
            Component_Name = string.Empty;
            Component_Ref_Name = string.Empty;
            Updated_By = string.Empty;
            Updated_On = null;
        }

    }
}
