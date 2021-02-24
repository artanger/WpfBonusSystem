using ClientBonusSystem.Models;
using Newtonsoft.Json;
using System;
using System.Windows;

namespace ClientBonusSystem
{
    /// <summary>
    /// Interaction logic for NewCard.xaml
    /// </summary>
    public partial class NewCard : Window
    {
        private BonusCard _card;

        public NewCard(BonusCard card)
        {
            InitializeComponent();

            this._card = card;

            this.txtFirstName.Text = _card.FirstName;
            this.txtLastName.Text = _card.LastName;
            this.txtPhoneNumber.Text = _card.PhoneNumber;
            this.txtBalance.Text = _card.Balance.ToString();
            this.dpExpDate.SelectedDate = DateTime.UtcNow.AddDays(1095);
            this.txtCreationDate.Text = _card.CreationDate.ToString();
        }

        private void btnCreateCard_Click(object sender, RoutedEventArgs e)
        {
            var url = "api/bonuscard";

            var qryParams = $"phone={_card.PhoneNumber}&expdate={this.dpExpDate.SelectedDate.Value:dd.MM.yyyy}";

            url = $"{url}?{qryParams}";

            var parametrers = new CreateParamsModel
            {
                PhoneNumber = _card.PhoneNumber,
                ExpirationDate = this.dpExpDate.SelectedDate.Value.ToString("dd.MM.yyyy")
            };

            var postParams = JsonConvert.SerializeObject(parametrers);

            var response = new CardApiClient().Post(url, postParams);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Success");

                Close();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            } 
        }

       
    }
}
