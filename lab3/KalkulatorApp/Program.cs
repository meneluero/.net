using KalkulatorApp;

Calculator kalkulator = new Calculator();
ScientificCalculator naukowy = new ScientificCalculator(kalkulator);
CalculatorService serwis = new CalculatorService(naukowy);

serwis.Run();