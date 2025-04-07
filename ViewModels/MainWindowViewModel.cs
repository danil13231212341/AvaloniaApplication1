using AvaloniaApplication1.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private MySet<int> _mySet = new MySet<int>();
        private string _inputText = "";
        private string _outputText = "";

        // Для отображения элементов в UI
        public ObservableCollection<int> SetItems { get; } = new ObservableCollection<int>();

        public string InputText
        {
            get => _inputText;
            set => this.RaiseAndSetIfChanged(ref _inputText, value);
        }

        public string OutputText
        {
            get => _outputText;
            set => this.RaiseAndSetIfChanged(ref _outputText, value);
        }

        //код для кнопок
        public void AddElement()
        {
            if (int.TryParse(InputText, out int number))
            {
                _mySet.Add(number);
                UpdateSetItems();
                OutputText = $"Добавлено: {number}";
            }
            else
            {
                OutputText = "Ошибка: введите число!";
            }
        }

        public void RemoveElement()
        {
            if (int.TryParse(InputText, out int number))
            {
                _mySet.Remove(number);
                UpdateSetItems();
                OutputText = $"Удалено: {number}";
            }
            else
            {
                OutputText = "Ошибка: введите число!";
            }
        }

        public void CheckContains()
        {
            if (int.TryParse(InputText, out int number))
            {
                bool contains = _mySet.Contains(number);
                OutputText = contains ? $"Элемент {number} есть в множестве" : $"Элемента {number} нет в множестве";
            }
            else
            {
                OutputText = "Ошибка: введите число!";
            }
        }

        public void ClearSet()
        {
            _mySet.Clear();
            UpdateSetItems();
            OutputText = "Множество очищено";
        }

        //обновляет список элементов для отображения
        private void UpdateSetItems()
        {
            SetItems.Clear();
            foreach (var item in _mySet.GetAllElements())
            {
                SetItems.Add(item);
            }
        }
    }
}