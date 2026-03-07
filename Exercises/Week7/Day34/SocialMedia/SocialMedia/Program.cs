using System.Security.Cryptography.X509Certificates;

namespace SocialMedia
{
    class Person
    {
        public string Name { get; set; }

        public List<Person> Friends = new List<Person>();
        public Person(string name) => Name = name;

        public void AddFriend(Person person)
        {
            if (!Friends.Contains(person)) {
                Friends.Add(person);
                person.Friends.Add(this);
            }
             
        }
    }
    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();

        public void AddMember(Person member)
        {
            _members.Add(member); 
        }
        public void ShowNetwork()
        {
            foreach (var members in _members) {
                Console.WriteLine($"{members.Name}->");
                List<string> friends = new List<string>();
                foreach (var friend in members.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",", friends)}");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            

            Person Aman = new Person("Aman");
            Person Bhaskar = new Person("Bhasker");
            Person Chetan = new Person("Chetan");
            Person Diwakar = new Person("Diwakar");

            network.AddMember(Aman);
            network.AddMember(Bhaskar);
            network.AddMember(Chetan);
            network.AddMember(Diwakar);

            Aman.AddFriend(Chetan);
            Aman.AddFriend(Bhaskar);

            Chetan.AddFriend(Diwakar);

            Diwakar.AddFriend(Aman);

            Bhaskar.AddFriend(Chetan);

            network.ShowNetwork();







        }
    }
}
