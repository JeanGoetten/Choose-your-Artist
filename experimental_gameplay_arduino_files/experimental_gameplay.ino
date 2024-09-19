int buttonA = 2;  // Botão A no pino 2
int buttonB = 3;  // Botão B no pino 3

void setup() {
  Serial.begin(9600);    // Inicializa a comunicação serial
  pinMode(buttonA, INPUT_PULLUP);  // Configura o pino do botão A
  pinMode(buttonB, INPUT_PULLUP);  // Configura o pino do botão B
}

void loop() {
  if (digitalRead(buttonA) == LOW) {  // Verifica se o botão A foi pressionado
    Serial.println("A");
    delay(300);  // Evita múltiplas leituras do mesmo clique
  }
  
  if (digitalRead(buttonB) == LOW) {  // Verifica se o botão B foi pressionado
    Serial.println("B");
    delay(300);  // Evita múltiplas leituras do mesmo clique
  }
}
