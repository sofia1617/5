﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая5
{
    /// <summary>
    /// Логика взаимодействия для DayInfoPage.xaml
    /// </summary>
    public partial class DayInfoPage : Page
    {
        DateTime date;
        List<Punct> puncts;
        List<DaySelect> daySelects;

        public DayInfoPage(DateTime date)
        {
            InitializeComponent();

            daySelects = Serializer.Load<List<DaySelect>>("days.json");
            if (daySelects == null)
            {
                daySelects = new List<DaySelect>();
            }

            this.date = date;
            DateLabel.Content = date.ToLongDateString();
            LoadPuncts();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.ChagePage(new CalendarPage(date));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Navigation.ChagePage(new CalendarPage(date));
        }

        private List<Punct> GetSelectedPuncts()
        {
            DaySelect daySelect = daySelects.Find((item) => item.date == date.ToString("dd.MM.yyyy"));
            if (daySelect == null)
            {
                return new List<Punct>();
            }

            return daySelect.puncts;
        }

        private List<Punct> GetAllPuncts(List<Punct> selected)
        {
            List<Punct> puncts = new List<Punct>();

            Punct cola = selected.Find((item) => item.name == "Кола");
            if (cola == null)
            {
                cola = new Punct("Кола", "cola.png", false);
            }
            puncts.Add(cola);

            Punct coffee = selected.Find((item) => item.name == "Кофе");
            if (coffee == null)
            {
                coffee = new Punct("Кофе", "coffee.png", false);
            }
            puncts.Add(coffee);

            Punct juice = selected.Find((item) => item.name == "Сок");
            if (juice == null)
            {
                juice = new Punct("Сок", "juice.png", false);
            }
            puncts.Add(juice);

            Punct tea = selected.Find((item) => item.name == "Чай");
            if (tea == null)
            {
                tea = new Punct("Чай", "tea.png", false);
            }
            puncts.Add(tea);

            Punct water = selected.Find((item) => item.name == "Вода");
            if (water == null)
            {
                water = new Punct("Вода", "water.png", false);
            }
            puncts.Add(water);

            return puncts;
        }

        private void LoadPuncts()
        {
            List<Punct> selected = GetSelectedPuncts();
            puncts = GetAllPuncts(selected);

            List<SelectionControl> selections = new List<SelectionControl>();
            foreach (var punct in puncts)
            {
                selections.Add(new SelectionControl(punct));
            }
            PunctsList.ItemsSource = selections;
        }

        private void Save()
        {
            List<Punct> selected = puncts.FindAll((item) => item.selected);
            DaySelect daySelect = daySelects.Find((item) => item.date == date.ToString("dd.MM.yyyy"));
            if (daySelect == null)
            {
                daySelect = new DaySelect(date.ToString("dd.MM.yyyy"), selected);
                daySelects.Add(daySelect);
            }
            else
            {
                daySelect.puncts = selected;
            }

            Serializer.Save("days.json", daySelects);
        }
    }
}
