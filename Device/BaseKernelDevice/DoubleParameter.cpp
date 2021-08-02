#include "doubleparameter.h"
#include "consts.h"

double dblval = 1.0;

double DoubleParameter::getValue(uint8_t pIdx)
{
  dblval += 0.1;
  return dblval;
}

const char * DoubleParameter::getValueType()
{
  return "double";  
}


uint8_t DoubleParameter::getValueTypeID()
{
  return DOUBLE_VALUE_TYPEID;
}
