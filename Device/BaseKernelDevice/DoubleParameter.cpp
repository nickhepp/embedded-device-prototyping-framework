#include "doubleparameter.h"
#include "cmd_param.h"
#include "consts.h"
#include <stdlib.h>


double DoubleParameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	double val;
	val = atof(cmd_params[pIdx].param_value);
	return val;
}

const char * DoubleParameter::getValueType()
{
  return "double";  
}


uint8_t DoubleParameter::getValueTypeID()
{
  return DOUBLE_VALUE_TYPEID;
}
