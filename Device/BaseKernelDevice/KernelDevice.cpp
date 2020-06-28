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
#include "KernelDevice.h"

/**************************************************************************/
/*! 
    @brief  Instantiates a new KernelDevice class
*/
/**************************************************************************/
KernelDevice::KernelDevice() 
{
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

// structure of a command parameter
#define PARAM_VALUE_LENGTH  16
struct cmd_param
{
    // value of the parameter
    char param_value[PARAM_VALUE_LENGTH];
};

// parts the make up a command parameter
#define CMD_PARAM_PREFIX                "p["
#define CMD_PARAM_PREFIX_LENGTH         2
#define CMD_PARAM_SUFFIX                "]="
#define CMD_PARAM_SUFFIX_LENGTH         2

#define CMD_PARAMS_COUNT        4
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
#define CMD_NAME_LENGTH                 24
struct cmd
{
    // name of the command that needs to be entered in the command line
    char cmd_name[CMD_NAME_LENGTH];
    // length of the used command name in characters
    char cmd_name_length;
    // method that will be executed
    void (*cmd)();
};

#define CMDS_COUNT          12
struct cmd cmds[CMDS_COUNT];

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
void printDeviceInfo()
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

//////////////////////////////////////////////////////////////////////
//  Echos the command parameter.
//  p[0] = index of param to execute
//  p[p[0]] = value to echo
//////////////////////////////////////////////////////////////////////
void echoCommandParameter()
{
    // read the parameter index
    int paramIdx = atoi(cmd_params[0].param_value);
    if ((paramIdx == 0)         // invalid value
            || (paramIdx > CMD_PARAMS_COUNT)) 
    {
        Serial.print(err_reading_param_msg);
        return;
    }

    Serial.print(cmd_params[paramIdx].param_value);
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
void printRegisteredCommands()
{
    for (int k = 0; k < CMDS_COUNT; k++)
    {
        if (cmds[k].cmd != NULL)
        {
            Serial.println(cmds[k].cmd_name);            
        }
    }
    
}

//////////////////////////////////////////////////////////////////////
//  Prints the command parameters.
//////////////////////////////////////////////////////////////////////
void printCommandParams()
{
    Serial.println(F("Command params:"));
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
                                                    for (int k = 0; k < input_buffer_idx; k++)
                                                    {
                                                        TRACEHEX(input_buffer[k]); TRACE(" ");
                                                    }
                                                    TRACELN();
                                                    TRACE(F("ibd=")); TRACELN(input_buffer_idx);
                                                    TRACE(F("memcmp1=")); TRACELN(memcmp(CMD_PREFIX, input_buffer, CMD_PREFIX_LENGTH));
                                                    TRACE(F("memcmp2=")); TRACELN(memcmp(CMD_SUFFIX, input_buffer + input_buffer_idx - CMD_SUFFIX_LENGTH - 1, CMD_SUFFIX_LENGTH));
    if ((input_buffer_idx >= MINIMUM_CMD_LENGTH) &&
            (memcmp(CMD_PREFIX, input_buffer, CMD_PREFIX_LENGTH) == 0) &&
            (memcmp(CMD_SUFFIX, input_buffer + input_buffer_idx - CMD_SUFFIX_LENGTH - 1, CMD_SUFFIX_LENGTH) == 0))
    {
        // determine the command name
        size_t cmd_val_sz = strlen(input_buffer + CMD_PREFIX_LENGTH + 1) - CMD_SUFFIX_LENGTH;
        if (cmd_val_sz > 0)
        {
            for (int k = 0; k < CMDS_COUNT; k++)
            {
                
                if ((cmds[k].cmd_name_length == cmd_val_sz) && 
                        (memcmp(cmds[k].cmd_name, input_buffer + CMD_PREFIX_LENGTH, cmd_val_sz) == 0))
                {
                    cmds[k].cmd();
                }
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

//////////////////////////////////////////////////////////////////////
//  Registers a command to be executed via command name.
//////////////////////////////////////////////////////////////////////
void registerCommand(char* cmd_name, void (*cmd)())
{
    int k = 0;
    bool found_empty = false;
    while (!found_empty && k < CMDS_COUNT)
    {
        found_empty = (cmds[k].cmd == NULL);
        if (found_empty)
        {
            int cmd_name_sz = strlen(cmd_name);
            if ((cmd_name_sz > 0) && (cmd_name_sz <= (CMD_NAME_LENGTH - 1)))
            {
                memcpy(cmds[k].cmd_name, cmd_name, cmd_name_sz);
                cmds[k].cmd_name_length = cmd_name_sz;
                cmds[k].cmd = cmd;
            } else
            {
                Serial.println(err_registering_cmd_msg);
            }
        }
        k++;
    }
}


void KernelDevice::init()
{
    // clear out the buffers
    input_buffer_idx = 0;
    for (uint8_t k = 0; k < CMD_PARAMS_COUNT; k++)
    {
        cmd_params[k].param_value[0] = 0;
    }
    for (uint8_t k = 0; k < CMDS_COUNT; k++)
    {
        cmds[k].cmd_name[0] = 0;
        cmds[k].cmd = NULL;
    }

    delay(100);
    Serial.begin(115200);  
    // give the device time to catch up before reading

    registerCommand("printDeviceInfo\0", printDeviceInfo);
    registerCommand("printRegisteredCommands\0", printRegisteredCommands);
    registerCommand("printCommandParams\0", printCommandParams);
    registerCommand("echoCommandParameter\0", echoCommandParameter);
    
    Serial.println();
    Serial.print(CMD_RESPONSE_LINE_ENDING);
}


void KernelDevice::loopAction() 
{
    readCharacters();
}




