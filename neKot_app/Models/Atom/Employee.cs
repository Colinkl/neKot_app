namespace neKot_app.Models
{
    public class Employee
    {

        public int Id { get; set; }


        public string FirstName { get; set; }


        public string FamilyName { get; set; }


        public string LastName { get; set; }


        public string Department { get; set; }

        public string Role {get; set;}


        public string Email { get; set; }
        public int Phone { get; set; }

        public Account Account {get; set;}

    }
}
