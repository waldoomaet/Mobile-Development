using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.ViewModels
{
    class LanguagesViewModel
    {
        public LanguagesViewModel()
        {
            CSharp = new LanguageItem("csharp.png", "C#", "250 horas");
            CPlusPlus = new LanguageItem("cplusplus.png", "C++", "350 horas");
            Python  = new LanguageItem("python.png", "Python", "150 horas");
            Java  = new LanguageItem("java.png", "Java", "250 horas");
            Asm = new LanguageItem("asm.png", "x86 Assembler", "1000 horas");
            Js = new LanguageItem("js.png", "JavaScript", "300 horas");
            Option1 = new TabBarOption("home.png", "Profile 1");
            Option2 = new TabBarOption("battery.png", "Profile 2");
            Option3 = new TabBarOption("star.png", "Profile 3");
            Option4 = new TabBarOption("analytics.png", "Profile 4");
            Option5 = new TabBarOption("trend.png", "Profile 5");
        }

        public TabBarOption Option1 { get; }
        public TabBarOption Option2 { get; }
        public TabBarOption Option3 { get; }
        public TabBarOption Option4 { get; }
        public TabBarOption Option5 { get; }
        public LanguageItem CSharp { get; }
        public LanguageItem CPlusPlus { get; }
        public LanguageItem Python { get; }
        public LanguageItem Java { get; }
        public LanguageItem Asm { get; }
        public LanguageItem Js { get; }
    }
}
