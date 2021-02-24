using ClientBonusSystem.Models;
using Newtonsoft.Json;
using System.Windows;

namespace ClientBonusSystem
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Window
    {
        private BonusCard _card;

        public Card(BonusCard card)
        {
            InitializeComponent();

            this._card = card;

            this.txtFirstName.Text = _card.FirstName;
            this.txtLastName.Text = _card.LastName;
            this.txtPhoneNumber.Text = _card.PhoneNumber;
            this.txtBalance.Text = _card.Balance.ToString();
            this.tbBonusValue.Text = 100.ToString();
            this.txtCardNumber.Text = _card.CardNumber;
            this.txtCreationDate.Text = _card.CreationDate.ToString();


            //this.txtBonus = _card.Balance.ToString();

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            UpdateCard(true);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            UpdateCard(false);
        }

        private void UpdateCard(bool isAdding)
        {
            var url = "api/bonuscard/update";

            var typeParam = isAdding ? 1.ToString() : 0.ToString();

            var qryParams = $"number={_card.CardNumber}&value={this.tbBonusValue.Text}&type={typeParam}";

            url = $"{url}?{qryParams}";

            var parametrers = new PaymentCardParamsModel
            {
                CardNumber = _card.CardNumber,
                NewValue = _card.Balance.Value.ToString(),
                Type = typeParam
            };

            var postParams = JsonConvert.SerializeObject(parametrers);

            var response = new CardApiClient().Post(url, postParams);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }


    }
}
