# Sensor Data Server-Client System

A simple TCP-based client-server system for simulating sensor data communication, built with C# Console.

## Features

- **Sensor Server**  
  - Listens on configurable port (default: 8888)  
  - Handles multiple concurrent clients 
  - Supports three commands:  
    - `GET_TEMP` - Random temperature (20.0°C to 30.0°C)  
    - `GET_STATUS` - Random boolean state (ACTIVE/INACTIVE)  
    - `GET_PRESSURE` - Random pressure (900-1100 hPa)  

- **Sensor Client**  
  - Thread-safe UI updates  
  - Input validation and error handling  

- **Common**  
  - Console versions included  
  - Detailed logging with timestamps  
  - Graceful shutdown handling  



```
Connected to server. Enter commands (GET_TEMP, GET_STATUS, GET_PRESSURE)
[22:52:48] Server started. Waiting for connections...
[22:52:48] Client connected: d5919793-0bed-4014-b735-f9e1b6e39b6e
ENTER COMMAND -> GET_TEMP
[22:52:59] Received from d5919793-0bed-4014-b735-f9e1b6e39b6e: GET_TEMP
[22:52:59] Sent response to d5919793-0bed-4014-b735-f9e1b6e39b6e:

==================== GET_TEMP: 29°C

ENTER COMMAND-> GET_STATUS
[22:53:10] Received from d5919793-0bed-4014-b735-f9e1b6e39b6e: GET_STATUS
[22:53:10] Sent response to d5919793-0bed-4014-b735-f9e1b6e39b6e:

==================== GET_STATUS: ACTIVE

ENTER COMMAND-> GET_PRESSURE
[22:53:27] Received from d5919793-0bed-4014-b735-f9e1b6e39b6e: GET_PRESSURE
[22:53:27] Sent response to d5919793-0bed-4014-b735-f9e1b6e39b6e:

==================== GET_PRESSURE: 1073 hPa

ENTER COMMAND->
Press ENTER to stop server...
[22:53:41] Client disconnected: d5919793-0bed-4014-b735-f9e1b6e39b6e

[22:53:46] Exiting...