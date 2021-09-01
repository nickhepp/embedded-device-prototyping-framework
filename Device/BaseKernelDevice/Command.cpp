#include <string.h>
#include <stdint.h>

#include "Arduino.h"

#include "cmd_param.h"
#include "command.h"
#include "parameter.h"
#include "doubleparameter.h"
#include "boolparameter.h"
#include "uint8parameter.h"
#include "uint16parameter.h"
#include "uint32parameter.h"
#include "int8parameter.h"
#include "int16parameter.h"
#include "int32parameter.h"

BoolParameter boolParam;
DoubleParameter doubleParam;
UInt8Parameter  uint8Param;
UInt16Parameter uint16Param;
UInt32Parameter uint32Param;
Int8Parameter   int8Param;
Int16Parameter  int16Param;
Int32Parameter  int32Param;


Command::Command()
{
  memset(&_params, NULL_PTR, MAX_COMMAND_PARAMS * sizeof(param_ptr));
  _paramsCnt = 0;
  _nextCommand = NULL_PTR;
}

void Command::initCommand(const char* cmdName, struct cmd_param cmd_params[], void (*callback_handle)(Command*))
{
    _cmdName = cmdName;
    _cmdNameSz = strlen(cmdName);
    _cmd_params_data = cmd_params;
    _callback_handle = callback_handle;
}

void Command::execute()
{
  (*_callback_handle)(this);
}

uint8_t Command::getParamByTypeAndName(uint8_t typeID, const char *paramName)
{
	uint8_t paramIdx = 0;
	size_t testSz = strlen(paramName);
    size_t typeSz;
	while (paramIdx < _paramsCnt)
	{

        if ((_params[paramIdx].param->getValueTypeID() == typeID) &&
            (testSz == _params[paramIdx].param_name_len) &&
            (memcmp(_params[paramIdx].param_name, paramName, testSz) == 0))
        {
            return paramIdx;
        }
  
		paramIdx++;
	}
	
	return UNDEFINED_PARAM_IDX;
}

void Command::addUInt8Parameter(const char *paramName)
{
  addParameter(paramName, &uint8Param);
}

bool Command::getUInt8Parameter(const char *paramName, uint8_t *val)
{
	uint8_t idx = getParamByTypeAndName(UINT8_VALUE_TYPEID, paramName);
	if (idx != UNDEFINED_PARAM_IDX)
	{
		*val = uint8Param.getValue(idx, _cmd_params_data);
    return true;
	}
  return false;
}

void Command::addUInt16Parameter(const char *paramName)
{
  addParameter(paramName, &uint16Param);
}

bool Command::getUInt16Parameter(const char *paramName, uint16_t *val)
{
    uint8_t idx = getParamByTypeAndName(UINT16_VALUE_TYPEID, paramName);
    if (idx != UNDEFINED_PARAM_IDX)
    {
        *val = uint16Param.getValue(idx, _cmd_params_data);
        return true;
    }
    return false;
}

void Command::addUInt32Parameter(const char *paramName)
{
  addParameter(paramName, &uint32Param);
}

bool Command::getUInt32Parameter(const char *paramName, uint32_t *val)
{
  uint8_t idx = getParamByTypeAndName(UINT32_VALUE_TYPEID, paramName);
  if (idx != UNDEFINED_PARAM_IDX)
  {
    *val = uint32Param.getValue(idx, _cmd_params_data);
    return true;
  }
  return false;
}

void Command::addInt8Parameter(const char *paramName)
{
  addParameter(paramName, &int8Param);
}

bool Command::getInt8Parameter(const char *paramName, int8_t *val)
{
  uint8_t idx = getParamByTypeAndName(INT8_VALUE_TYPEID, paramName);
  if (idx != UNDEFINED_PARAM_IDX)
  {
    *val = int8Param.getValue(idx, _cmd_params_data);
    return true;
  }
  return false;
}

void Command::addInt16Parameter(const char *paramName)
{
  addParameter(paramName, &int16Param);
}

bool Command::getInt16Parameter(const char *paramName, int16_t *val)
{
    uint8_t idx = getParamByTypeAndName(INT16_VALUE_TYPEID, paramName);
    if (idx != UNDEFINED_PARAM_IDX)
    {
        *val = int16Param.getValue(idx, _cmd_params_data);
        return true;
    }
    return false;
}

void Command::addInt32Parameter(const char *paramName)
{
  addParameter(paramName, &int32Param);
}

bool Command::getInt32Parameter(const char *paramName, int32_t *val)
{
  uint8_t idx = getParamByTypeAndName(INT32_VALUE_TYPEID, paramName);
  if (idx != UNDEFINED_PARAM_IDX)
  {
    *val = int32Param.getValue(idx, _cmd_params_data);
    return true;
  }
  return false;
}

void Command::addBoolParameter(const char *paramName)
{
  addParameter(paramName, &boolParam);  
}

bool Command::getBoolParameter(const char *paramName, bool *val)
{
    uint8_t idx = getParamByTypeAndName(BOOL_VALUE_TYPEID, paramName);
    if (idx != UNDEFINED_PARAM_IDX)
    {
        *val = boolParam.getValue(idx, _cmd_params_data);
        return true;
    }
    return false;
}

void Command::addDoubleParameter(const char *paramName)
{
  addParameter(paramName, &doubleParam);
}

bool Command::getDoubleParameter(const char *paramName, double *val)
{
  uint8_t idx = getParamByTypeAndName(DOUBLE_VALUE_TYPEID, paramName);
  if (idx != UNDEFINED_PARAM_IDX)
  {
    *val = doubleParam.getValue(idx, _cmd_params_data);
    return true;
  }
  return false;
}

////////////////////////////


void Command::addParameter(const char *paramName, Parameter *param)
{
  if (_paramsCnt < MAX_COMMAND_PARAMS)
  {
    _params[_paramsCnt].param = param;
    _params[_paramsCnt].param_name = paramName;
	_params[_paramsCnt].param_name_len = strlen(paramName);
    _paramsCnt++;
  }
}


void Command::printCommand()
{
  Serial.print(_cmdName);
  Serial.print(F(" {"));

  uint8_t pIdx = 0;
  while (pIdx < _paramsCnt)
  {
    Serial.print(F("p["));
    Serial.print(pIdx, DEC);
    Serial.print(F("]:("));
    Serial.print(_params[pIdx].param->getValueType());
    Serial.print(F(")"));
    Serial.print(_params[pIdx].param_name);
    if (pIdx != (_paramsCnt - 1))
    {
      Serial.print(F(","));
    }

    pIdx++;
  }
  Serial.println(F("}"));
}


void Command::setNextCommand(Command *nextCommand)
{
  _nextCommand = nextCommand;
}

Command * Command::getNextCommand()
{
  return _nextCommand;
}
