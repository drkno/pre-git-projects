using System.ComponentModel;

namespace MetServiceAPI.MetService
{
    public enum Urban
    {
        Auckland = 0,
        AucklandCentral = 1,
        NorthShore = 2,
        Waitakere = 3,
        Hunua = 4,
        Manukau = 5,
        Masterton = 6,
        TeKuiti = 7,
        Dannevirke = 8,
        Napier = 9,
        Thames = 10,
        Dargaville = 11,
        NewPlymouth = 12,
        Tokoroa = 13,
        Gisborne = 14,
        PalmerstonN = 15,
        Wanganui = 16,
        Hamilton = 17,
        Paraparaumu = 18,
        Wellington = 19,
        WellingtonCity = 20,
        WesternHills = 21,
        LowerHutt = 22,
        UpperHutt = 23,
        Wainuiomata = 24,
        Porirua = 25,
        Kapiti = 26,
        Hastings = 27,
        Rotorua = 28,
        Whakatane = 29,
        Kaitaia = 30,
        Taumarunui = 31,
        Whangarei = 32,
        Kerikeri = 33,
        Taupo = 34,
        Whitianga = 35,
        Levin = 36,
        Tauranga = 37,
        Alexandra = 38,
        Kaikoura = 39,
        Ashburton = 40,
        Motueka = 41,
        Blenheim = 42,
        Nelson = 43,
        Christchurch = 44,
        ChristchurchEasternSuburbs = 45,
        PortHills = 46,
        BanksPeninsula = 47,
        Oamaru = 48,
        Dunedin = 49,
        Queenstown = 50,
        Gore = 51,
        Reefton = 52,
        Greymouth = 53,
        Timaru = 54,
        Hokitika = 55,
        Wanaka = 56,
        Invercargill = 57,
        Westport = 58
    }

    public enum Rural
    {
        Northland = 0,
        Taumarunui = 1,
        Auckland = 2,
        Taihape = 3,
        CoromandelPeninsula = 4,
        Wanganui = 5,
        Waikato = 6,
        Manawatu = 7,
        Waitomo = 8,
        KapitiHorowhenua = 9,
        Rotorua = 10,
        Wairarapa = 11,
        BayofPlenty = 12,
        Wellington = 13,
        Taupo = 14,
        Gisborne = 15,
        HawkesBay = 16,
        Taranaki = 17,
        Marlborough = 18,
        Nelson = 19,
        Buller = 20,
        Westland = 21,
        CanterburyPlains = 22,
        Christchurch = 23,
        NorthOtago = 24,
        CentralOtago = 25,
        Dunedin = 26,
        Clutha = 27,
        Southland = 28,
        Levin = 29,
        Otaki = 30,
        Whitianga = 31,
        Thames = 32,
        Kerikeri = 33,
        Kaitaia = 34,
        Kaikohe = 35,
        Dargaville = 36,
        Whangarei = 37,
        Warkworth = 38,
        Leigh = 39,
        Kumeu = 40,
        Pukekohe = 42,
        Paeroa = 46,
        Matamata = 48,
        Hamilton = 49,
        TeAwamutu = 50,
        Tokoroa = 52,
        TeKuiti = 54,
        TePuke = 58,
        Tauranga = 59,
        Whakatane = 60,
        Ruatoria = 64,
        Mahia = 68,
        EasternRangitaiki = 70,
        Hastings = 72,
        Waipukurau = 74,
        NewPlymouth = 76,
        Hawera = 78,
        Waiouru = 82,
        Ohakea = 86,
        PalmerstonNorth = 87,
        Dannevirke = 90,
        Masterton = 92,
        Castlepoint = 94,
        Martinborough = 96,
        Judgeford = 102,
        OhariuValley = 104,
        Wainuiomata = 106,
        Blenheim = 108,
        Kaikoura = 110,
        Takaka = 112,
        Motueka = 114,
        Westport = 116,
        Greymouth = 117,
        Hokitika = 118,
        Haast = 120,
        Twizel = 121,
        Waipara = 122,
        Darfield = 124,
        Rakaia = 126,
        Ashburton = 127,
        Timaru = 128,
        Marshland = 130,
        Lincoln = 132,
        HillTop = 134,
        Oamaru = 136,
        Alexandra = 139,
        Middlemarch = 140,
        Waitati = 142,
        Mosgiel = 144,
        NuggetPoint = 146,
        Gore = 147,
        TeAnau = 148,
        Queenstown = 149,
        Lumsden = 150,

    }

