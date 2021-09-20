#include "int32parameter.h"
#include "consts.h"
#include "cmd_param.h"

int32_t Int32Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	int32_t val = 0;
	val = (int32_t)atol(cmd_params[pIdx].param_value);
	return val;
}

const char * Int32Parameter::getValueType()
{
  return "int32";  
}

uint8_t Int32Parameter::getValueTypeID()
{
  return INT32_VALUE_TYPEID;
}
