/*  Author: Matthew Baker
 *  Email: Hackmattr@gmail.com
 *  Date Created: 4/17/2018
 *  Date Modified: 4/29/2018
 *  Description: Main Controller for the LawnBot 
 */
// #include<SoftwareSerial.h>
//SoftwareSerial Bluetooth(2,3);
#include <MOTOR.h>
void StopMotors();
int state;

void setup() {
  motor.begin();
 // Bluetooth.begin(38400);
  Serial.begin(38400); // Default communication rate of the Bluetooth module
}
String temp;
void loop() {
  while(Serial.available() > 0){ // Checks whether data is coming from the serial port
   state = Serial.read(); // Reads the data from the serial port
   Serial.println(state);
 

   switch(state){
      case 'F' :
        // Move Forward

        motor.set(A,50,FORWARD);
        motor.set(B,50,REVERSE);
        break;      
      case 'f':
        // Stop Forward
        StopMotors();
        break;   
      case 'B':
        //Move Backward
        motor.set(A,50,REVERSE);
        motor.set(B,50,FORWARD);
        break; 
      case 'b':
        //Stop Backward
        StopMotors();
        break;
      case 'R':
        motor.set(A,50,FORWARD);
        motor.set(B,50,FORWARD);
        //Move Right
        break;
      case 'r':
        // Stop Right
        StopMotors();
        break;
      case 'L':
        //Move Left
        motor.set(A,50,REVERSE);
        motor.set(B,50,REVERSE);
        break;
      case 'l':
        // Stop Left
        StopMotors();
        break;
   }
}
}

void StopMotors(){
  motor.close(A);
  motor.close(B);
}


