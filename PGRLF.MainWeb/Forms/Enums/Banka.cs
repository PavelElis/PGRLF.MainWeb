using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum Banka
    {

        [Display(Name = "Komerční banka, a.s." + " (0100)")]
        KomercniBanka,
        [Display(Name = "Československá obchodní banka, a.s." + " (0300)")]
        CeskoslovenskaObchodniBanka,
        [Display(Name = "GE Money Bank, a.s." + " (0600)")]
        GEMoneyBank,
        [Display(Name = "Česká národní banka" + " (0710)")]
        CeskaNarodniBanka,
        [Display(Name = "Česká spořitelna, a.s." + " (0800)")]
        CeskaSporitelna,
        [Display(Name = "Fio banka, a.s." + "(2010)")]
        FioBanka,
        [Display(Name = "Bank of Tokyo-Mitsubishi UFJ (Holland) N.V. Prague Branch, organizační složka" + " (2020)")]
        BankOfTokyo,
        [Display(Name = "AKCENTA, spořitelní a úvěrní družstvo" + " (2030)")]
        Akcenta,
        [Display(Name = "Citfin, spořitelní družstvo" + " (2060)")]
        Citfin,
        [Display(Name = "Moravský Peněžní Ústav – spořitelní družstvo" + " (2070)")]
        MoravskyPenezniUstav,
        [Display(Name = "Hypoteční banka, a.s." + " (2100)")]
        HypotecniBanka,
        [Display(Name = "Peněžní dům, spořitelní družstvo" + " (2200)")]
        PenezniDum,
        [Display(Name = "ERB bank, a.s." + " (2210)")]
        ERBBank,
        [Display(Name = "Artesa, spořitelní družstvo" + " (2220)")]
        Artesa,
        [Display(Name = "Poštová banka, a.s., pobočka Česká republika" + " (2240)")]
        PostovnaBanka,
        [Display(Name = "Záložna CREDITAS, spořitelní družstvo" + " (2250)")]
        ZaloznaCreditas,
        [Display(Name = "ANO spořitelní družstvo" + " (2260)")]
        ANOSpotrebniDruzstvi,
        [Display(Name = "ZUNO BANK AG, organizační složka" + " (2310)")]
        ZunoBankAG,
        [Display(Name = "Citibank Europe plc, organizační složka" + " (2600)")]
        CitibankEurope,
        [Display(Name = "UniCredit Bank Czech Republic, a.s." + " (2700)")]
        UniCreditBank,
        [Display(Name = "Air Bank a.s." + " (3030)")]
        AirBank,
        [Display(Name = "ING Bank N.V." + " (3500)")]
        INGBank,
        [Display(Name = "Expobank CZ a.s." + " (4000)")]
        Expobank,
        [Display(Name = "Českomoravská záruční a rozvojová banka, a.s." + " (4300)")]
        CeskomoravskaZarucniARozvojovaBanka,
        [Display(Name = "The Royal Bank of Scotland plc, organizační složka" + "(5400)")]
        TheRoyalBankOfScotland,
        [Display(Name = "Raiffeisenbank a.s." + " (5500)")]
        Raiffeisenbank,
        [Display(Name = "J & T Banka, a.s." + " (5800)")]
        JandTBanka,
        [Display(Name = "PPF banka a.s." + " (6000)")]
        PPFBanka,
        [Display(Name = "Equa bank a.s." + " (6100)")]
        EquaBank,
        [Display(Name = "COMMERZBANK Aktiengesellschaft, pobočka Praha" + " (6200)")]
        CommerzbankAktiengesellschaft,
        [Display(Name = "mBank S.A., organizační složka" + " (6210)")]
        MBank,
        [Display(Name = "BNP Paribas Fortis SA/NV, pobočka Česká republika" + " (6300)")]
        BMPParibasFortis,
        [Display(Name = "Všeobecná úverová banka a.s., pobočka Praha" + " (6700)")]
        VseobecnaUverovaBanka,
        [Display(Name = "Sberbank CZ, a.s." + " (6800)")]
        Sberbank,
        [Display(Name = "Deutsche Bank A.G. Filiale Prag" + " (7910)")]
        DeutscheBank,
        [Display(Name = "Waldviertler Sparkasse Bank AG" + " (7940)")]
        WaldviertlerSparkasseBank,
        [Display(Name = "Raiffeisen stavební spořitelna a.s." + " (7950)")]
        RaiffeisenStavebniSporitelna,
        [Display(Name = "Českomoravská stavební spořitelna, a.s." + " (7960)")]
        CeskomoravskaStavebniSporitelna,
        [Display(Name = "Wüstenrot-stavební spořitelna a.s." + " (7970)")]
        WustenrotStavebniSporitelna,
        [Display(Name = "Wüstenrot hypoteční banka a.s." + " (7980)")]
        WustenrotHypotecniBanka,
        [Display(Name = "Modrá pyramida stavební spořitelna, a.s." + " (7990)")]
        ModraPyramidaStavebniSporitelna,
        [Display(Name = "Raiffeisenbank im Stiftland eG pobočka Cheb, odštěpný závod" + " (8030)")]
        RaiffeisenbankImStiftland,
        [Display(Name = "Oberbank AG pobočka Česká republika" + "(8040)")]
        Oberbank,
        [Display(Name = "Stavební spořitelna České spořitelny, a.s." + " (8060)")]
        StavebniSporitelnaCeskeSporitelny,
        [Display(Name = "Česká exportní banka, a.s." + " (8090)")]
        CeskaExportniBanka,
        [Display(Name = "HSBC Bank plc - pobočka Praha" + " (8150)")]
        HSBCBank,
        [Display(Name = "PRIVAT BANK AG der Raiffeisenlandesbank Oberösterreich v České republice" + " (8200)")]
        PrivatBank,
        [Display(Name = "Payment Execution s.r.o." + " (8220)")]
        PaymentExecution,
        [Display(Name = "EEPAYS s.r.o." + " (8230)")]
        EEPays,
        [Display(Name = "Družstevní záložna Kredit" + " (8240)")]
        DruzstevniZaloznaKredit
    }
}