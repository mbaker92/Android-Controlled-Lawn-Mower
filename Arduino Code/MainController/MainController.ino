/*  Author: Matthew Baker
 *  Email: Hackmattr@gmail.com
 *  Date Created: 4/17/2018
 *  Date Modified: 4/17/2018
 *  Description: Main Controller for the LawnBot 
 */

int state;
void setup() {
;
  Serial.begin(38400); // Default communication rate of the Bluetooth module
}

void loop() {
  while(Serial.available() > 0){ // Checks whether data is comming from the serial port
    state = Serial.read(); // Reads the data from the serial port

   switch(state)
      case 'F':
        // Move Forward
        break;
      case 'f':
        // Stop Forward
        break;
      case 'B':
        //Move Backward
        break;
      case 'b':
        //Stop Backward
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
