/* 
 *  
 * This class performs the basic IO operations.
 * MIT License
 * 
 * Copyright (c) 2020 Nick Heppermann (e content services, LLC) nickhepp@gmail.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE
 * 
 */


#include <EEPROM.h>
#include "common.h"
#include "cmd_param.h"
#include "KernelDevice.h"
#include "CommandCollection.h"

CommandCollection cmdCollection;

/**************************************************************************/
/*! 
    @brief  Instantiates a new KernelDevice class
*/
/**************************************************************************/
KernelDevice::KernelDevice() 
{
}


void KernelDevice::registerCommand(Command* cmd)
{
    cmdCollection.addCommand(cmd);
}



//////////////////////////////////////////
// Input Buffer
//////////////////////////////////////////

// terminating character for a line of input
#define INPUT_LINE_END                      '\n'

// size of the input buffer before code evaluates it
#define INPUT_BUFFER_SIZE                   256

// the input buffer
char input_buffer[INPUT_BUFFER_SIZE];

// the tail index of where the next input buffer will go
int input_buffer_idx;


//////////////////////////////////////////
// Command Parameters
//////////////////////////////////////////

// what the device echoes back to the host signalling it has finished processing input
#define CMD_RESPONSE_LINE_ENDING            F("\n>")


// parts the make up a command parameter
#define CMD_PARAM_PREFIX                "p["
#define CMD_PARAM_PREFIX_LENGTH         2
#define CMD_PARAM_SUFFIX                "]="
#define CMD_PARAM_SUFFIX_LENGTH         2


#define CMD_PARAMS_IDX_LENGTH   1
struct cmd_param cmd_params[CMD_PARAMS_COUNT];

// the size of the param perfix
#define CMD_PARAM_ASSIGNMENT_LENGTH     (CMD_PARAM_PREFIX_LENGTH + CMD_PARAMS_IDX_LENGTH + CMD_PARAM_SUFFIX_LENGTH)


//////////////////////////////////////////
// Commands
//////////////////////////////////////////

#define CMD_PREFIX                      "cmd:"
#define CMD_PREFIX_LENGTH               4
#define CMD_SUFFIX                      "()"
#define CMD_SUFFIX_LENGTH               2
#define MINIMUM_CMD_LENGTH              CMD_PREFIX_LENGTH + CMD_SUFFIX_LENGTH + 1

////******************************************************************
////******************************************************************
//  [START] COMMANDS
//  The following functions are "commands", which can be executed by
//  entering "cmd:<commandName>()" over the serial IO.
////******************************************************************
////******************************************************************

//////////////////////////////////////////////////////////////////////
//  Prints device info.
//////////////////////////////////////////////////////////////////////
void get_device_info(Command* cmd)
{
    Serial.println(DEVICE_NAME);
    Serial.print(F("V"));
    Serial.print(VERSION_MAJOR);
    Serial.print(F("."));
    Serial.print(VERSION_MINOR);
    Serial.print(F("."));
    Serial.print(VERSION_BUILD);
    Serial.print(F("."));
    Serial.println(VERSION_REVISION);
    Serial.print(F("cmd params count:"));
    Serial.print(CMD_PARAMS_COUNT);
}


// <-- Add more command methods here.  Signature needs to be like so below.
//      Cant have any arguments.  That is what command parameters are for.
// void methodName()


////******************************************************************
////******************************************************************
//  [END] COMMANDS
////******************************************************************
////******************************************************************


////******************************************************************
////******************************************************************
//  [START] BASE KERNEL IO
//  These functions control the base kernel device IO.
//  entering "cmd:<commandName>()" over the serial IO.
////******************************************************************
////******************************************************************

//////////////////////////////////////////////////////////////////////
//  Prints the commands that have been registered.
//////////////////////////////////////////////////////////////////////
void get_registered_commands(Command* cmd)
{
    Command* cmdPtr = cmdCollection.getCommandByPtr(NULL_PTR);
    while (cmdPtr != NULL_PTR)
    {
        cmdPtr->printCommand();
        cmdPtr = cmdCollection.getCommandByPtr(cmdPtr);
    }
}


