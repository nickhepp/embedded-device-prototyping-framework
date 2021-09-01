#ifndef __CMD_PARAM_H__
#define __CMD_PARAM_H__

#include "consts.h"


// structure of a command parameter
struct cmd_param
{
    // value of the parameter
    char param_value[PARAM_VALUE_LENGTH];
};


#endif // __CMD_PARAM_H__

