#include <MOTOR.h>

int state =0;
void setup() {
  // Setup A and B Motor Pins on Shield
  motor.begin();

  // Defualt Communication rate of HC-05
  Serial.begin(38400);
}

void loop() {
  
  // Check if there is data available from the HC-05 Module
  while(Serial.available()<0{
    state = Serial.read(); // Reads the data from the serial port.
  }


  // Set Motor A to move foward at half speed
  motor.set(A,127,FORWARD);

  // Keep Motor A on for 3 seconds
  delay(3000);

  // Turn Off Motor
  motor.close(A);
}


