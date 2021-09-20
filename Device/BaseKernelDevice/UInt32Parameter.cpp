#include "uint32parameter.h"
#include "consts.h"
#include "cmd_param.h"
#include <stdlib.h>

uint32_t UInt32Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	uint32_t val = 0;
	val = (uint32_t)atol(cmd_params[pIdx].param_value);
	return val;
}

const char * UInt32Parameter::getValueType()
{
  return "uint32";  
}

uint8_t UInt32Parameter::getValueTypeID()
{
  return UINT32_VALUE_TYPEID;
}
