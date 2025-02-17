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
[23:26:50] Server started. Waiting for connections...
[23:26:50] Client connected: 90be7aa6-243b-4be2-a5fe-060fbccf6458

Available commands:
GET_TEMP - Get temperature reading
GET_STATUS - Get system status
GET_PRESSURE - Get pressure reading

ENTER COMMAND -> GET_TEMP
[23:26:57] Received from 90be7aa6-243b-4be2-a5fe-060fbccf6458: GET_TEMP
[23:26:57] Sent response to 90be7aa6-243b-4be2-a5fe-060fbccf6458:

%%%%%%%%%%%%%%%%%% GET_TEMP: 25.5°C

ENTER COMMAND-> GET_STATUS
[23:27:04] Received from 90be7aa6-243b-4be2-a5fe-060fbccf6458: GET_STATUS
[23:27:04] Sent response to 90be7aa6-243b-4be2-a5fe-060fbccf6458:

%%%%%%%%%%%%%%%%%% GET_STATUS: ACTIVE

ENTER COMMAND-> GET_PRESSURE
[23:27:11] Received from 90be7aa6-243b-4be2-a5fe-060fbccf6458: GET_PRESSURE
[23:27:11] Sent response to 90be7aa6-243b-4be2-a5fe-060fbccf6458:

%%%%%%%%%%%%%%%%%% GET_PRESSURE: 948 hPa

ENTER COMMAND-> GET_NO
[23:27:22] Received from 90be7aa6-243b-4be2-a5fe-060fbccf6458: GET_NO
[23:27:22] Sent response to 90be7aa6-243b-4be2-a5fe-060fbccf6458:

%%%%%%%%%%%%%%%%%% GET_NO: ERROR: Unknown command

ENTER COMMAND->
Press ENTER to stop server...
[23:27:25] Client disconnected: 90be7aa6-243b-4be2-a5fe-060fbccf6458

[23:27:28] Exiting...