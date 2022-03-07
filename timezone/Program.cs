var timezones = TimeZoneInfo.GetSystemTimeZones();
foreach (var timezone in timezones)
{
    Console.WriteLine(timezone.Id);
    Console.WriteLine(timezone);
    Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezone));
    Console.WriteLine("---");
}

// Dateline Standard Time
// (UTC-12:00) Linha de Data Internacional Oeste
// 07/03/2022 00:03:57
// ---
// UTC-11
// (UTC-11:00) Tempo Universal Coordenado-11
// 07/03/2022 01:03:57
// ---
// Hawaiian Standard Time
// (UTC-10:00) Havaí
// 07/03/2022 02:03:57
// ---
// Aleutian Standard Time
// (UTC-10:00) Ilhas Aleutas
// 07/03/2022 02:03:57
// ---
// Marquesas Standard Time
// (UTC-09:30) Ilhas Marquesas
// 07/03/2022 02:33:57
// ---
// Alaskan Standard Time
// (UTC-09:00) Alasca
// 07/03/2022 03:03:57
// ---
// UTC-09
// (UTC-09:00) Tempo Universal Coordenado-09
// 07/03/2022 03:03:57
// ---
// Pacific Standard Time (Mexico)
// (UTC-08:00) Baja Califórnia
// 07/03/2022 04:03:57
// ---
// Pacific Standard Time
// (UTC-08:00) Hora do Pacífico (EUA e Canadá)
// 07/03/2022 04:03:57
// ---
// UTC-08
// (UTC-08:00) Tempo Universal Coordenado-08
// 07/03/2022 04:03:57
// ---
// US Mountain Standard Time
// (UTC-07:00) Arizona
// 07/03/2022 05:03:57
// ---
// Mountain Standard Time (Mexico)
// (UTC-07:00) Chihuahua, La Paz, Mazatlan
// 07/03/2022 05:03:57
// ---
// Mountain Standard Time
// (UTC-07:00) Hora das Montanhas (EUA e Canadá)
// 07/03/2022 05:03:57
// ---
// Yukon Standard Time
// (UTC-07:00) Yukon
// 07/03/2022 05:03:57
// ---
// Central America Standard Time
// (UTC-06:00) América Central
// 07/03/2022 06:03:57
// ---
// Central Standard Time (Mexico)
// (UTC-06:00) Guadalajara, Cidade do México, Monterrey
// 07/03/2022 06:03:57
// ---
// Central Standard Time
// (UTC-06:00) Hora Central (EUA e Canadá)
// 07/03/2022 06:03:57
// ---
// Easter Island Standard Time
// (UTC-06:00) Ilha da Páscoa
// 07/03/2022 07:03:57
// ---
// Canada Central Standard Time
// (UTC-06:00) Saskatchewan
// 07/03/2022 06:03:57
// ---
// SA Pacific Standard Time
// (UTC-05:00) Bogotá, Lima, Quito, Rio Branco
// 07/03/2022 07:03:57
// ---
// Eastern Standard Time (Mexico)
// (UTC-05:00) Chetumal
// 07/03/2022 07:03:57
// ---
// Haiti Standard Time
// (UTC-05:00) Haiti
// 07/03/2022 07:03:57
// ---
// Cuba Standard Time
// (UTC-05:00) Havana
// 07/03/2022 07:03:57
// ---
// Eastern Standard Time
// (UTC-05:00) Hora Oriental (EUA e Canadá)
// 07/03/2022 07:03:57
// ---
// US Eastern Standard Time
// (UTC-05:00) Indiana (Leste)
// 07/03/2022 07:03:57
// ---
// Turks And Caicos Standard Time
// (UTC-05:00) Turcos e Caicos
// 07/03/2022 07:03:57
// ---
// Paraguay Standard Time
// (UTC-04:00) Assunção
// 07/03/2022 09:03:57
// ---
// Venezuela Standard Time
// (UTC-04:00) Caracas
// 07/03/2022 08:03:57
// ---
// Central Brazilian Standard Time
// (UTC-04:00) Cuiabá
// 07/03/2022 08:03:57
// ---
// SA Western Standard Time
// (UTC-04:00) Georgetown, La Paz, Manaus, San Juan
// 07/03/2022 08:03:57
// ---
// Atlantic Standard Time
// (UTC-04:00) Hora do Atlântico (Canadá)
// 07/03/2022 08:03:57
// ---
// Pacific SA Standard Time
// (UTC-04:00) Santiago
// 07/03/2022 09:03:57
// ---
// Newfoundland Standard Time
// (UTC-03:30) Newfoundland
// 07/03/2022 08:33:57
// ---
// Tocantins Standard Time
// (UTC-03:00) Araguaina
// 07/03/2022 09:03:57
// ---
// E. South America Standard Time
// (UTC-03:00) Brasília
// 07/03/2022 09:03:57
// ---
// SA Eastern Standard Time
// (UTC-03:00) Caiena, Fortaleza
// 07/03/2022 09:03:57
// ---
// Argentina Standard Time
// (UTC-03:00) Cidade de Buenos Aires
// 07/03/2022 09:03:57
// ---
// Greenland Standard Time
// (UTC-03:00) Groenlândia
// 07/03/2022 09:03:57
// ---
// Montevideo Standard Time
// (UTC-03:00) Montevidéu
// 07/03/2022 09:03:57
// ---
// Magallanes Standard Time
// (UTC-03:00) Punta Arenas
// 07/03/2022 09:03:57
// ---
// Bahia Standard Time
// (UTC-03:00) Salvador
// 07/03/2022 09:03:57
// ---
// Saint Pierre Standard Time
// (UTC-03:00) São Pedro e Miquelon
// 07/03/2022 09:03:57
// ---
// Mid-Atlantic Standard Time
// (UTC-02:00) Atlântico Central - Antigo
// 07/03/2022 10:03:57
// ---
// UTC-02
// (UTC-02:00) Tempo Universal Coordenado-02
// 07/03/2022 10:03:57
// ---
// Azores Standard Time
// (UTC-01:00) Açores
// 07/03/2022 11:03:57
// ---
// Cape Verde Standard Time
// (UTC-01:00) Ilha de Cabo Verde
// 07/03/2022 11:03:57
// ---
// UTC
// (UTC) Tempo Universal Coordenado
// 07/03/2022 12:03:57
// ---
// GMT Standard Time
// (UTC+00:00) Dublin, Edinburgo, Lisboa, Londres
// 07/03/2022 12:03:57
// ---
// Greenwich Standard Time
// (UTC+00:00) Monróvia, Reykjavik
// 07/03/2022 12:03:57
// ---
// Sao Tome Standard Time
// (UTC+00:00) São Tomé
// 07/03/2022 12:03:57
// ---
// Morocco Standard Time
// (UTC+01:00) Casablanca
// 07/03/2022 13:03:57
// ---
// W. Europe Standard Time
// (UTC+01:00) Amsterdã, Berlim, Berna, Roma, Estocolmo, Viena
// 07/03/2022 13:03:57
// ---
// Central Europe Standard Time
// (UTC+01:00) Belgrado, Bratislava, Budapeste, Liubliana, Praga
// 07/03/2022 13:03:57
// ---
// Romance Standard Time
// (UTC+01:00) Bruxelas, Copenhague, Madri, Paris
// 07/03/2022 13:03:58
// ---
// W. Central Africa Standard Time
// (UTC+01:00) Centro-oeste da África
// 07/03/2022 13:03:58
// ---
// Central European Standard Time
// (UTC+01:00) Sarajevo, Skoplie, Varsóvia, Zagreb
// 07/03/2022 13:03:58
// ---
// Jordan Standard Time
// (UTC+02:00) Amã
// 07/03/2022 15:03:58
// ---
// GTB Standard Time
// (UTC+02:00) Atenas, Bucareste
// 07/03/2022 14:03:58
// ---
// Middle East Standard Time
// (UTC+02:00) Beirute
// 07/03/2022 14:03:58
// ---
// Egypt Standard Time
// (UTC+02:00) Cairo
// 07/03/2022 14:03:58
// ---
// Sudan Standard Time
// (UTC+02:00) Cartum
// 07/03/2022 14:03:58
// ---
// E. Europe Standard Time
// (UTC+02:00) Chisinau
// 07/03/2022 14:03:58
// ---
// Syria Standard Time
// (UTC+02:00) Damasco
// 07/03/2022 14:03:58
// ---
// West Bank Standard Time
// (UTC+02:00) Gaza, Hebron
// 07/03/2022 14:03:58
// ---
// South Africa Standard Time
// (UTC+02:00) Harare, Pretória
// 07/03/2022 14:03:58
// ---
// FLE Standard Time
// (UTC+02:00) Helsinque, Kiev, Riga, Sófia, Tallinn, Vilnius
// 07/03/2022 14:03:58
// ---
// Israel Standard Time
// (UTC+02:00) Jerusalém
// 07/03/2022 14:03:58
// ---
// South Sudan Standard Time
// (UTC+02:00) Juba
// 07/03/2022 14:03:58
// ---
// Kaliningrad Standard Time
// (UTC+02:00) Kaliningrado
// 07/03/2022 14:03:58
// ---
// Libya Standard Time
// (UTC+02:00) Trípoli
// 07/03/2022 14:03:58
// ---
// Namibia Standard Time
// (UTC+02:00) Windhoek
// 07/03/2022 14:03:58
// ---
// Arabic Standard Time
// (UTC+03:00) Bagdá
// 07/03/2022 15:03:58
// ---
// Turkey Standard Time
// (UTC+03:00) Istambul
// 07/03/2022 15:03:58
// ---
// Arab Standard Time
// (UTC+03:00) Kuwait, Riad
// 07/03/2022 15:03:58
// ---
// Belarus Standard Time
// (UTC+03:00) Minsk
// 07/03/2022 15:03:58
// ---
// Russian Standard Time
// (UTC+03:00) Moscou, São Petersburgo
// 07/03/2022 15:03:58
// ---
// E. Africa Standard Time
// (UTC+03:00) Nairóbi
// 07/03/2022 15:03:58
// ---
// Volgograd Standard Time
// (UTC+03:00) Volgogrado
// 07/03/2022 15:03:58
// ---
// Iran Standard Time
// (UTC+03:30) Teerã
// 07/03/2022 15:33:58
// ---
// Arabian Standard Time
// (UTC+04:00) Abu Dhabi, Mascate
// 07/03/2022 16:03:58
// ---
// Astrakhan Standard Time
// (UTC+04:00) Astrakhan, Ulyanovsk
// 07/03/2022 16:03:58
// ---
// Azerbaijan Standard Time
// (UTC+04:00) Baku
// 07/03/2022 16:03:58
// ---
// Caucasus Standard Time
// (UTC+04:00) Ierevan
// 07/03/2022 16:03:58
// ---
// Russia Time Zone 3
// (UTC+04:00) Izhevsk, Samara
// 07/03/2022 16:03:58
// ---
// Mauritius Standard Time
// (UTC+04:00) Port Louis
// 07/03/2022 16:03:58
// ---
// Saratov Standard Time
// (UTC+04:00) Saratov
// 07/03/2022 16:03:58
// ---
// Georgian Standard Time
// (UTC+04:00) Tbilisi
// 07/03/2022 16:03:58
// ---
// Afghanistan Standard Time
// (UTC+04:30) Cabul
// 07/03/2022 16:33:58
// ---
// West Asia Standard Time
// (UTC+05:00) Ashgabat, Tashkent
// 07/03/2022 17:03:58
// ---
// Ekaterinburg Standard Time
// (UTC+05:00) Ekaterimburgo
// 07/03/2022 17:03:58
// ---
// Pakistan Standard Time
// (UTC+05:00) Islamabad, Karachi
// 07/03/2022 17:03:58
// ---
// Qyzylorda Standard Time
// (UTC+05:00) Qyzylorda
// 07/03/2022 17:03:58
// ---
// India Standard Time
// (UTC+05:30) Chennai (Madras), Kolkata (Calcutá), Mumbai, Nova Délhi
// 07/03/2022 17:33:58
// ---
// Sri Lanka Standard Time
// (UTC+05:30) Sri Jayawardenepura
// 07/03/2022 17:33:58
// ---
// Nepal Standard Time
// (UTC+05:45) Katmandu
// 07/03/2022 17:48:58
// ---
// Central Asia Standard Time
// (UTC+06:00) Astana
// 07/03/2022 18:03:58
// ---
// Bangladesh Standard Time
// (UTC+06:00) Dacca
// 07/03/2022 18:03:58
// ---
// Omsk Standard Time
// (UTC+06:00) Omsk
// 07/03/2022 18:03:58
// ---
// Myanmar Standard Time
// (UTC+06:30) Yangon (Rangoon)
// 07/03/2022 18:33:58
// ---
// SE Asia Standard Time
// (UTC+07:00) Bancoc, Hanói, Jacarta
// 07/03/2022 19:03:58
// ---
// Altai Standard Time
// (UTC+07:00) Barnaul, Gorno-Altaysk
// 07/03/2022 19:03:58
// ---
// W. Mongolia Standard Time
// (UTC+07:00) Hovd
// 07/03/2022 19:03:58
// ---
// North Asia Standard Time
// (UTC+07:00) Krasnoyarsk
// 07/03/2022 19:03:58
// ---
// N. Central Asia Standard Time
// (UTC+07:00) Novosibirsk
// 07/03/2022 19:03:58
// ---
// Tomsk Standard Time
// (UTC+07:00) Tomsk
// 07/03/2022 19:03:58
// ---
// North Asia East Standard Time
// (UTC+08:00) Irkutsk
// 07/03/2022 20:03:58
// ---
// Singapore Standard Time
// (UTC+08:00) Kuala Lumpur, Cingapura
// 07/03/2022 20:03:58
// ---
// China Standard Time
// (UTC+08:00) Pequim, Chonquim, Hong Kong, Urumqui
// 07/03/2022 20:03:58
// ---
// W. Australia Standard Time
// (UTC+08:00) Perth
// 07/03/2022 20:03:58
// ---
// Taipei Standard Time
// (UTC+08:00) Taipé
// 07/03/2022 20:03:58
// ---
// Ulaanbaatar Standard Time
// (UTC+08:00) Ulaanbaatar
// 07/03/2022 20:03:58
// ---
// Aus Central W. Standard Time
// (UTC+08:45) Eucla
// 07/03/2022 20:48:58
// ---
// Transbaikal Standard Time
// (UTC+09:00) Chita
// 07/03/2022 21:03:58
// ---
// Tokyo Standard Time
// (UTC+09:00) Osaka, Sapporo, Tóquio
// 07/03/2022 21:03:58
// ---
// North Korea Standard Time
// (UTC+09:00) Pyongyang
// 07/03/2022 21:03:58
// ---
// Korea Standard Time
// (UTC+09:00) Seul
// 07/03/2022 21:03:58
// ---
// Yakutsk Standard Time
// (UTC+09:00) Yakutsk
// 07/03/2022 21:03:58
// ---
// Cen. Australia Standard Time
// (UTC+09:30) Adelaide
// 07/03/2022 22:33:58
// ---
// AUS Central Standard Time
// (UTC+09:30) Darwin
// 07/03/2022 21:33:58
// ---
// E. Australia Standard Time
// (UTC+10:00) Brisbane
// 07/03/2022 22:03:58
// ---
// AUS Eastern Standard Time
// (UTC+10:00) Camberra, Melbourne, Sydney
// 07/03/2022 23:03:58
// ---
// West Pacific Standard Time
// (UTC+10:00) Guam, Port Moresby
// 07/03/2022 22:03:58
// ---
// Tasmania Standard Time
// (UTC+10:00) Hobart
// 07/03/2022 23:03:58
// ---
// Vladivostok Standard Time
// (UTC+10:00) Vladivostok
// 07/03/2022 22:03:58
// ---
// Lord Howe Standard Time
// (UTC+10:30) Ilha Lord Howe
// 07/03/2022 23:03:58
// ---
// Russia Time Zone 10
// (UTC+11:00) Chokurdakh
// 07/03/2022 23:03:58
// ---
// Bougainville Standard Time
// (UTC+11:00) Ilha Bougainville
// 07/03/2022 23:03:58
// ---
// Norfolk Standard Time
// (UTC+11:00) Ilha Norfolk
// 08/03/2022 00:03:58
// ---
// Central Pacific Standard Time
// (UTC+11:00) Ilhas Salomão, Nova Caledônia
// 07/03/2022 23:03:58
// ---
// Magadan Standard Time
// (UTC+11:00) Magadã
// 07/03/2022 23:03:58
// ---
// Sakhalin Standard Time
// (UTC+11:00) Sakhalin
// 07/03/2022 23:03:58
// ---
// Russia Time Zone 11
// (UTC+12:00) Anadyr, Petropavlovsk-Kamchatsky
// 08/03/2022 00:03:58
// ---
// New Zealand Standard Time
// (UTC+12:00) Auckland, Wellington
// 08/03/2022 01:03:58
// ---
// Fiji Standard Time
// (UTC+12:00) Fiji
// 08/03/2022 00:03:58
// ---
// Kamchatka Standard Time
// (UTC+12:00) Petropavlovsk-Kamchatsky - Antigo
// 08/03/2022 00:03:58
// ---
// UTC+12
// (UTC+12:00) Tempo Universal Coordenado+12
// 08/03/2022 00:03:58
// ---
// Chatham Islands Standard Time
// (UTC+12:45) Ilhas Chatham
// 08/03/2022 01:48:58
// ---
// Tonga Standard Time
// (UTC+13:00) Nuku'alofa
// 08/03/2022 01:03:58
// ---
// Samoa Standard Time
// (UTC+13:00) Samoa
// 08/03/2022 02:03:58
// ---
// UTC+13
// (UTC+13:00) Tempo Universal Coordenado+13
// 08/03/2022 01:03:58
// ---
// Line Islands Standard Time
// (UTC+14:00) Ilha Kiritimati
// 08/03/2022 02:03:58
// ---