#ifndef __CONSTS__
#define __CONSTS__

#define MAX_COMMAND_PARAMS  (8)
#define NULL_PTR            (0)
#define UNDEFINED_PARAM_IDX	(255)


//const uint8_t getValueTypeID() = 0;
#define BOOL_VALUE_TYPEID     (0)
#define UINT8_VALUE_TYPEID    (1)
#define UINT16_VALUE_TYPEID   (2)
#define UINT32_VALUE_TYPEID   (3)
#define INT8_VALUE_TYPEID     (4)
#define INT16_VALUE_TYPEID    (5)
#define INT32_VALUE_TYPEID    (6)
#define DOUBLE_VALUE_TYPEID   (7)

#define PARAM_VALUE_LENGTH		(16)
#define CMD_PARAMS_COUNT        (8)

#define INCLUDE_PARAM_IO_COMMAND		(1)
#define INCLUDE_SHOW_HIGHLIGHTS_COMMAND	(1)
#define INCLUDE_CHARTING_VALUES_COMMAND	(1)


#endif //__CONSTS__
