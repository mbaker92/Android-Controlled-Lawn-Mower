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

        motor.set(A,100,REVERSE);
        motor.set(B,100,FORWARD);
        break;      
      case 'f':
        // Stop Forward
        motor.set(A,40,REVERSE);
        motor.set(B,40,FORWARD);
        delay(250);
        StopMotors();
        break;   
      case 'B':
        //Move Backward
        motor.set(A,80,FORWARD);
        motor.set(B,80,REVERSE);
        break; 
      case 'b':
        //Stop Backward
        motor.set(A,30,FORWARD);
        motor.set(B,30,REVERSE);
        delay(250);
        StopMotors();
        break;
      case 'R':
        motor.set(A,90,FORWARD);
        motor.set(B,90,FORWARD);
        //Move Right
        break;
      case 'r':
        // Stop Right
        StopMotors();
        break;
      case 'L':
        //Move Left
        motor.set(A,90,REVERSE);
        motor.set(B,90,REVERSE);
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


