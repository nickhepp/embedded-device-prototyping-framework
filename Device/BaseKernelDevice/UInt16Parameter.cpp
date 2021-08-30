#include "uint16parameter.h"
#include "consts.h"
#include "cmd_param.h"


uint16_t UInt16Parameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	uint16_t val = 0;
	val = (uint16_t)atoi(cmd_params[pIdx].param_value);
	return val;
}

const char * UInt16Parameter::getValueType()
{
  return "uint16";  
}


uint8_t UInt16Parameter::getValueTypeID()
{
  return UINT16_VALUE_TYPEID;
}
