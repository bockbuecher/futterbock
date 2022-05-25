namespace Futterbock.Model
{
    public class MealCategory
    {
        public int Id { get; set; }
        public Enum.MealCategory Category { get; set; }
        public string Description { get;set; }
    }
}
