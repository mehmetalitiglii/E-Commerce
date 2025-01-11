using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    [Required]
    [StringLength(100)]

    [DisplayName("Ürün Adı")]

    public string ProductName { get; set; }

    [DisplayName("Fiyat")]

    public decimal UnitPrice { get; set; }


    [DisplayName("Kategori")]
    public int CategoryID { get; set; }
    [DisplayName("Marka")]
    public int SupplierID { get; set; }
    [DisplayName("Stok")]
    public int Stock { get; set; }

    [DisplayName("İndirim")]
    public int Discount { get; set; }

    [DisplayName("Durum")]
    public int StatusID { get; set; }

    [DisplayName("Eklenme Tarihi")]
    public DateTime AddDate { get; set; }

    [DisplayName("Anahtar Kelimeler")]
    public string? Keywords { get; set; }

    private int _Kdv { get; set; }


    [DisplayName("KDV")]

    public int Kdv //KDV değeri için property tanımlanıyor
    {
        get { return _Kdv; } //KDV değeri okunabilir
        set { _Kdv = Math.Abs(value); } //Negatif KDV olamaz
    }

    public int HighLighted { get; set; } //Öne Çıkan Ürünler

    public int TopSeller { get; set; } //Çok Satan Ürünler
    [DisplayName("Bu Ürüne Bakanlar")]

    public int Related { get; set; } //Benzer Ürünler
    [DisplayName("Notlar")]

    public string? Notes { get; set; } //Notlar
    [DisplayName("Fotoğraf")]

    public string? PhotoPath { get; set; } //Fotoğraf Yolu

    public bool? IsActive { get; set; } //Boolean Değer


}
