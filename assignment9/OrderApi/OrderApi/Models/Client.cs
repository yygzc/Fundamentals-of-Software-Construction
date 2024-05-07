using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        [Required]
        public string Address { get; set; }

        public Client() { }
        public Client(int clientId, string name, string address)
        {
            ClientId = clientId;
            ClientName = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Client ID: {ClientId}, Name: {ClientName}, Address: {Address}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Client other = (Client)obj;
            return ClientId == other.ClientId;
        }
    }
}
