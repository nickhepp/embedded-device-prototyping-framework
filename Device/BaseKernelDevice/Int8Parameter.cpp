#include "int8parameter.h"
#include "consts.h"

int8_t int8val = -8;
int8_t Int8Parameter::getValue(uint8_t pIdx)
{
  int8val++;
  return int8val;
}

const char * Int8Parameter::getValueType()
{
  return "int8";  
}

uint8_t Int8Parameter::getValueTypeID()
{
  return INT8_VALUE_TYPEID;
}
