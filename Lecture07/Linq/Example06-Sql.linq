<Query Kind="Statements">
  <Connection>
    <ID>62f14ba5-efe2-4bd5-8eba-7f24fbd341fd</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Server>localhost</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>biblio</Database>
    <NoPluralization>true</NoPluralization>
  </Connection>
</Query>

Knyga.Where(k => k.Metai < 2007).Dump();

//Knyga.Where(k => k.Metai < 2007).Select(k => new { k.ISBN, Title = k.Pavadinimas, Publisher = k.Leidykla, Year = k.Metai }).Dump();

//Knyga.Where(k => k.Metai < 2007).Where(k => new Regex("[a-z]+").IsMatch(k.Pavadinimas)).Dump();

//Knyga.Where(k => k.Metai < 2007).ToList().Where(k => new Regex("[a-z]+").IsMatch(k.Pavadinimas)).Dump();