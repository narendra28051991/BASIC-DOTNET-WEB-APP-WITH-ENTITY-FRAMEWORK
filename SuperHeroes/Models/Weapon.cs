namespace SuperHeroes.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }
        public List<Character> Characters { get; set;}
    }
}
