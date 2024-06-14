using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Models
{
    public class AddStudent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }

    }
}
