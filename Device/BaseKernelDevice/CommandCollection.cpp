#include "commandcollection.h"
#include "consts.h"

CommandCollection::CommandCollection()
{
  _headPtr = NULL_PTR;
}

void CommandCollection::addCommand(Command *cmd)
{
	if (_headPtr == NULL_PTR)
	{
		// this is the first, set the first
		_headPtr = cmd;
	}
	else {
		// start at the first and keep going until we find the first open spot
		Command* currCmd = _headPtr;
		while (currCmd->_nextCommand != NULL_PTR)
		{
			currCmd = currCmd->_nextCommand;
		}
		currCmd->_nextCommand = cmd;
	}
}

Command* CommandCollection::getCommandByPtr(Command* cmd)
{
	Command* nextCmd;
	if (cmd == NULL_PTR)
	{
		nextCmd = _headPtr;
	}
	else
	{
		nextCmd = cmd->_nextCommand;
	}
	return nextCmd;
}

Command* CommandCollection::getCommandByName(const char* cmdName, size_t cmdNameSz)
{
	Command* currCmd = _headPtr;
	while (currCmd != NULL_PTR)
	{
		if ((cmdNameSz == currCmd->_cmdNameSz) && (memcmp(currCmd->_cmdName, cmdName, cmdNameSz) == 0))
		{
			return currCmd;
		}
		currCmd = currCmd->_nextCommand;
	}

	return NULL_PTR;
}

