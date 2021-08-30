#include "int8parameter.h"
#include "cmd_param.h"
#include "consts.h"
#include <stdlib.h>

int8_t Int8Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	int8_t val = 0;
	val = (int8_t)atoi(cmd_params[pIdx].param_value);
	return val;
}

const char * Int8Parameter::getValueType()
{
  return "int8";  
}

uint8_t Int8Parameter::getValueTypeID()
{
  return INT8_VALUE_TYPEID;
}
