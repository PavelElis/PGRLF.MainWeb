using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class Banky
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var zoznamBank = new string[]
            {
               "Komerční banka, a.s."                                                                +" (0100)",
               "Československá obchodní banka, a.s."                                                 +" (0300)",
               "GE Money Bank, a.s."                                                                 +" (0600)",
               "Česká národní banka"                                                                 +" (0710)",
               "Česká spořitelna, a.s."                                                              +" (0800)",
               "Fio banka, a.s."                                                                     +" (2010)",
               "Bank of Tokyo-Mitsubishi UFJ (Holland) N.V. Prague Branch, organizační složka"       +" (2020)",
               "AKCENTA, spořitelní a úvěrní družstvo"                                               +" (2030)",
               "Citfin, spořitelní družstvo"                                                         +" (2060)",
               "Moravský Peněžní Ústav – spořitelní družstvo"                                        +" (2070)",
               "Hypoteční banka, a.s."                                                               +" (2100)",
               "Peněžní dům, spořitelní družstvo"                                                    +" (2200)",
               "ERB bank, a.s."                                                                      +" (2210)",
               "Artesa, spořitelní družstvo"                                                         +" (2220)",
               "Poštová banka, a.s., pobočka Česká republika"                                        +" (2240)",
               "Záložna CREDITAS, spořitelní družstvo"                                               +" (2250)",
               "ANO spořitelní družstvo"                                                             +" (2260)",
               "ZUNO BANK AG, organizační složka"                                                    +" (2310)",
               "Citibank Europe plc, organizační složka"                                             +" (2600)",
               "UniCredit Bank Czech Republic, a.s."                                                 +" (2700)",
               "Air Bank a.s."                                                                       +" (3030)",
               "ING Bank N.V."                                                                       +" (3500)",
               "Expobank CZ a.s."                                                                    +" (4000)",
               "Českomoravská záruční a rozvojová banka, a.s."                                       +" (4300)",
               "The Royal Bank of Scotland plc, organizační složka"                                  +" (5400)",
               "Raiffeisenbank a.s."                                                                 +" (5500)",
               "J & T Banka, a.s."                                                                   +" (5800)",
               "PPF banka a.s."                                                                      +" (6000)",
               "Equa bank a.s."                                                                      +" (6100)",
               "COMMERZBANK Aktiengesellschaft, pobočka Praha"                                       +" (6200)",
               "mBank S.A., organizační složka"                                                      +" (6210)",
               "BNP Paribas Fortis SA/NV, pobočka Česká republika"                                   +" (6300)",
               "Všeobecná úverová banka a.s., pobočka Praha"                                         +" (6700)",
               "Sberbank CZ, a.s."                                                                   +" (6800)",
               "Deutsche Bank A.G. Filiale Prag"                                                     +" (7910)",
               "Waldviertler Sparkasse Bank AG"                                                      +" (7940)",
               "Raiffeisen stavební spořitelna a.s."                                                 +" (7950)",
               "Českomoravská stavební spořitelna, a.s."                                             +" (7960)",
               "Wüstenrot-stavební spořitelna a.s."                                                  +" (7970)",
               "Wüstenrot hypoteční banka a.s."                                                      +" (7980)",
               "Modrá pyramida stavební spořitelna, a.s."                                            +" (7990)",
               "Raiffeisenbank im Stiftland eG pobočka Cheb, odštěpný závod"                         +" (8030)",
               "Oberbank AG pobočka Česká republika"                                                 +" (8040)",
               "Stavební spořitelna České spořitelny, a.s."                                          +" (8060)",
               "Česká exportní banka, a.s."                                                          +" (8090)",
               "HSBC Bank plc - pobočka Praha"                                                       +" (8150)",
               "PRIVAT BANK AG der Raiffeisenlandesbank Oberösterreich v České republice"            +" (8200)",
               "Payment Execution s.r.o."                                                            +" (8220)",
               "EEPAYS s.r.o."                                                                       +" (8230)",
               "Družstevní záložna Kredit"                                                           +" (8240)" 
            };
            var zoznamKodov = new string[]
            {
                "0100",
                "0300",
                "0600",
                "0710",
                "0800",
                "2010",
                "2020",
                "2030",
                "2060",
                "2070",
                "2100",
                "2200",
                "2210",
                "2220",
                "2240",
                "2250",
                "2260",
                "2310",
                "2600",
                "2700",
                "3030",
                "3500",
                "4000",
                "4300",
                "5400",
                "5500",
                "5800",
                "6000",
                "6100",
                "6200",
                "6210",
                "6300",
                "6700",
                "6800",
                "7910",
                "7940",
                "7950",
                "7960",
                "7970",
                "7980",
                "7990",
                "8030",
                "8040",
                "8060",
                "8090",
                "8150",
                "8200",
                "8220",
                "8230",
                "8240"
            };

            var returnList = new List<SelectListItem>();

            for (int i = 0; i < zoznamBank.Length; i++)
            {
                returnList.Add(new SelectListItem() {Text = zoznamBank[i], Value = zoznamKodov[i]});
            }
            return returnList;
        }
    }
}