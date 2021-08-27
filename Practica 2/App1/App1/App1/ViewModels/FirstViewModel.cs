using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class FirstViewModel: INotifyPropertyChanged
    {
        public MenuOption CSharp { get; set; } = new MenuOption("csharp.png","C#","250 horas");
        public MenuOption CPlusPlus { get; set; } = new MenuOption("cplusplus.png", "C++", "350 horas");
        public MenuOption Python { get; set; } = new MenuOption("python.png", "Python", "150 horas");
        public MenuOption Java { get; set; } = new MenuOption("java.png", "Java", "250 horas");
        public MenuOption Asm { get; set; } = new MenuOption("asm.png", "x86 Assembler", "1000 horas");
        public MenuOption Js { get; set; } = new MenuOption("js.png", "JavaScript", "300 horas");

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
