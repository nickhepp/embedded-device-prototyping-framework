#include "boolparameter.h"
#include "consts.h"

bool boolval = false;

bool BoolParameter::getValue(uint8_t pIdx)
{
  boolval = !boolval;
  return boolval;
}

const char * BoolParameter::getValueType()
{
  return "bool";  
}


uint8_t BoolParameter::getValueTypeID()
{
  return BOOL_VALUE_TYPEID;
}