//////////////////////////////////////////////////////////////////////
//  Prints the command parameters.
//////////////////////////////////////////////////////////////////////
void get_command_parameters(Command* cmd)
{
    for (int k = 0; k < CMD_PARAMS_COUNT; k++)
    {
        Serial.print(CMD_PARAM_PREFIX);
        Serial.print(k, DEC);
        Serial.print(CMD_PARAM_SUFFIX);
        Serial.print(F("'"));
        Serial.print(cmd_params[k].param_value);
        Serial.println(F("'"));
    }
}


//////////////////////////////////////////////////////////////////////
//  Attempts to execute a registered command, if one is found.
//////////////////////////////////////////////////////////////////////
void KernelDevice::executeCommand()
{
    // look that the inputer buffer is big enough,
    // has the correct prefix
    // and the correct suffix
#ifdef DEBUG
    for (int k = 0; k < input_buffer_idx; k++)
    {
        TRACEHEX(input_buffer[k]); TRACE(" ");
    }
    TRACELN();
    TRACE(F("ibd=")); TRACELN(input_buffer_idx);
    TRACE(F("memcmp1=")); TRACELN(memcmp(CMD_PREFIX, input_buffer, CMD_PREFIX_LENGTH));
    TRACE(F("memcmp2=")); TRACELN(memcmp(CMD_SUFFIX, input_buffer + input_buffer_idx - CMD_SUFFIX_LENGTH - 1, CMD_SUFFIX_LENGTH));
#endif

    if ((input_buffer_idx >= MINIMUM_CMD_LENGTH) &&
            (memcmp(CMD_PREFIX, input_buffer, CMD_PREFIX_LENGTH) == 0) &&
            (memcmp(CMD_SUFFIX, input_buffer + input_buffer_idx - CMD_SUFFIX_LENGTH - 1, CMD_SUFFIX_LENGTH) == 0))
    {
        // determine the command name
        size_t cmd_val_sz = strlen(input_buffer + CMD_PREFIX_LENGTH + 1) - CMD_SUFFIX_LENGTH;
        if (cmd_val_sz > 0)
        {

            Command* cmd = cmdCollection.getCommandByName(input_buffer + CMD_PREFIX_LENGTH, cmd_val_sz);
            if (cmd != NULL_PTR)
            {
                cmd->execute();
            }
        }
    }
}

//////////////////////////////////////////////////////////////////////
//  Attempts to read a command parameter.
//////////////////////////////////////////////////////////////////////
void KernelDevice::readCommandParam()
{
    // check that the potential command parameter is big enough, start matches, and end matches
    if ((input_buffer_idx >= CMD_PARAM_ASSIGNMENT_LENGTH) && 
            (strncmp(CMD_PARAM_PREFIX, input_buffer, CMD_PARAM_PREFIX_LENGTH) == 0) &&
            (strncmp(CMD_PARAM_SUFFIX, input_buffer + CMD_PARAM_PREFIX_LENGTH + CMD_PARAMS_IDX_LENGTH, CMD_PARAM_SUFFIX_LENGTH) == 0))
    {
        size_t param_val_sz = strlen(input_buffer + CMD_PARAM_ASSIGNMENT_LENGTH + 1);
        //Serial.print("param_val_sz = ");
        //Serial.println(param_val_sz);
        int param_idx = atoi(input_buffer + CMD_PARAM_PREFIX_LENGTH);
        //if (param_idx == 0 && input_buffer[CMD_PARAM_PREFIX_LENGTH] != '\0')
        //{
        //    // could not read any parameter
        //    Serial.write(err_reading_param_msg);
        //    return;
        //}

        // zero out remainder of params
        memset(&(cmd_params[param_idx].param_value), 0, PARAM_VALUE_LENGTH);
        // param looks good, copy it to our buffer
        memcpy(&(cmd_params[param_idx].param_value), input_buffer + CMD_PARAM_PREFIX_LENGTH + CMD_PARAMS_IDX_LENGTH + CMD_PARAM_SUFFIX_LENGTH, param_val_sz);
    }
  
}

