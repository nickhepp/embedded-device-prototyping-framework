#include "int16parameter.h"
#include "consts.h"
#include "cmd_param.h"

int16_t Int16Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	int16_t val = 0;
	val = (int16_t)atoi(cmd_params[pIdx].param_value);
	return val;
}

const char * Int16Parameter::getValueType()
{
  return "int16";  
}


uint8_t Int16Parameter::getValueTypeID()
{
  return INT16_VALUE_TYPEID;
}
