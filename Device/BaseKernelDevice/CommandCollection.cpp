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


Command* CommandCollection::getCommandByName(const char* cmdName, size_t cmdNameSz)
{
	Serial.print("looking for ");
	Serial.print(cmdName);
	Serial.print(", ");
	//size_t cmdNameSz = strlen(cmdName);
	Serial.println(cmdNameSz, DEC);

	/*
	Command* currCmd = _headPtr;
	do {

		if ((cmdNameSz == currCmd->_cmdNameSz) || (memcmp(currCmd->_cmdName, cmdName, cmdNameSz) == 0))
		{
			return currCmd;
		}

	} while (currCmd->_nextCommand != NULL_PTR);
	*/

	if (_headPtr != NULL_PTR)
	{
		Command* currCmd = _headPtr;

		while (currCmd->_nextCommand != NULL_PTR)
		{

			Serial.print("comparing ");
			Serial.print(currCmd->_cmdName);
			Serial.print(", ");
			//size_t cmdNameSz = strlen(cmdName);
			Serial.println(currCmd->_cmdNameSz, DEC);

			if ((cmdNameSz == currCmd->_cmdNameSz) || (memcmp(currCmd->_cmdName, cmdName, cmdNameSz) == 0))
			{
				return currCmd;
			}
			currCmd = currCmd->_nextCommand;
		}
	}



	return NULL_PTR;
}