//////////////////////////////////////////////////////////////////////
//  Reads characters and looks for command parameters and commands.
//////////////////////////////////////////////////////////////////////
void KernelDevice::readCharacters()
{
    bool found_line_end = false;
    int char_avail_count = Serial.available(); 
    int read_char;
    if (char_avail_count > 0) 
    {
        // figure out the max we can put in our buffer
        int max_to_read = INPUT_BUFFER_SIZE - input_buffer_idx;
        if (char_avail_count < max_to_read)
        {
            max_to_read = char_avail_count;     
        }

        // read what's waiting
        int bytes_read = 0;
        while ((bytes_read < char_avail_count) && !found_line_end)
        {
            read_char = Serial.read();
            if (read_char <= 0x7F)
            {
                input_buffer[input_buffer_idx] = read_char;
                // echo back out
                Serial.write(input_buffer[input_buffer_idx]);
                found_line_end = (input_buffer[input_buffer_idx] == INPUT_LINE_END);
                input_buffer_idx++;
            }
            bytes_read++;
        }

        if (found_line_end)
        {
            // terminate end of line, which is used by parsing function to find end of command
            input_buffer[input_buffer_idx] = '\0'; 
            readCommandParam();
            executeCommand();
            Serial.print(CMD_RESPONSE_LINE_ENDING);
            // reset the line buffer to the beginning
            input_buffer_idx = 0;
        }
    }
}


#if INCLUDE_PARAM_IO_COMMAND
#define EXAMPLE_UINT8_PARAM_NAME    "uint8_val"
#define EXAMPLE_INT8_PARAM_NAME     "int8_val"
#define EXAMPLE_UINT16_PARAM_NAME   "uint16_val"
#define EXAMPLE_INT16_PARAM_NAME    "int16_val"
#define EXAMPLE_UINT32_PARAM_NAME   "uint32_val"
#define EXAMPLE_INT32_PARAM_NAME    "int32_val"
#define EXAMPLE_DOUBLE_PARAM_NAME   "double_val"
#define EXAMPLE_BOOL_PARAM_NAME     "bool_val"

