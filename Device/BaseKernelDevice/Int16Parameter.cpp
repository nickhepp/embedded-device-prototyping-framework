#include "int16parameter.h"
#include "consts.h"

int16_t valint16 = -16;
int16_t Int16Parameter::getValue(uint8_t pIdx)
{
  valint16++;
  return valint16;
}

const char * Int16Parameter::getValueType()
{
  return "int16";  
}


uint8_t Int16Parameter::getValueTypeID()
{
  return INT16_VALUE_TYPEID;
}
