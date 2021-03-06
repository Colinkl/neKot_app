﻿using neKot_app.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using neKot_app.Views;
using neKot_app.Services;
using System.Collections.Generic;

namespace neKot_app.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand {get; }
        public ObservableCollection<NewsModel> News { get; set; }
        public Command<NewsModel> ItemTapped { get; }

        private NewsModel selectedItem;
        private NewsService newsService;
        
        public NewsViewModel()
        {
            Title = "News";
            News = new ObservableCollection<NewsModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AppearItemsCommand = new Command(async() => await ExecuteAppearItemsCommand());
            ItemTapped = new Command<NewsModel>(OnItemSelected);
            newsService = new NewsService(HttpClient);
        }
        public NewsModel SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(NewsModel news)
        {
            if (news == null)
                return;
            await OpenBrowser(news.Link);      
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await UpdateNews();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ExecuteAppearItemsCommand()
        {
            try
            {
                await UpdateNews();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task UpdateNews()
        {
            News.Clear();
            List<NewsModel> news = new List<NewsModel>();
            try
            {
                news = await newsService.GetNews(1);
            }
            catch (Exception e)
            {
                throw e;
            }
            //var news = new List<NewsModel>()
            //{
            //    new NewsModel { Title = "Стартовал всероссийский этап Всероссийских спортивных состязаний", Avatar = "https://admtyumen.ru/images/thumbnails/1000_1000/t_-1168059359_body.jpg", Date = DateTime.Now},
            //    new NewsModel { Title = "Стартовал всероссийский этап Всероссийских спортивных состязаний", Avatar = "https://admtyumen.ru/images/thumbnails/1000_1000/t_-1168059359_body.jpg", Date = DateTime.Now},
            //    new NewsModel { Title = "Стартовал всероссийский этап Всероссийских спортивных состязаний", Avatar = "https://admtyumen.ru/images/thumbnails/1000_1000/t_-1168059359_body.jpg", Date = DateTime.Now}
            //};
            foreach (var item in news)
            {
                News.Add(item);
            }
        }
        private async Task OpenBrowser(string url)
        {
            var uri = url.Replace("Id","id");
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}