Command paramIOCommand;
void param_io_command(Command* cmd)
{
    uint8_t uint8_val;
    if (cmd->getUInt8Parameter(EXAMPLE_UINT8_PARAM_NAME, &uint8_val))
    {
        Serial.print(F(EXAMPLE_UINT8_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(uint8_val, DEC);
    }

    int8_t int8_val;
    if (cmd->getInt8Parameter(EXAMPLE_INT8_PARAM_NAME, &int8_val))
    {
        Serial.print(F(EXAMPLE_INT8_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(int8_val, DEC);
    }

    uint16_t uint16_val;
    if (cmd->getUInt16Parameter(EXAMPLE_UINT16_PARAM_NAME, &uint16_val))
    {
        Serial.print(F(EXAMPLE_UINT16_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(uint16_val, DEC);
    }

    int16_t int16_val;
    if (cmd->getInt16Parameter(EXAMPLE_INT16_PARAM_NAME, &int16_val))
    {
        Serial.print(F(EXAMPLE_INT16_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(int16_val, DEC);
    }

    uint32_t uint32_val;
    if (cmd->getUInt32Parameter(EXAMPLE_UINT32_PARAM_NAME, &uint32_val))
    {
        Serial.print(F(EXAMPLE_UINT32_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(uint32_val, DEC);
    }

    int32_t int32_val;
    if (cmd->getInt32Parameter(EXAMPLE_INT32_PARAM_NAME, &int32_val))
    {
        Serial.print(F(EXAMPLE_INT32_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(int32_val, DEC);
    }

    double dbl_val;
    if (cmd->getDoubleParameter(EXAMPLE_DOUBLE_PARAM_NAME, &dbl_val))
    {
        Serial.print(F(EXAMPLE_DOUBLE_PARAM_NAME));
        Serial.print(F("="));
        Serial.println(dbl_val, 3);
    }

    bool bool_val;
    if (cmd->getBoolParameter(EXAMPLE_BOOL_PARAM_NAME, &bool_val))
    {
        Serial.print(F(EXAMPLE_BOOL_PARAM_NAME));
        Serial.print(F("="));
        if (bool_val)
        {
            Serial.println(F("TRUE"));
        }
        else
        {
            Serial.println(F("FALSE"));
        }
    }
}
#endif  // INCLUDE_PARAM_IO_COMMAND

#if INCLUDE_SHOW_HIGHLIGHTS_COMMAND 
Command highlightsCommand;
void show_highlights_command(Command* cmd)
{
    Serial.println(F("WARN: an example warning message"));
    Serial.println(F("PASS: an example success message"));
    Serial.println(F("ERR: an example error message"));
}
#endif  // INCLUDE_SHOW_HIGHLIGHTS_COMMAND

#if INCLUDE_COLOR_COMMANDS

#define RED_COLOR_PARAM_NAME    "red"
#define GREEN_COLOR_PARAM_NAME  "green"
#define BLUE_COLOR_PARAM_NAME   "blue"

#define RED_ADDRESS       (0x00)
#define GREEN_ADDRESS     (0x01)
#define BLUE_ADDRESS      (0x02)


// TODO: make the back and forth get + set

Command getColorsCommand;
void get_colors_command(Command* cmd)
{
    Serial.print(F(RED_COLOR_PARAM_NAME));
    Serial.print(F("="));
    Serial.print(EEPROM.read(RED_ADDRESS), DEC);
    Serial.print(F(", "));

    Serial.print(F(GREEN_COLOR_PARAM_NAME));
    Serial.print(F("="));
    Serial.print(EEPROM.read(GREEN_ADDRESS), DEC);
    Serial.print(F(", "));
    
    Serial.print(F(BLUE_COLOR_PARAM_NAME));
    Serial.print(F("="));
    Serial.print(EEPROM.read(BLUE_ADDRESS), DEC);
}

Command setColorsCommand;
void set_colors_command(Command* cmd)
{
    uint8_t red_val;
    if (cmd->getUInt8Parameter(RED_COLOR_PARAM_NAME, &red_val))
    {
        EEPROM.write(RED_ADDRESS, red_val);
    }
    
    uint8_t green_val;
    if (cmd->getUInt8Parameter(GREEN_COLOR_PARAM_NAME, &green_val))
    {
        EEPROM.write(GREEN_ADDRESS, green_val);
    }

    uint8_t blue_val;
    if (cmd->getUInt8Parameter(BLUE_COLOR_PARAM_NAME, &blue_val))
    {
        EEPROM.write(BLUE_ADDRESS, blue_val);
    }

    Serial.println(F("written colors"));
}

#endif // INCLUDE_COLOR_COMMANDS

#if INCLUDE_CHARTING_VALUES_COMMAND
const int16_t TRIANGLE_WAVE_VAL = 1000;
const int16_t MIN_TRIANGLE_WAVE_VAL = -1000;
int16_t triangle_wave_val = 0;
bool triangle_wave_ascending = true;

static float sin_qtr_cycle[] = { 0.0, .20, .38, .56, .70, .84, .92, .98 };

const uint8_t sin_qtr_cycle_sample_max = 8;
uint8_t sin_qtr_cycle_sample_idx = sin_qtr_cycle_sample_max;

const uint8_t sin_qtr_part_max = 4;
uint8_t sin_qtr_part_idx = sin_qtr_part_max;

const uint8_t saw_tooth_sample_max = sin_qtr_cycle_sample_max * sin_qtr_part_max;
uint8_t saw_tooth_sample_idx = saw_tooth_sample_max;

Command chartingCommand;
void charting_values_command(Command* cmd)
{
    // in place of real hardware sensing a value do an in memory representation

    /////////////////////////////////////////////////////////////
    // do the triangle wave, oscillates from 1000 to -1000
    if (triangle_wave_ascending)
    {
        triangle_wave_val += TRIANGLE_WAVE_VAL / 10;
        if (triangle_wave_val >= TRIANGLE_WAVE_VAL)
        {
            triangle_wave_val = TRIANGLE_WAVE_VAL;
            triangle_wave_ascending = false;
        }

    } else {
        triangle_wave_val -= TRIANGLE_WAVE_VAL / 10;
        if (triangle_wave_val <= MIN_TRIANGLE_WAVE_VAL)
        {
            triangle_wave_val = MIN_TRIANGLE_WAVE_VAL;
            triangle_wave_ascending = true;
        }
    }

    /////////////////////////////////////////////////////////////
    // do the sin wave
    sin_qtr_cycle_sample_idx++;
    if (sin_qtr_cycle_sample_idx >= sin_qtr_cycle_sample_max)
    {
        sin_qtr_part_idx++;
        if (sin_qtr_part_idx >= sin_qtr_part_max)
        {
            sin_qtr_part_idx = 0;
        }

        if ((sin_qtr_part_idx & 1) == 1)
        {
            sin_qtr_cycle_sample_idx = 0;
        }
        else
        {
            sin_qtr_cycle_sample_idx = 1;
        }
    }

    float sin_val;
    if (sin_qtr_part_idx == 0)
    {
        sin_val = sin_qtr_cycle[sin_qtr_cycle_sample_idx];
    }
    else if (sin_qtr_part_idx == 1)
    {
        sin_val = sin_qtr_cycle[sin_qtr_cycle_sample_max - sin_qtr_cycle_sample_idx - 1];
    }
    else if (sin_qtr_part_idx == 2)
    {
        sin_val = -sin_qtr_cycle[sin_qtr_cycle_sample_idx];
    }
    else //if (sin_qtr_part_idx == 3)
    {
        sin_val = -sin_qtr_cycle[sin_qtr_cycle_sample_max - sin_qtr_cycle_sample_idx - 1];
    }

    /////////////////////////////////////////////////////////////
    // do the saw tooth wave
    saw_tooth_sample_idx++;
    if (saw_tooth_sample_idx > saw_tooth_sample_max)
    {
        saw_tooth_sample_idx = 0;
    }
    float saw_tooth_val = (float)(saw_tooth_sample_idx) / (float)(saw_tooth_sample_max);

    Serial.print("vals:");
    Serial.print(triangle_wave_val, DEC);
    Serial.print(",");
    Serial.print(sin_val, 2);
    Serial.print(",");
    Serial.println(saw_tooth_val, 2);
}
#endif  // INCLUDE_CHARTING_VALUES_COMMAND

#if INCLUDE_EDPF_DEMO_KIT


//// the joysticks Y axis
//#define EDPF_DEMO_STICK_PRESS_PIN	(A2)
//
//// the joysticks Y axis
//#define EDPF_DEMO_STICK_VRY_PIN		(A4)
//
//// the joysticks X axis
//#define EDPF_DEMO_STICK_VRX_PIN		(A5)

Command edpfKitReadCommand;
void edpf_kit_read_command(Command* cmd)
{
    int joy_x = analogRead(EDPF_DEMO_STICK_VRX_PIN);
    int joy_y = analogRead(EDPF_DEMO_STICK_VRY_PIN);
    //int joy_pressed = analogRead(EDPF_DEMO_STICK_PRESS_PIN);
    int joy_pressed = digitalRead(EDPF_DEMO_STICK_PRESS_PIN);
    uint8_t b1 = digitalRead(EDPD_DEMO_BUTTON_B1);
    uint8_t b2 = digitalRead(EDPD_DEMO_BUTTON_B2);
    uint8_t b3 = digitalRead(EDPD_DEMO_BUTTON_B3);
    uint8_t b4 = digitalRead(EDPD_DEMO_BUTTON_B4);

    Serial.print("kit:");
    Serial.print(joy_x, DEC);
    Serial.print(",");
    Serial.print(joy_y, DEC);
    Serial.print(",");
    Serial.print(joy_pressed, DEC);
    Serial.print(",");
    Serial.print(b1, DEC);
    Serial.print(",");
    Serial.print(b2, DEC);
    Serial.print(",");
    Serial.print(b3, DEC);
    Serial.print(",");
    Serial.println(b4, DEC);

}


#endif //INCLUDE_EDPF_DEMO_KIT

void clear_input_buffers()
{
    // clear out the buffers
    input_buffer_idx = 0;
    for (uint8_t k = 0; k < CMD_PARAMS_COUNT; k++)
    {
        cmd_params[k].param_value[0] = 0;
    }
}

// these are the core commands that are needed for the
// the device to work properly
Command getDeviceInfoCommand;
Command getRegisteredCommandsCommand;
Command getCommandParametersCommand;

void KernelDevice::init()
{
    clear_input_buffers();

    delay(100);
    Serial.begin(115200);  

// How to create a custom command
// https://github.com/nickhepp/embedded-device-prototyping-framework/blob/master/how_to_create_custom_commands.md

// create a simple command that matches the example found above, and keep the one command with all the type options
// as a seperate compile in example

#if INCLUDE_COLOR_COMMANDS
  getColorsCommand.initCommand("get_colors", cmd_params, get_colors_command);
  registerCommand(&getColorsCommand);

  setColorsCommand.initCommand("set_colors", cmd_params, set_colors_command);
  setColorsCommand.addUInt8Parameter(RED_COLOR_PARAM_NAME);
  setColorsCommand.addUInt8Parameter(GREEN_COLOR_PARAM_NAME);
  setColorsCommand.addUInt8Parameter(BLUE_COLOR_PARAM_NAME);
  registerCommand(&setColorsCommand);
  
#endif  // INCLUDE_COLOR_COMMANDS

#if INCLUDE_CHARTING_VALUES_COMMAND
    chartingCommand.initCommand("charting_values", cmd_params, charting_values_command);
    registerCommand(&chartingCommand);
#endif  // INCLUDE_CHARTING_VALUES_COMMAND

#if INCLUDE_SHOW_HIGHLIGHTS_COMMAND
    highlightsCommand.initCommand("show_highlights", cmd_params, show_highlights_command);
    registerCommand(&highlightsCommand);
#endif  // INCLUDE_SHOW_HIGHLIGHTS_COMMAND

#if INCLUDE_PARAM_IO_COMMAND
	// initialize the command by giving it a name for the host application and assigning the callback method,
	// note that this example uses the same characters for the text name and the callback name, but they dont have
	// to be the same
    paramIOCommand.initCommand("param_io", cmd_params, param_io_command);
	// add parameters to the command
    paramIOCommand.addUInt8Parameter(EXAMPLE_UINT8_PARAM_NAME);
    paramIOCommand.addInt8Parameter(EXAMPLE_INT8_PARAM_NAME);
    paramIOCommand.addUInt16Parameter(EXAMPLE_UINT16_PARAM_NAME);
    paramIOCommand.addInt16Parameter(EXAMPLE_INT16_PARAM_NAME);
    paramIOCommand.addUInt32Parameter(EXAMPLE_UINT32_PARAM_NAME);
    paramIOCommand.addInt32Parameter(EXAMPLE_INT32_PARAM_NAME);
    paramIOCommand.addDoubleParameter(EXAMPLE_DOUBLE_PARAM_NAME);
    paramIOCommand.addBoolParameter(EXAMPLE_BOOL_PARAM_NAME);
	// register the command so the processing loop can look for matches by name
    registerCommand(&paramIOCommand);
#endif  // INCLUDE_PARAM_IO_COMMAND

#if INCLUDE_EDPF_DEMO_KIT

    pinMode(EDPF_DEMO_STICK_PRESS_PIN, INPUT);
    digitalWrite(EDPF_DEMO_STICK_PRESS_PIN, HIGH);

    pinMode(EDPD_DEMO_BUTTON_B1, INPUT_PULLUP);
    pinMode(EDPD_DEMO_BUTTON_B2, INPUT_PULLUP);
    pinMode(EDPD_DEMO_BUTTON_B3, INPUT_PULLUP);
    pinMode(EDPD_DEMO_BUTTON_B4, INPUT_PULLUP);
    edpfKitReadCommand.initCommand("edpf_kit_read", cmd_params, edpf_kit_read_command);
    // register the command so the processing loop can look for matches by name
    registerCommand(&edpfKitReadCommand);
#endif  // INCLUDE_EDPF_DEMO_KIT

    //////////////////////////////////////////
    // START - leave these commands alone, they are meant for proper operation of the framework
    //////////////////////////////////////////
    // leave this command here, its meants for proper operation of the framework
    getDeviceInfoCommand.initCommand("get_device_info", cmd_params, get_device_info);
    registerCommand(&getDeviceInfoCommand);

    // leave this command here, its meants for proper operation of the framework
    getRegisteredCommandsCommand.initCommand("get_registered_commands", cmd_params, get_registered_commands);
    registerCommand(&getRegisteredCommandsCommand);

    // leave this command here, its meants for proper operation of the framework
    getCommandParametersCommand.initCommand("get_command_parameters", cmd_params, get_command_parameters);
    registerCommand(&getCommandParametersCommand);
    //////////////////////////////////////////
    // END - leave these commands alone, they are meant for proper operation of the framework
    //////////////////////////////////////////

    Serial.println();
    Serial.print(CMD_RESPONSE_LINE_ENDING);
}


void KernelDevice::loopAction() 
{
    readCharacters();
}
