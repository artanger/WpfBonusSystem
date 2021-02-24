using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClientBonusSystem.Models;
using System.Net.Http;

namespace ClientBonusSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isSearchByNumber;

        private void rdBtnSearchType_Checked(object sender, RoutedEventArgs e)
        {
            var checkedRadioBtn = (sender as RadioButton);
            isSearchByNumber = checkedRadioBtn.Name.Equals(this.CheckByNumber.Name);

            if (this.txtPhoneNumber != null && this.txtCardNumber != null)
            {
                this.txtPhoneNumber.IsEnabled = !isSearchByNumber;
                this.txtCardNumber.IsEnabled = isSearchByNumber;

                if (isSearchByNumber)
                {
                    this.txtCardNumber.Focus();
                }
                else
                {
                    this.txtPhoneNumber.Focus();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchClient();
        }

        private void SearchClient()
        {
             var searchInput = isSearchByNumber
                ? txtCardNumber.Text.Trim()
                : txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                // return Validation Message
                return;
            }

            if (!searchInput.All(Char.IsDigit))
            {
                // return Validation Message
                return;
            }

            var url = isSearchByNumber 
                ? "api/bonuscard/getbynumber/"
                : $"api/bonuscard/getbyphone/";

            url = $"{url}{searchInput}";

            var response = new CardApiClient().Get(url);

            if (response.IsSuccessStatusCode)
            {
                if (isSearchByNumber)
                {
                    var bonusCard = response.Content.ReadAsAsync<BonusCard>().Result;
                    var bonusCards = new List<BonusCard> { bonusCard };
                    grdClients.ItemsSource = bonusCards;
                }
                else
                {
                    var bonusCards = response.Content.ReadAsAsync<IEnumerable<BonusCard>>().Result;

                    grdClients.ItemsSource = bonusCards;
                }
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void grdClients_Loaded(object sender, RoutedEventArgs e)
        {
            SearchClient();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cardDto = (BonusCard)((Button)e.Source).DataContext;

                if (string.IsNullOrEmpty(cardDto.CardNumber))
                {
                    var newCardWindiw = new NewCard(cardDto);
                    newCardWindiw.Show();
                }
                else
                {
                    var cardWindiw = new Card(cardDto);
                    cardWindiw.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var newCardWindiw = new AddCardCllient();
            newCardWindiw.Show();
        }
    }
}

 