    public class TownsCitiesRural
    {
        public static string RuralToCode(Rural rural)
        {
            switch (rural)
            {
                case Rural.Northland: return "northland";
                case Rural.Taumarunui: return "taumarunui";
                case Rural.Auckland: return "auckland";
                case Rural.Taihape: return "taihape";
                case Rural.CoromandelPeninsula: return "coromandelpeninsula";
                case Rural.Wanganui: return "wanganui";
                case Rural.Waikato: return "waikato";
                case Rural.Manawatu: return "manawatu";
                case Rural.Waitomo: return "waitomo";
                case Rural.KapitiHorowhenua: return "kapitihorowhenua";
                case Rural.Rotorua: return "rotorua";
                case Rural.Wairarapa: return "wairarapa";
                case Rural.BayofPlenty: return "bay-of-plenty";
                case Rural.Wellington: return "wellington";
                case Rural.Taupo: return "taupo";
                case Rural.Gisborne: return "gisborne";
                case Rural.HawkesBay: return "hawkes-bay";
                case Rural.Taranaki: return "taranaki";
                case Rural.Marlborough: return "marlborough";
                case Rural.Nelson: return "nelson";
                case Rural.Buller: return "buller";
                case Rural.Westland: return "westland";
                case Rural.CanterburyPlains: return "canterbury-plains";
                case Rural.Christchurch: return "christchurch";
                case Rural.NorthOtago: return "north-otago";
                case Rural.CentralOtago: return "central-otago";
                case Rural.Dunedin: return "dunedin";
                case Rural.Clutha: return "clutha";
                case Rural.Southland: return "southland";
                case Rural.Levin: return "levin";
                case Rural.Otaki: return "otaki";
                case Rural.Whitianga: return "whitianga";
                case Rural.Thames: return "thames";
                case Rural.Kerikeri: return "kerikeri";
                case Rural.Kaitaia: return "kaitaia";
                case Rural.Kaikohe: return "kaikohe";
                case Rural.Dargaville: return "dargaville";
                case Rural.Whangarei: return "whangarei";
                case Rural.Warkworth: return "warkworth";
                case Rural.Leigh: return "leigh";
                case Rural.Kumeu: return "kumeu";
                case Rural.Pukekohe: return "pukekohe";
                case Rural.Paeroa: return "paeroa";
                case Rural.Matamata: return "matamata";
                case Rural.Hamilton: return "hamilton";
                case Rural.TeAwamutu: return "te-awamutu";
                case Rural.Tokoroa: return "tokoroa";
                case Rural.TeKuiti: return "te-kuiti";
                case Rural.Tauranga: return "tauranga";
                case Rural.Whakatane: return "whakatane";
                case Rural.Ruatoria: return "ruatoria";
                case Rural.Mahia: return "mahia";
                case Rural.EasternRangitaiki: return "eastern-rangitaiki";
                case Rural.Hastings: return "hastings";
                case Rural.Waipukurau: return "waipukurau";
                case Rural.NewPlymouth: return "new-plymouth";
                case Rural.Hawera: return "hawera";
                case Rural.Waiouru: return "waiouru";
                case Rural.Ohakea: return "ohakea";
                case Rural.PalmerstonNorth: return "palmerston-north";
                case Rural.Dannevirke: return "dannevirke";
                case Rural.Masterton: return "masterton";
                case Rural.Castlepoint: return "castlepoint";
                case Rural.Martinborough: return "martinborough";
                case Rural.Judgeford: return "judgeford";
                case Rural.OhariuValley: return "ohariu-valley";
                case Rural.Wainuiomata: return "wainuiomata";
                case Rural.Blenheim: return "blenheim";
                case Rural.Kaikoura: return "kaikoura";
                case Rural.Takaka: return "takaka";
                case Rural.Motueka: return "motueka";
                case Rural.Westport: return "westport";
                case Rural.Greymouth: return "greymouth";
                case Rural.Hokitika: return "hokitika";
                case Rural.Haast: return "haast";
                case Rural.Twizel: return "twizel";
                case Rural.Waipara: return "waipara";
                case Rural.Darfield: return "darfield";
                case Rural.Rakaia: return "rakaia";
                case Rural.Ashburton: return "ashburton";
                case Rural.Timaru: return "timaru";
                case Rural.Marshland: return "marshland";
                case Rural.Lincoln: return "lincoln";
                case Rural.HillTop: return "hill-top";
                case Rural.Oamaru: return "oamaru";
                case Rural.Alexandra: return "alexandra";
                case Rural.Middlemarch: return "middlemarch";
                case Rural.Waitati: return "waitati";
                case Rural.Mosgiel: return "mosgiel";
                case Rural.NuggetPoint: return "nugget-point";
                case Rural.Gore: return "gore";
                case Rural.TeAnau: return "te-anau";
                case Rural.Queenstown: return "queenstown";
                case Rural.Lumsden: return "lumsden";
                default:  throw new InvalidEnumArgumentException("rural", (int)rural, typeof(Rural));
            }
        }
        public static string UrbanToCode(Urban urban)
        {
            switch (urban)
            {
                case Urban.Auckland: return "auckland";
                case Urban.AucklandCentral: return "auckland-central";
                case Urban.NorthShore: return "north-shore";
                case Urban.Waitakere: return "waitakere";
                case Urban.Hunua: return "hunua";
                case Urban.Manukau: return "manukau";
                case Urban.Masterton: return "masterton";
                case Urban.TeKuiti: return "tekuiti";
                case Urban.Dannevirke: return "dannevirke";
                case Urban.Napier: return "napier";
                case Urban.Thames: return "thames";
                case Urban.Dargaville: return "dargaville";
                case Urban.NewPlymouth: return "new-plymouth";
                case Urban.Tokoroa: return "tokoroa";
                case Urban.Gisborne: return "gisborne";
                case Urban.PalmerstonN: return "palmerston-north";
                case Urban.Wanganui: return "wanganui";
                case Urban.Hamilton: return "hamilton";
                case Urban.Paraparaumu: return "paraparaumu";
                case Urban.Wellington: return "wellington";
                case Urban.WellingtonCity: return "wellington-city";
                case Urban.WesternHills: return "western-hills";
                case Urban.LowerHutt: return "lower-hutt";
                case Urban.UpperHutt: return "upper-hutt";
                case Urban.Wainuiomata: return "wainuiomata";
                case Urban.Porirua: return "porirua";
                case Urban.Kapiti: return "kapiti";
                case Urban.Hastings: return "hastings";
                case Urban.Rotorua: return "rotorua";
                case Urban.Whakatane: return "whakatane";
                case Urban.Kaitaia: return "kaitaia";
                case Urban.Taumarunui: return "taumarunui";
                case Urban.Whangarei: return "whangarei";
                case Urban.Kerikeri: return "kerikeri";
                case Urban.Taupo: return "taupo";
                case Urban.Whitianga: return "whitianga";
                case Urban.Levin: return "levin";
                case Urban.Tauranga: return "tauranga";
                case Urban.Alexandra: return "alexandra";
                case Urban.Kaikoura: return "kaikoura";
                case Urban.Ashburton: return "ashburton";
                case Urban.Motueka: return "motueka";
                case Urban.Blenheim: return "blenheim";
                case Urban.Nelson: return "nelson";
                case Urban.Christchurch: return "christchurch";
                case Urban.ChristchurchEasternSuburbs: return "eastern-suburbs";
                case Urban.PortHills: return "port-hills";
                case Urban.BanksPeninsula: return "banks-peninsula";
                case Urban.Oamaru: return "oamaru";
                case Urban.Dunedin: return "dunedin";
                case Urban.Queenstown: return "queenstown";
                case Urban.Gore: return "gore";
                case Urban.Reefton: return "reefton";
                case Urban.Greymouth: return "greymouth";
                case Urban.Timaru: return "timaru";
                case Urban.Hokitika: return "hokitika";
                case Urban.Wanaka: return "wanaka";
                case Urban.Invercargill: return "invercargill";
                case Urban.Westport: return "westport";
                default: throw new InvalidEnumArgumentException("urban", (int)urban, typeof(Urban));
            }
        }
    }
}
