# Emplo_RecruitmentProject

Projekt realizuje zadania rekrutacyjne firmy Emplo dla stanowiska .NET Developer.  
Kod został przygotowany z uwzględnieniem zasad czystego kodu, SOLID i programowania obiektowego.

---

## Zadanie 1
Określenie, czy dany pracownik jest przełożonym dowolnego rzędu dla innego pracownika oraz na jakim poziomie.  
Logika oparta na strukturze powiązań pracowników.

**Przykład użycia:**
```csharp
var structures = employeeStructureService.FillEmployeesStructure(employees);
var level = employeeStructureService.GetSuperiorRowOfEmployee(3, 1); // np. 2
```
**Pliki w projekcie:**
- `Models/Employee.cs` – model pracownika
- `Models/EmployeeStructure.cs` – model relacji
- `Services/EmployeeStructureService.cs` – logika wypełniania struktury i sprawdzania rzędu przełożonego

---

## Zadanie 2
Zapytania do bazy danych dotyczące urlopów:
- pracownicy z urlopami w danym zespole i roku
- liczba użytych dni urlopowych w bieżącym roku
- zespoły bez urlopów w danym roku

**Przykłady użycia:**
```csharp
// a) Pracownicy z zespołu ".NET" z urlopem w 2019
await vacationQueries.GetEmployeesWithVacationsByTeamAndYearAsync(".NET", 2019);

// b) Liczba użytych dni urlopowych w bieżącym roku
await vacationQueries.GetUsedVacationDaysForCurrentYearAsync();

// c) Zespoły bez urlopów w 2019
await vacationQueries.GetTeamsWithoutVacationsInYearAsync(2019);
```
**Pliki w projekcie:**
- `Queries/VacationQueries.cs` – implementacja metod zapytań
- `Models/VacationReportModel.cs` – model wyników raportów
- `Models/Employee.cs`, `Models/Vacation.cs`, `Models/Team.cs`, `Models/VacationPackage.cs` – modele danych

---

## Zadanie 3
Liczenie liczby wolnych dni urlopu dla pracownika na podstawie przydzielonych dni i już wykorzystanych pełnych urlopów.

**Przykład użycia:**
```csharp
var freeDays = vacationService.CountFreeDaysForEmployee(employeeVacationContext);
```
**Pliki w projekcie:**
- `Models/EmployeeVacationContext.cs` – kontekst danych
- `Models/Vacation.cs`, `Models/VacationPackage.cs` – dane urlopowe
- `Services/VacationService.cs` – metoda `CountFreeDaysForEmployee`

---

## Zadanie 4
Sprawdzenie, czy pracownik może wziąć urlop w podanym terminie.

**Przykład użycia:**
```csharp
var canRequest = vacationService.CanRequestVacation(employeeVacationContext);
```
**Pliki w projekcie:**
- `Services/VacationService.cs` – metoda `CanRequestVacation`
- `Models/EmployeeVacationContext.cs` – dane wejściowe

---

## Zadanie 5
Testy jednostkowe logiki urlopowej:
- `employee_can_request_vacation`
- `employee_cant_request_vacation`

**Pliki w projekcie:**
- `Emplo_RecruitmentProject.Tests/VacationServiceTests.cs` – testy
- `Emplo_RecruitmentProject.Tests/TestData/MockData.cs` – dane testowe

---

## Zadanie 6
Trzy sposoby optymalizacji liczby zapytań SQL w przypadku bezpośredniego pobierania danych z bazy:
1. **Projekcja do DTO w jednym zapytaniu** – zwracanie tylko potrzebnych pól w obiekcie wynikowym, unikanie N+1.
2. **Filtrowanie i agregacja po stronie bazy** – ograniczenie liczby wierszy i kolumn przesyłanych do aplikacji.
3. **Wyłączenie lazy loadingu i jawne ładowanie danych** – pełna kontrola nad liczbą zapytań.

---
