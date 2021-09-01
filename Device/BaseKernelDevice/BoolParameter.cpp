#include "boolparameter.h"
#include "cmd_param.h"
#include "consts.h"
#include <stdlib.h>
#include <arduino.h>

bool BoolParameter::getValue(uint8_t pIdx, struct cmd_param cmd_params[])
{
	bool val = 0;
	if (	(strcmp(cmd_params[pIdx].param_value, "TRUE") == 0) ||		// true capped
			(strcmp(cmd_params[pIdx].param_value, "true") == 0) ||		// true lower
			(strcmp(cmd_params[pIdx].param_value, "1") == 0))
	{
		val = 1;
	}
	return val;
}

const char * BoolParameter::getValueType()
{
  return "bool";  
}


uint8_t BoolParameter::getValueTypeID()
{
  return BOOL_VALUE_TYPEID;
}
