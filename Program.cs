using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using RestSharp;

class Program
{
    static async Task Main(string[] args)
    {

        // Read data from the CSV file.
            using (var reader = new StreamReader(@"./336_EI_clone.csv"))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Record>().ToList();
                int i = 0;
                foreach (var record in records)
                {
                    // first 200 rows test
                    i++;
                    if(i > 500)
                    {
                        break;
                    }

                    if(i <= 199)
                    {
                        continue;
                    }

                    if (record.Gender == "0")
                    {
                        record.Gender = "Nữ";
                    }else
                    {
                        record.Gender = "Nam";
                    }

                    switch (record.Major)
                    {
                        case "1":
                            record.Major = "Quản trị kinh doanh";
                            break;
                        case "2":
                        record.Major = "Kinh doanh quốc tế";
                        break;
                        case "3":
                        record.Major = "Tài chính kế toán";
                        break;
                        case "4":
                        record.Major = "Tài chính ngân hàng";
                        break;
                        case "5":
                        record.Major = "Marketing";
                        break;
                        default:
                        break;
                    }

                    switch (record.Education)
                    {
                        case "1":
                            record.Education = "Trung cấp";
                            break;
                        case "2":
                        record.Education = "Cao đẳng";
                        break;
                        case "3":
                        record.Education = "Đại học";
                        break;
                        case "4":
                        record.Education = "Sau Đại học";
                        break;
                        default:
                        break;
                    }
                    switch (record.Area)
                    {
                        case "0":
                            record.Area = "Nông thôn";
                            break;
                        case "1":
                        record.Area = "Thành thị";
                        break;
                        default:
                        break;
                    }

                    await CallAPI(record);
                    
                    Console.WriteLine($"Submission No. {record.STT} has been submitted successfully!!!");
                    
                    var timer = (int)new Random().NextInt64(100);
                    Console.WriteLine($"Wait: {(double)timer/1000} seconds to the next submission...");
                    Thread.Sleep(timer);

                    
                }
            }
        
                    
    }

    private static async Task  CallAPI(Record record)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://docs.google.com/forms/d/e/1FAIpQLSc02PKBwg1HT8yfRdbXz6c4EiMOjehsfuiksRl95J_wxo88jA/formResponse");
        // request.Headers.Add("authority", "docs.google.com");
        // request.Headers.Add("accept", "text/html,application/x-www-form-urlencoded,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        // request.Headers.Add("accept-language", "en-US,en;q=0.9");
        // request.Headers.Add("cache-control", "max-age=0");
        // //request.Headers.Add("content-type", "application/x-www-form-urlencoded");
        // request.Headers.Add("origin", "https://docs.google.com");
        // request.Headers.Add("sec-ch-ua-mobile", "?0");
        // request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
        // request.Headers.Add("sec-fetch-dest", "document");
        // request.Headers.Add("sec-fetch-mode", "navigate");
        // request.Headers.Add("sec-fetch-site", "same-origin");
        // request.Headers.Add("sec-fetch-user", "?1");
        // request.Headers.Add("upgrade-insecure-requests", "1");
        //request.Headers.Add("Cookie", "COMPASS=spreadsheet_forms=CjIACWuJV8ZN-MNaGD57u2HrbHba8boHT3l9s1M3YZOYMukHfYCCJf3MPaMADuQqOPt15RD7gIuiBho0AAlriVf_B9IkOmu1FAQSYxbtv3lB2RsOKUPSLyNIn1Ps5ykJyJ_hL0o4M20B4knEB6gbEQ==; S=spreadsheet_forms=J-koCMoW-zswMl7m9XrfpxVG9bQ7nGUmBbOGr4kc2tw; NID=511=c9D4VsAoQI3wrtUav5Bats8PAgPr05b5yAA9dxGYBd2DH5SHS1wHwB_Po8sG4V4qo3dakP22K0xhWz69Z5EpoJgKOQVaEEzUvzjiJeIyacHbP_dj_zR3CFiaxvyVbj-7sXi81Ruo9a_xfRkpu9Fa26KTA0a62PRVZJdlYNgiggA");
         var collection = new List<KeyValuePair<string, string>>();
        collection.Add(new("entry.992842650", record.ATT1));
        collection.Add(new("entry.979303534", record.ATT2));
        collection.Add(new("entry.1628285755", record.ATT3));
        collection.Add(new("entry.1289848878", record.ATT4));
        collection.Add(new("entry.1138227195", record.PBC1));
        collection.Add(new("entry.1752112283", record.PBC2));
        collection.Add(new("entry.1555359621", record.PBC3));
        collection.Add(new("entry.1977374260", record.PBC4));
        collection.Add(new("entry.968195878", record.SN1));
        collection.Add(new("entry.2081872828", record.SN2));
        collection.Add(new("entry.1933664240", record.SN3));
        collection.Add(new("entry.1047452769", record.SN4));
        collection.Add(new("entry.1776591293", record.PI1));
        collection.Add(new("entry.2049598084", record.PI2));
        collection.Add(new("entry.1319117585", record.PI3));
        collection.Add(new("entry.163499386", record.PI4));
        collection.Add(new("entry.326809469", record.PF1));
        collection.Add(new("entry.1364252741", record.PF2));
        collection.Add(new("entry.1603548573", record.PF3));
        collection.Add(new("entry.2035868142", record.PF4));
        collection.Add(new("entry.708017689", record.PF5));
        collection.Add(new("entry.686935045", record.PD1));
        collection.Add(new("entry.1308911055", record.PD2));
        collection.Add(new("entry.1707862952", record.PD3));
        collection.Add(new("entry.1376162376", record.PTA1));
        collection.Add(new("entry.1729176492", record.PTA2));
        collection.Add(new("entry.1954519991", record.PTA3));
        collection.Add(new("entry.1382364500", record.EE1));
        collection.Add(new("entry.1030231987", record.EE2));
        collection.Add(new("entry.2002430899", record.EE3));
        collection.Add(new("entry.607790811", record.EE4));
        collection.Add(new("entry.371912723", record.SEE1));
        collection.Add(new("entry.1027382505", record.SEE2));
        collection.Add(new("entry.381599551", record.SEE3));
        collection.Add(new("entry.550335766", record.SEE4));
        collection.Add(new("entry.1169149671", record.SEE5));
        collection.Add(new("entry.2127476790", record.SEE6));
        collection.Add(new("entry.521498416", record.GS1));
        collection.Add(new("entry.1209899142", record.GS2));
        collection.Add(new("entry.842054628", record.GS3));
        collection.Add(new("entry.671728547", record.GS4));
        collection.Add(new("entry.1505146042", record.FS1));
        collection.Add(new("entry.2004161738", record.FS2));
        collection.Add(new("entry.396296200", record.FS3));
        collection.Add(new("entry.165625810", record.FS4));
        collection.Add(new("entry.2051977415", record.FS5));
        collection.Add(new("entry.908437642", record.FS6));
        collection.Add(new("entry.945501304", record.EI1));
        collection.Add(new("entry.451797140", record.EI2));
        collection.Add(new("entry.308893472", record.EI3));
        collection.Add(new("entry.501872170", record.EI4));
        collection.Add(new("entry.563076998", record.EB1));
        collection.Add(new("entry.1734227998", record.EB2));
        collection.Add(new("entry.9391375", record.EB3));
        collection.Add(new("entry.1934790184", record.EB4));
        collection.Add(new("entry.61360731", record.EB5));
        collection.Add(new("entry.1578813126", record.EB6));
        collection.Add(new("entry.1424211217", record.EB7));
        collection.Add(new("entry.1334569098", record.EB8));
        
        collection.Add(new("partialResponse", $"[[[null,2034530046,[\"{record.Gender}\"],0],[null,942298180,[\"{record.Education}\"],0],[null,1051726225,[\"{record.Major}\"],0],[null,1860521396,[\"{record.AcademicYear}\"],0],[null,149585158,[\"{record.Area}\"],0]],null,\"4605578548585539409\"]"));
        collection.Add(new("fvv", "1"));
        collection.Add(new("pageHistory", "0,1,2"));
        collection.Add(new("fbzx", "4605578548585539409"));

        var content = new FormUrlEncodedContent(collection);
        request.Content = content;
        var response = await client.SendAsync(request);
       
        // Use the StatusCode and Response Content
        Console.WriteLine($"Status : {(int)response.StatusCode} {response.StatusCode.ToString()}");
       // Console.WriteLine($"Body : \n{await response.Content.ReadAsStringAsync()}");
        
    }

    public class Record
{
    public string STT { get; set; }
    public string Gender { get; set; }
    public string Education { get; set; }
    public string Major { get; set; }
    public string AcademicYear { get; set; }
    public string Area { get; set; }
    public string ATT1 { get; set; }
    public string ATT2 { get; set; }
    public string ATT3 { get; set; }
    public string ATT4 { get; set; }
    public string PBC1 { get; set; }
    public string PBC2 { get; set; }
    public string PBC3 { get; set; }
    public string PBC4 { get; set; }
    public string SN1 { get; set; }
    public string SN2 { get; set; }
    public string SN3 { get; set; }
    public string SN4 { get; set; }
    public string PI1 { get; set; }
    public string PI2 { get; set; }
    public string PI3 { get; set; }
    public string PI4 { get; set; }
    public string PF1 { get; set; }
    public string PF2 { get; set; }
    public string PF3 { get; set; }
    public string PF4 { get; set; }
    public string PF5 { get; set; }
    public string PD1 { get; set; }
    public string PD2 { get; set; }
    public string PD3 { get; set; }
    public string PTA1 { get; set; }
    public string PTA2 { get; set; }
    public string PTA3 { get; set; }
    public string EE1 { get; set; }
    public string EE2 { get; set; }
    public string EE3 { get; set; }
    public string EE4 { get; set; }
    public string SEE1 { get; set; }
    public string SEE2 { get; set; }
    public string SEE3 { get; set; }
    public string SEE4 { get; set; }
    public string SEE5 { get; set; }
    public string SEE6 { get; set; }
    public string GS1 { get; set; }
    public string GS2 { get; set; }
    public string GS3 { get; set; }
    public string GS4 { get; set; }
    public string FS1 { get; set; }
    public string FS2 { get; set; }
    public string FS3 { get; set; }
    public string FS4 { get; set; }
    public string FS5 { get; set; }
    public string FS6 { get; set; }
    public string EI1 { get; set; }
    public string EI2 { get; set; }
    public string EI3 { get; set; }
    public string EI4 { get; set; }
    public string EB1 { get; set; }
    public string EB2 { get; set; }
    public string EB3 { get; set; }
    public string EB4 { get; set; }
    public string EB5 { get; set; }
    public string EB6 { get; set; }
    public string EB7 { get; set; }
    public string EB8 { get; set; }
}






}