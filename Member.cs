namespace Inlämningsuppg2
{
    partial class Program
    {
        public class Member
        {
            // auto proppar
            public string Name { get; set; }
            public int Age { get; set; }
            public int Height { get; set; }
            public string Hobby { get; set; }
            public string FavoriteFood { get; set; }
            public string FavoriteColor { get; set; }
            public string Motivation { get; set; }
            public string CurrentCity { get; set; }
            public string CityOfBirth { get; set; }
            public int NumberOfSiblings { get; set; }

            // konstruktor som tar emot information och sätter det inuti properties.
            public Member(string name, int age, int height, string hobby, string favoriteFood, string favoriteColor, string motivation, string currentCity, string cityOfBirth, int numberOfSiblings)
            {
                this.Name = name;
                this.Age = age;
                this.Height = height;
                this.Hobby = hobby;
                this.FavoriteFood = favoriteFood;
                this.FavoriteColor = favoriteColor;
                this.Motivation = motivation;
                this.CurrentCity = currentCity;
                this.CityOfBirth = cityOfBirth;
                this.NumberOfSiblings = numberOfSiblings;

            }
            // overridar ToString och returnerar all infomration om den skapade medlemmen.
            public override string ToString()
            {
                return $"Namn: {Name}\nÅlder: {Age}\nLängd: {Height}\nHobby: {Hobby}\nFavoritkäk: {FavoriteFood}\nFavoritfärg: {FavoriteColor}\n" +
                    $"Motivation: {Motivation}\nHemort: {CurrentCity}\nFödelseort: {CityOfBirth}\nSyskon: {NumberOfSiblings}\n";
            }

        }
    }
}

