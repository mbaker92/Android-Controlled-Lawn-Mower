/*  Author: Matthew Baker
 *  Email: Hackmattr@gmail.com
 *  Date Created: 4/17/2018
 *  Date Modified: 4/29/2018
 *  Description: Main Controller for the LawnBot 
 */

#include <MOTOR.h>

int state;

void setup() {
  motor.begin();
  Serial.begin(38400); // Default communication rate of the Bluetooth module
}

void loop() {
  while(Serial.available() > 0){ // Checks whether data is comming from the serial port
    state = Serial.read(); // Reads the data from the serial port

   switch(state)
      case 'F':
        // Move Forward
        motor.set(A,127,FORWARD);
        motor.set(B,127,FORWARD);
        break;
        
      case 'f':
        // Stop Forward
        StopMotors();
        break;
        
      case 'B':
        //Move Backward
        motor.set(A,127,REVERSE);
        motor.set(B,127,REVERSE);
        break;
        
      case 'b':
        //Stop Backward
        StopMotors();
        break;
        
      case 'R':
        //Move Right
        break;
      case 'r':
        // Stop Right
        break;
      case 'L':
        //Move Left
        break;
      case 'l':
        // Stop Left
        break;
  
}}

void StopMotors(){
  motor.close(A);
  motor.close(B);
}
}

