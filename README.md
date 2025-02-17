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


```bash
git clone https://github.com/andoabza/sensor-tcp-system.git
cd sensor-tcp-system