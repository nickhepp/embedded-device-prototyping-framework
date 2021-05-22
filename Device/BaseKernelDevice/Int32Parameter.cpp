#include "int32parameter.h"
#include "consts.h"

int32_t int32val = -32;
int32_t Int32Parameter::getValue(uint8_t pIdx)
{
  int32val++;
  return int32val;
}

const char * Int32Parameter::getValueType()
{
  return "int32";  
}

uint8_t Int32Parameter::getValueTypeID()
{
  return INT32_VALUE_TYPEID;
}
