namespace BHEL_Project_2.Models
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string Component_Name { get; set; }
        public string Ref { get;set; }
        public string? Serial_Number { get; set; }
        public string? Make { get; set; }
        public string? AlternateMake_1 { get; set; }
        public string? AlternateMake_2 { get; set; }

        public Component()
        {
            Component_Name = "";
            Ref = "";
            Serial_Number = "";
            Make = "";
            AlternateMake_1 = "";
            AlternateMake_2 = "";
        }

    }
}
