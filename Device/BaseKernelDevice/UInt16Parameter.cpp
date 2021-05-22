#include "uint16parameter.h"
#include "consts.h"

uint16_t uint16val = 16;
uint16_t UInt16Parameter::getValue(uint8_t pIdx)
{
  uint16val++;
  return uint16val;
}

const char * UInt16Parameter::getValueType()
{
  return "uint16";  
}


uint8_t UInt16Parameter::getValueTypeID()
{
  return UINT16_VALUE_TYPEID;
}
