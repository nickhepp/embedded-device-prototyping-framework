#ifndef __EDPF_COMMANDCOLLECTION__
#define __EDPF_COMMANDCOLLECTION__

#include "parameter.h"
#include "command.h"

class CommandCollection
{
    public:

        CommandCollection();

        void addCommand(Command *cmd);

        Command* getCommandByName(const char* cmdName, size_t cmdNameSz);

        Command* getCommandByPtr(Command* cmd);

    private:

        Command* _headPtr;
    
};

#endif //__EDPF_COMMANDCOLLECTION__
