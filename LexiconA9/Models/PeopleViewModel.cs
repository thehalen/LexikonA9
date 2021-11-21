using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {

        public string filterC ="",filterN;
		public static string filter_C="*", filter_N="*";

		private static List<PersonModel> personsListView = new List<PersonModel>();
		public static List<PersonModel> listOfPeople = new List<PersonModel>();

        public static List<PersonModel> PersonsListView
		{			
			get 
			{
				PeopleViewModel.personsListView.Clear();
				var foo = listOfPeople.Where(c => c.City == filter_C && c.Name == filter_N);
				PeopleViewModel.personsListView.AddRange(foo);
				return listOfPeople;
				return PeopleViewModel.personsListView;
			}
			set => personsListView = value;
		}
        public string FilterC { get => filterC; set => filterC = value; }
        public string FilterN { get => filterN; set => filterN = value; }

        public PeopleViewModel()
        {
            personsListView = new List<PersonModel>();
        }

		public void AddPerson(string name, string city, string phonenr)
		{
			PersonModel person = new PersonModel(name, city, phonenr);
			AddPerson(person);
		}
		public void AddPerson(PersonModel pm)
		{
			listOfPeople.Add(pm);
		}

		public void DeletePerson(int ind)
		{
			if (ind >= 0 && ind < listOfPeople.Count)
			{
				listOfPeople.RemoveAt(ind);
				//return true;
			}
			//return false;
		}

		public static void MakePeople()
		{
			//app peeps
			listOfPeople.Add(new PersonModel() { Name = "Nisse", City = "Malmö", PhoneNr = "09341" });
			listOfPeople.Add(new PersonModel() { Name = "Hans", City = "Tjockholm", PhoneNr = "020KNDÖDEN" });
			listOfPeople.Add(new PersonModel() { Name = "Bojan", City = "London", PhoneNr = "123CALLING" });
		}

	}
}
