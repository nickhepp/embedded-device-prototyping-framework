#include "uint8parameter.h"
#include "consts.h"

uint8_t test_val = 8;
uint8_t UInt8Parameter::getValue(uint8_t pIdx)
{
  test_val++;
  return test_val;
}

const char * UInt8Parameter::getValueType()
{
  return "uint8";  
}

uint8_t UInt8Parameter::getValueTypeID()
{
  return UINT8_VALUE_TYPEID;
}
