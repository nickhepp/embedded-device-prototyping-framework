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


 
#ifndef COMMON_H
#define COMMON_H


////////////////////////////////////
// Device identifying info
////////////////////////////////////
#define VERSION_MAJOR       0
#define VERSION_MINOR       0
#define VERSION_BUILD       0    
#define VERSION_REVISION    35

#define DEVICE_NAME         F("KernelDevice")


////////////////////////////////////
// Debugging -- poor man's version
////////////////////////////////////

// Uncomment below to allow for poor man's debugger (print)
//#define DEBUG

#ifdef DEBUG
#define TRACE(x)    Serial.print(x)
#define TRACELN(x)  Serial.println(x)
#define TRACEDEC(x) Serial.print(x, DEC)
#define TRACEHEX(x) Serial.print(x, HEX)
#else
#define TRACE(x)
#define TRACELN(x)  
#define TRACEDEC(x) 
#define TRACEHEX(x) 
#endif /* DEBUG */



////////////////////////////////////
// Error messages
////////////////////////////////////

#define err_alloc_msg           F("ERR: Allocating memory")
#define err_reading_param_msg   F("ERR: Reading parameters")
#define err_registering_cmd_msg F("ERR: Registering command")
#define err_invalid_value_msg   F("ERR: Invalid value")



// COMMON_H
#endif



