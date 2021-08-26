namespace PetShop.UI
{
    public class StringConstants
    {
        //Menu Choices
        public const string PrintPetListText = "Please press 1 to show all pets.";
        public const string SearchByPetTypeText = "Please press 2 to search by pet type.";
        public const string CreateNewPetText = "Please press 3 to create a new pet.";
        public const string DeletePetText = "Please press 4 to delete a pet.";
        public const string UpdatePetInfoText = "Please press 5 to update a specific pets info.";
        public const string SortPetsByPriceText = "Please press 6 to sort the pet list by price.";
        public const string CheapestPetsText = "Please press 7 to see the 5 cheapest available pets.";
        public const string ExitConsoleText = "Please press 0 to exit the menu.";


        //Menu Messages
        public const string WelcomeGreeting = "Welcome to the PetShop menu, please select an option below:";
        public const string SearchPetTypeByNameText = "Please type the pet type you would like to search for:";
        public const string HereIsAListOfAllPets = "Here is a list of all pets:";
        public const string PleaseEnterPetName = "Please enter the pet name:";
        public const string PleaseEnterPetType = "Please enter the pet type:";
        public const string PleaseEnterPetBirthDay = "Please enter the pets birthday with - or / as separators:";
        public const string PleaseEnterPetSoldDate = "Please enter the day the pet was sold with - or / as separators:";
        public const string PleaseEnterPetColor = "Please enter the pet color:";
        public const string PleaseEnterPetPrice = "Please enter the pet price:";
        public const string PetHasBeenCreatedText = "Pet with the following properties created:";
        public const string ExitingMenuText = "Exiting, thanks for using the menu application";
        
        //Errors
        public const string SeachResultEqualsZero = "Couldn't find a matching pet type, returning to main menu.";
        public const string PetListIsEmptyText = "Couldn't find any results, returning to main menu.";
        public const string NamesCannotContainNumbersText = "Names can't contain numbers, returning to main menu.";
        public const string TypesCannotContainNumbersText = "Types can't contain numbers, returning to main menu.";
        public const string DatesCannotContainLettersText = "Dates can't contain letters, returning to main menu.";
        public const string ColorsCannotContainNumbersText = "Colors can't contain numbers, returning to main menu.";
        public const string PricesCannotContainLettersText = "Prices can't contain letters, returning to main menu.";
        public const string ValueCannotBeNullText = "Field can't be empty, returning to main menu.";
        
    }
}