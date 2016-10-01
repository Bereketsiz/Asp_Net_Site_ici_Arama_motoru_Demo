using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AramaDemo1 : System.Web.UI.Page
{
    Fonksiyon system = new Fonksiyon();

    protected void Page_Load(object sender, EventArgs e)
    {

        //Query Stringden gelen ara ismli paramtreyi alıyoruz ve null değilse
        if (Request.QueryString["ara"] != null)
        {
            //Gelen parametreyi string bir değişkene atıyoruz.
            //Dolayısıyla queryStringden gelen ara isimli değişkenin değeride aranan isimli dğişkende depolanıyor ve
            //Bu değişkeni HaberleriGetir Metoduna parametre olarak gönderdiğimizde metottaki sql sorgusunda aranan değerde bu oluyor
            string aranan = Request.QueryString["ara"];

            //aranan değeri HaberleriGetir Metoduna parametre olarak gönderiyoruz.
            HaberleriGetir(aranan);

        }

    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        //Arama yapacağımız textbox un eğerini temizle metoduna gönderip sqlInjection u engelliyoruz.
        string aranan = txtAra.Text;

        if (aranan.Length < 3)
        {
            lblBilgi.Text = "En Az 3 Karakter Girmelisiniz!";
            GridView1.Visible = false;
            //Eğer 3 karakterden az değer girilirse sonuç dönmeyeceği için önceden ekranda bir değer varsa Datagridi gizliyoruzki herhangi bir değer dönmediği belli olsun

        }
        else
        {
            Response.Redirect("Default.aspx?ara=" + aranan);

        }
        //Response.Redirect("AramaDemo1.aspx");

    }

    //Haberleri veritabanından çekmek için metot tanımlıyoruz.
    void HaberleriGetir(string aranan)
    {
        //Bağlantı kodlarımız.
        SqlConnection baglanti = system.baglan();
        //Veritabanından aldığımız kayıtları DataAdapter e atıyoruz.
        SqlDataAdapter dAdapter = new SqlDataAdapter("select Baslik,Ozet,Detay from Haberler Where Baslik LIKE '%" + aranan + "%' OR Ozet LIKE '%" + aranan + "%' OR Detay LIKE '" + aranan + "%' order by HaberId desc", baglanti);

        //Datatable tanımlıyoruz. Dataadapter için.
        DataTable dtHaberler = new DataTable();

        //Datatable i Adaptere atıyoruz.
        dAdapter.Fill(dtHaberler);

        //Datatable deki satır sayısını alıyoruz. Eğer Kayıt varsa. Okunan kayıtları GridWiev a bağlıyoruz.
        if (dtHaberler.Rows.Count > 0)
        {
            GridView1.DataSource = dtHaberler;
            GridView1.DataBind();
            GridView1.Visible = true;

            //Ardından bulunan kayıt sayısını rakam ile label e yazdırıp kayıt bulundu onu bildiriyoruz.
            lblBilgi.Text = dtHaberler.Rows.Count + " adet sonuç bulunmuştur";
            GridView1.Visible = true;
        }

        else
        {
            //Eğer girilen kelimeyi karşılayacak herangi bir kayıt bulunamazsada aşağıdaki kodu çalıştırıyoruz.
            lblBilgi.Text = aranan + " kelimesi için sonuç bulunamadı";
            GridView1.Visible = false;
        }
    }

}