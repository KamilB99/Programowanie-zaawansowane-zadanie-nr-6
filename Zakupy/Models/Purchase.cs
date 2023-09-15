using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakupy.Models;

public partial class Purchase : ObservableValidator
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    [Required(ErrorMessage = "Wymagana jest data zakupu.")]
    private DateTime dateTime = DateTime.Today;

    [ObservableProperty]
    [Required(ErrorMessage = "Wymagana jest nazwa zakupu.")]
    private string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GrossPrice))]
    [Required(ErrorMessage = "Wymagana jest ilość.")]
    [Range(0.0, 9999.99, ErrorMessage = "Niezgadza się ilość.")]
    [Column(TypeName = "decimal(6, 2)")]
    private decimal amount;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GrossPrice))]
    [Required(ErrorMessage = "Wymagana jest cena jednostkowa.")]
    [Range(0.0, 9999.99, ErrorMessage = "Nie zgadza się cena jednostkowa.")]
    [Column(TypeName = "decimal(6, 2)")]
    private decimal unitPrice;

    public decimal GrossPrice => UnitPrice * Amount;

    public bool Validate()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}
