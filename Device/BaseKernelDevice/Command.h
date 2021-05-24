#ifndef __EDPF_COMMAND__
#define __EDPF_COMMAND__

#include <arduino.h>
#include "consts.h"
#include "parameter.h"

struct param_ptr
{
  
  Parameter *param;
  
  const char *param_name;
  
  size_t param_name_len;
  
};

class Command
{
    public:
  
        Command();

        void initCommand(const char *cmdName, void (*callback_handle)(Command*));

        void execute();
    
        void addUInt8Parameter(const char *paramName);
	
        bool getUInt8Parameter(const char *paramName, uint8_t *val);

        void addUInt16Parameter(const char *paramName);

        bool getUInt16Parameter(const char *paramName, uint16_t *val);    

        void addUInt32Parameter(const char *paramName);

        bool getUInt32Parameter(const char *paramName, uint32_t *val);

        void addInt8Parameter(const char *paramName);

        bool getInt8Parameter(const char *paramName, int8_t *val);

        void addInt16Parameter(const char *paramName);

        bool getInt16Parameter(const char *paramName, int16_t *val);

        void addInt32Parameter(const char *paramName);

        bool getInt32Parameter(const char *paramName, int32_t *val);    

        void addBoolParameter(const char *paramName);

        bool getBoolParameter(const char *paramName, bool *val);    

        void addDoubleParameter(const char *paramName);

        bool getDoubleParameter(const char *paramName, double *val);
    
        void printCommand();

        void setNextCommand(Command *nextCommand);

        Command *getNextCommand();

    private:

        uint8_t getParamByTypeAndName(uint8_t typeID, const char *paramName);

        void addParameter(const char *paramName, Parameter *param);
    
        const char *_cmdName;

        size_t _cmdNameSz;
    
        param_ptr _params[MAX_COMMAND_PARAMS];
    
        uint8_t _paramsCnt;

        void (*_callback_handle)(Command *);

        Command *_nextCommand;

        friend class CommandCollection;
};

#endif //__EDPF_COMMAND__
