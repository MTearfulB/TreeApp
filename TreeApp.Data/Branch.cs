using System.ComponentModel.DataAnnotations;

namespace TreeApp.Data
{
    public class Branch
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public int ParentId {  get; set; } 
    }
}
