#include "uint8parameter.h"
#include "cmd_param.h"
#include "consts.h"
#include <stdlib.h>

uint8_t UInt8Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	uint8_t val = 0;
	val = (uint8_t)atoi(cmd_params[pIdx].param_value);
	return val;
}

const char * UInt8Parameter::getValueType()
{
  return "uint8";  
}

uint8_t UInt8Parameter::getValueTypeID()
{
  return UINT8_VALUE_TYPEID;
}
