#include "uint32parameter.h"
#include "consts.h"

uint32_t uint32val = 32;

uint32_t UInt32Parameter::getValue(uint8_t pIdx)
{
  uint32val++;
  return uint32val;
}

const char * UInt32Parameter::getValueType()
{
  return "uint32";  
}

uint8_t UInt32Parameter::getValueTypeID()
{
  return UINT32_VALUE_TYPEID;
}
